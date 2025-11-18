using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WowLogAnalyzer.Enums;
using WowLogAnalyzer.Serialization;
using WowLogAnalyzer.WowEvents;
namespace WowLogAnalyzer.Entities;

public class CombatEvent
{
    [Key]
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    [Required]
    public CombatSubEventType EventType { get; set; } = CombatSubEventType.Unknown;

    public double? Amount { get; set; }
    public AmountType? AmountType { get; set; }


    public double? AmountIncoming { get; set; }
    public AmountType? AmountIncomingType { get; set; }

    public string ToGuid { get; set; } = "";
    public string FromGuid { get; set; } = "";

    public int? ToCharacterId { get; set; }

    [ForeignKey(nameof(ToCharacterId))]
    public Character ToCharacter { get; set; } = null!;

    public int? FromCharacterId { get; set; }

    [ForeignKey(nameof(FromCharacterId))]
    public Character FromCharacter { get; set; } = null!;

    [Column(TypeName = "jsonb")]
    public object EventData { get; set; } = default!;

    [NotMapped]
    public ICombatEvent Event
        => EventPayloadSerializer.Deserialize(EventType, EventData);

    [NotMapped]
    public ICombatEvent Payload { get; set; } = default!;
    
    public int LogId { get; set; }

    [ForeignKey(nameof(LogId))]
    public Log Log { get; set; } = null!;

    public int? EncounterId { get; set; }

    [ForeignKey(nameof(EncounterId))]
    public Encounter Encounter { get; set; } = null!;
}