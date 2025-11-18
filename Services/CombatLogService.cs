using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using WowLogAnalyzer.Data;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Enums;
using WowLogAnalyzer.Repository;
using WowLogAnalyzer.Utilities;
using WowLogAnalyzer.WowEvents;
using WowLogAnalyzer.Registry;
using WowLogAnalyzer.Parsers;

namespace WowLogAnalyzer.Services;
public class CombatLogService(AppDbContext dbContext, IUserRepository userRepository)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

    public async Task ParseLogFileAsync(IFormFile file, Log log)
    {
        using var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
        string? line;

        // Using EF took 22+ minutes, switching to COPY
        string connectionString = _dbContext.Database.GetDbConnection().ConnectionString;

        await using var conn = new NpgsqlConnection(connectionString);
        await conn.OpenAsync();
        
        using var writer = await conn.BeginBinaryImportAsync(@"
            COPY combat_events (
                log_id, 
                timestamp, 
                event_type, 
                event_data,
                from_guid,
                to_guid,
                amount,
                amount_type,
                amount_incoming,
                amount_incoming_type
            )
            FROM STDIN (FORMAT BINARY)");

        string currentZoneName = "";
        int currentInstanceId = -1;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            CombatEvent evt = ParseLine(line);
            ICombatEvent eventData = evt.Event;
            if (eventData is ZoneChange zoneChange)
            {
                currentInstanceId = zoneChange.InstanceId;
                currentZoneName = zoneChange.ZoneName;
            }

            if (eventData is ISourceDestCombatEvent sourceDestCombatEvent)
            {
                evt.FromGuid = sourceDestCombatEvent.SourceGUID;
                evt.ToGuid = sourceDestCombatEvent.DestGUID;

                // Denormalize amount and amount type for easier querying
                if (evt.FromGuid.StartsWith("Player-"))
                {
                    if (eventData is IHealCombatEvent healCombatEvent)
                    {
                        evt.Amount = healCombatEvent.Amount;
                        evt.AmountType = AmountType.HEAL;
                    }

                    if (eventData is IDamageCombatEvent damageCombatEvent)
                    {
                        evt.Amount = damageCombatEvent.Amount;
                        evt.AmountType = AmountType.DAMAGE;
                    }

                    if (eventData is IAbsorbCombatEvent absorbCombatEvent)
                    {
                        evt.Amount = absorbCombatEvent.Amount;
                        evt.AmountType = AmountType.ABSORB;
                    }
                }
                if (evt.ToGuid.StartsWith("Player-"))
                {
                    if (eventData is IHealCombatEvent incomingHealCombatEvent)
                    {
                        evt.AmountIncoming = incomingHealCombatEvent.Amount;
                        evt.AmountIncomingType = AmountType.HEAL;
                    }

                    if (eventData is IDamageCombatEvent incomingDamageCombatEvent)
                    {
                        evt.AmountIncoming = incomingDamageCombatEvent.Amount;
                        evt.AmountIncomingType = AmountType.DAMAGE;
                    }

                    if (eventData is IAbsorbCombatEvent incomingAbsorbCombatEvent)
                    {
                        evt.AmountIncoming = incomingAbsorbCombatEvent.Amount;
                        evt.AmountIncomingType = AmountType.ABSORB;
                    }
                }
            }
           
            evt.Log = log;
            await writer.StartRowAsync();
            writer.Write(log.Id, NpgsqlTypes.NpgsqlDbType.Integer);
            writer.Write(evt.Timestamp, NpgsqlTypes.NpgsqlDbType.TimestampTz);
            writer.Write((int)evt.EventType, NpgsqlTypes.NpgsqlDbType.Integer);
            writer.Write(JsonSerializer.Serialize(evt.EventData), NpgsqlTypes.NpgsqlDbType.Jsonb);
            writer.Write(evt.FromGuid, NpgsqlTypes.NpgsqlDbType.Text);
            writer.Write(evt.ToGuid, NpgsqlTypes.NpgsqlDbType.Text);
            writer.Write(evt.Amount, NpgsqlTypes.NpgsqlDbType.Double);
            writer.Write((int?)evt.AmountType, NpgsqlTypes.NpgsqlDbType.Integer);            
            writer.Write(evt.AmountIncoming, NpgsqlTypes.NpgsqlDbType.Double);
            writer.Write((int?)evt.AmountIncomingType, NpgsqlTypes.NpgsqlDbType.Integer);
        }
        await writer.CompleteAsync();
        writer.Close();
        
        using var addEncounter = new NpgsqlCommand($@"
            INSERT INTO encounters (
                encounter_name,
                encounter_id,
                start_at, 
                end_at, 
                start_combat_event_id,
                end_combat_event_id,
                difficulty,
                success,
                log_id )
            SELECT
                start_event.event_data->>'EncounterName',
                (start_event.event_data->>'EncounterId')::integer,
                start_event.timestamp,
                end_event.timestamp,
                start_event.id,
                end_event.id,
                (start_event.event_data->>'DifficultyId')::integer,
                EXISTS (
                    SELECT 1
                    FROM combat_events unit_died
                    WHERE 
                        unit_died.log_id = @logId AND
                        unit_died.id BETWEEN start_event.id AND end_event.id AND
                        unit_died.event_type = {(int)CombatSubEventType.UNIT_DIED} AND
                        unit_died.event_data->>'DestGUID' NOT LIKE 'Player-%' AND
                        (end_event.timestamp - INTERVAL '1000 milliseconds') <  unit_died.timestamp
                    ORDER BY id DESC
                    LIMIT 1
                ),
                start_event.log_id
            FROM combat_events start_event
            LEFT JOIN LATERAL (
                SELECT e2.id, e2.timestamp, e2.event_data->>'EncounterName' as encounter_name
                FROM combat_events e2
                WHERE 
                    e2.log_id = start_event.log_id AND 
                    e2.event_type = {(int)CombatSubEventType.ENCOUNTER_END} AND 
                    e2.timestamp > start_event.timestamp
                ORDER BY e2.timestamp
                LIMIT 1
            ) end_event ON TRUE
            WHERE 
                start_event.event_type = {(int)CombatSubEventType.ENCOUNTER_START} AND 
                start_event.log_id = @logId
            ORDER BY start_event.timestamp
        ", conn);
        addEncounter.CommandTimeout = 500;
        addEncounter.Parameters.AddWithValue("logId", log.Id);
        await addEncounter.ExecuteNonQueryAsync();

        using var updateCombatEventsWithEncounter = new NpgsqlCommand($@"
            UPDATE combat_events
                SET encounter_id = (
                    SELECT encounters.id
                    FROM encounters
                    WHERE 
                        combat_events.id BETWEEN encounters.start_combat_event_id AND encounters.end_combat_event_id AND
                        encounters.log_id = @logId
                    LIMIT 1
                )
            WHERE combat_events.log_id = @logId
        ", conn);
        updateCombatEventsWithEncounter.CommandTimeout = 500;
        updateCombatEventsWithEncounter.Parameters.AddWithValue("logId", log.Id);
        await updateCombatEventsWithEncounter.ExecuteNonQueryAsync();

        using var addCharacters = new NpgsqlCommand($@"
            INSERT INTO characters (
                created_at,
                name,
                guid,
                server)
            SELECT
                NOW(),
                SPLIT_PART((combat_events.event_data->>'SourceName'), '-', 1),
                (combat_events.event_data->>'SourceGUID'),
                SUBSTRING(
                    (combat_events.event_data->>'SourceName'),
                    POSITION('-' IN (combat_events.event_data->>'SourceName')) + 1  
                )
            FROM combat_events 
            WHERE 
                NOT EXISTS (
                    SELECT characters.guid 
                    FROM characters
                    WHERE characters.guid = (combat_events.event_data->>'SourceGUID')
                ) AND
                combat_events.event_type =  {(int)CombatSubEventType.SPELL_AURA_APPLIED} AND 
                (combat_events.event_data->>'SourceGUID') ILIKE 'Player%' AND
                combat_events.log_id = @logId
            GROUP BY (combat_events.event_data->>'SourceName'), (combat_events.event_data->>'SourceGUID')
          
        ", conn);
        addCharacters.CommandTimeout = 500;
        addCharacters.Parameters.AddWithValue("logId", log.Id);
        await addCharacters.ExecuteNonQueryAsync();

        using var addCharacterEncounters = new NpgsqlCommand($@"
            INSERT INTO character_encounters (
                spec_id,
                character_id,
                encounter_id )
            SELECT
                encounter.spec_id,
                characters.id,
                encounter.id
            FROM characters
            INNER JOIN LATERAL (
                SELECT encounter_inner.id as id, spec_unique_spells.spec_id
                FROM encounters encounter_inner
                INNER JOIN combat_events check_unique_spec_spell ON check_unique_spec_spell.encounter_id = encounter_inner.id
                INNER JOIN spec_unique_spells ON spec_unique_spells.spell_id = (check_unique_spec_spell.event_data->>'SpellId')::integer 
                WHERE 
                    encounter_inner.log_id = @logId AND
                    check_unique_spec_spell.event_type = ANY (@spellEvents) AND
                    (check_unique_spec_spell.event_data->>'SpellId')::integer = spec_unique_spells.spell_id AND
                    (check_unique_spec_spell.event_data->>'SourceGUID') = characters.guid

            ) encounter on true
            GROUP BY encounter.spec_id, characters.id, encounter.id 
        ", conn);

        addCharacterEncounters.CommandTimeout = 500;
        addCharacterEncounters.Parameters.AddWithValue("logId", log.Id);
        addCharacterEncounters.Parameters.Add("spellEvents", NpgsqlDbType.Array | NpgsqlDbType.Integer).Value = CombatEventMapper.SpellEvents();
        await addCharacterEncounters.ExecuteNonQueryAsync();

        using var setCharacterFromId = new NpgsqlCommand($@"
            UPDATE combat_events 
            SET from_character_id = (
                    SELECT characters.id
                    FROM characters
                    WHERE characters.guid = combat_events.from_guid
                    LIMIT 1
                )
            WHERE log_id = @logId AND combat_events.from_guid LIKE 'Player%'
        ", conn);
        setCharacterFromId.CommandTimeout = 500;
        setCharacterFromId.Parameters.AddWithValue("logId", log.Id);
        await setCharacterFromId.ExecuteNonQueryAsync();

        using var setCharacterToId = new NpgsqlCommand($@"
            UPDATE combat_events 
            SET to_character_id = (
                    SELECT characters.id
                    FROM characters
                    WHERE characters.guid = combat_events.to_guid
                    LIMIT 1
                )
            WHERE log_id = @logId AND combat_events.to_guid LIKE 'Player%'
        ", conn);
        setCharacterToId.CommandTimeout = 500;
        setCharacterToId.Parameters.AddWithValue("logId", log.Id);
        await setCharacterToId.ExecuteNonQueryAsync();
    }

    public CombatEvent ParseLine(string line)
    {
        // Parse timestamp index, just find the 2 spaces
        int timestampSplitIndex = line.IndexOf("  ");
        var timestampString = line[..timestampSplitIndex].Trim() + ":00";
        var timestamp = DateTime.ParseExact(
            timestampString,
            "M/d/yyyy HH:mm:ss.fffK",
            CultureInfo.InvariantCulture
        ).ToUniversalTime();

        // Regex split (respecting quoted fields)
        string pattern = "(?:^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(line[timestampSplitIndex..]);

        List<string> fields = [];
        foreach (Match match in matches)
        {
            string matchString = match.ToString().Trim();
            if (matchString.StartsWith(","))
                matchString = matchString[1..];

            if (matchString.StartsWith("\"") && matchString.EndsWith("\""))
                matchString = matchString[1..^1].Replace("\"\"", "\"");
    
            fields.Add(matchString);
        }

        CombatSubEventType eventType = CombatEventMapper.ParseSubEvent(fields[0]);

        ICombatEvent eventData = ParsePayload(eventType, [.. fields]);


        var evt = new CombatEvent
        {
            Timestamp = timestamp,
            EventType = eventType,
            EventData = eventData
        };

        return evt;
    }

    private static ICombatEvent ParsePayload(CombatSubEventType type, string[] f)
    {
        var payloadType = PayloadTypeRegistry.GetPayloadType(type)
            ?? throw new Exception($"No payload type found for event type {f[0]} ");

        return (ICombatEvent)PayloadReflectionParser.Parse(f, payloadType);
    }
}
