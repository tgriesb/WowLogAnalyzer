using System;
using WowLogAnalyzer.Enums;
using WowLogAnalyzer.Services;
using WowLogAnalyzer.WowEvents;
using Xunit;

namespace WowLogAnalyzer.Tests.Services
{
    public class CombatLogService_RealWorldTests
    {
        [Fact]
        public void ParseLine_SpellDrain_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:27:16.762-6  SPELL_DRAIN,Vehicle-0-4392-1008-12040-60009-00001E9849,""Feng the Accursed"",0x10a48,0x80000000,Player-4385-05E5E88C,""Kalleth-Immerseus-US"",0x514,0x80000000,118783,""Chains of Shadow"",0x20,Player-4385-05E5E88C,0000000000000000,100,100,800,34049,44565,0,0,0,300000,300000,0,4049.22,1344.94,471,1.5335,514,3000,0,0,300000";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_DRAIN, evt.EventType);

            var drain = Assert.IsType<SpellDrain>(evt.EventData);
            Assert.Equal("Vehicle-0-4392-1008-12040-60009-00001E9849", drain.SourceGUID);
            Assert.Equal("Feng the Accursed", drain.SourceName);
            Assert.Equal(0x10a48, drain.SourceFlags);
            Assert.Equal(0x80000000, drain.SourceRaidFlags);
            Assert.Equal("Player-4385-05E5E88C", drain.DestGUID);
            Assert.Equal("Kalleth-Immerseus-US", drain.DestName);
            Assert.Equal(0x514, drain.DestFlags);
            Assert.Equal(0x80000000, drain.DestRaidFlags);
            Assert.Equal(118783, drain.SpellId);
            Assert.Equal("Chains of Shadow", drain.SpellName);
            Assert.Equal(0x20, drain.SpellSchool);
            Assert.Equal(514, drain.ItemLvl);
            Assert.Equal(3000, drain.Amount);
        }

        [Fact]
        public void ParseLine_DamageSplit_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:17:32.710-6  DAMAGE_SPLIT,Player-4385-05E74D63,""Spiraled-Immerseus-US"",0x514,0x80000000,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000040,115213,""Avert Harm"",0x1,Player-4385-05E60F02,0000000000000000,71,100,80328,250,18828,0,0,3,71,100,0,-2119.19,379.57,474,5.0341,510,0,0,-1,8,0,0,4974,nil,nil,nil,AOE";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.DAMAGE_SPLIT, evt.EventType);

            var ds = Assert.IsType<DamageSplit>(evt.EventData);
            Assert.Equal("Player-4385-05E74D63", ds.SourceGUID);
            Assert.Equal("Spiraled-Immerseus-US", ds.SourceName);
            Assert.Equal(0x514, ds.SourceFlags);
            Assert.Equal(0x80000000, ds.SourceRaidFlags);
            Assert.Equal("Player-4385-05E60F02", ds.DestGUID);
            Assert.Equal("Holygran-Immerseus-US", ds.DestName);
            Assert.Equal(0x40512, ds.DestFlags);
            Assert.Equal(0x80000040, ds.DestRaidFlags);
            Assert.Equal(115213, ds.SpellId);
            Assert.Equal("Avert Harm", ds.SpellName);
            Assert.Equal(0x1, ds.SpellSchool);
        }

        [Fact]
        public void ParseLine_Emote_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:49.752-6  EMOTE,Creature-0-4392-1009-10294-62543-00001E83B5,""Blade Lord Ta'yak"",Player-4385-05E5E88C,""Kalleth"",Blade Lord Ta'yak marks Kalleth for |cFFFF0000|Hspell:122949|h[Unseen Strike]|h|r!";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.EMOTE, evt.EventType);

            var emote = Assert.IsType<Emote>(evt.EventData);
            Assert.Equal("Creature-0-4392-1009-10294-62543-00001E83B5", emote.SourceGUID);
            Assert.Equal("Blade Lord Ta'yak", emote.SourceName);
            Assert.Equal("Player-4385-05E5E88C", emote.DestGUID);
            Assert.Equal("Kalleth", emote.DestName);
            Assert.Contains("Unseen Strike", emote.Message);
        }

        [Fact]
        public void ParseLine_EncounterStart_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:19.127-6  ENCOUNTER_START,1504,""Blade Lord Ta'yak"",5,10,1009,19";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.ENCOUNTER_START, evt.EventType);
            var start = Assert.IsType<EncounterStart>(evt.EventData);
            Assert.Equal(1504, start.EncounterId);
            Assert.Equal("Blade Lord Ta'yak", start.EncounterName);
            Assert.Equal(5, start.DifficultyId);
            Assert.Equal(10, start.GroupSize);
        }

        [Fact]
        public void ParseLine_EncounterEnd_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:18:20.259-6  ENCOUNTER_END,1504,""Blade Lord Ta'yak"",5,10,1";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.ENCOUNTER_END, evt.EventType);
            var end = Assert.IsType<EncounterEnd>(evt.EventData);
            Assert.Equal(1504, end.EncounterId);
            Assert.Equal("Blade Lord Ta'yak", end.EncounterName);
            Assert.Equal(5, end.DifficultyId);
            Assert.Equal(10, end.GroupSize);
            Assert.Equal(1, end.Success);
        }

        [Fact]
        public void ParseLine_EnvironmentalDamage_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:19:37.939-6  ENVIRONMENTAL_DAMAGE,0000000000000000,nil,0x80000000,0x80000000,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Player-4385-05E55B5C,0000000000000000,92,100,162,38080,15117,0,0,0,252439,300000,0,-1938.52,477.94,475,5.2772,510,Falling,46249,46249,0,1,0,0,0,nil,nil,nil";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.ENVIRONMENTAL_DAMAGE, evt.EventType);

            var env = Assert.IsType<EnvironmentalDamage>(evt.EventData);
            Assert.Equal("0000000000000000", env.SourceGUID);
            Assert.Equal("Player-4385-05E55B5C", env.DestGUID);
            Assert.Null(env.SourceName);
            Assert.Equal(0x80000000, env.SourceFlags);
            Assert.Equal(0x80000000, env.SourceRaidFlags);
            Assert.Equal("Player-4385-05E55B5C", env.DestGUID);
            Assert.Equal("Jiglyball-Immerseus-US", env.DestName);
            Assert.Equal(0x514, env.DestFlags);
            Assert.Equal(0x80000000, env.DestRaidFlags);
            Assert.Equal("Falling", env.DamageType);
            Assert.Equal(46249, env.Amount);
            Assert.Equal(46249, env.Overkill);
        }

        [Fact]
        public void ParseLine_MapChange_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:32.893-6  MAP_CHANGE,475,""Heart of Fear"",-1769.998535,-2730.001465,1430.010010,-9.994370";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.MAP_CHANGE, evt.EventType);

            var map = Assert.IsType<MapChange>(evt.EventData);
            Assert.Equal(475, map.MapId);
            Assert.Equal("Heart of Fear", map.MapName);
            Assert.Equal(-1769.998535, map.X0, 6);
            Assert.Equal(-2730.001465, map.X1, 6);
            Assert.Equal(1430.010010, map.Y0, 6);
            Assert.Equal(-9.994370, map.Y1, 6);
        }

        [Fact]
        public void ParseLine_PartyKill_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:18:20.157-6  PARTY_KILL,Player-4385-05E528FE,""Ugali-Immerseus-US"",0x40511,0x80000000,Creature-0-4392-1009-10294-62543-00001E83B5,""Blade Lord Ta'yak"",0x10a48,0x80000000,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.PARTY_KILL, evt.EventType);

            var pk = Assert.IsType<PartyKill>(evt.EventData);
            Assert.Equal("Player-4385-05E528FE", pk.SourceGUID);
            Assert.Equal("Ugali-Immerseus-US", pk.SourceName);
            Assert.Equal(0x40511, pk.SourceFlags);
            Assert.Equal(0x80000000, pk.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1009-10294-62543-00001E83B5", pk.DestGUID);
            Assert.Equal("Blade Lord Ta'yak", pk.DestName);
            Assert.Equal(0x10a48, pk.DestFlags);
            Assert.Equal(0x80000000, pk.DestRaidFlags);
        }

        [Fact]
        public void ParseLine_RangeDamage_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:23.473-6  RANGE_DAMAGE,Player-4385-05E55270,""Snippss-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-62543-00001E83B5,""Blade Lord Ta'yak"",0x10a48,0x80000000,75,""Auto Shot"",0x1,Creature-0-4392-1009-10294-62543-00001E83B5,0000000000000000,193200897,196261650,0,0,0,0,0,-1,0,0,0,-2100.94,281.07,474,3.1451,93,21353,27954,-1,1,0,0,0,nil,nil,nil,ST";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.RANGE_DAMAGE, evt.EventType);

            var rd = Assert.IsType<RangeDamage>(evt.EventData);
            Assert.Equal("Player-4385-05E55270", rd.SourceGUID);
            Assert.Equal("Snippss-Immerseus-US", rd.SourceName);
            Assert.Equal(0x512, rd.SourceFlags);
            Assert.Equal(0x80000000, rd.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1009-10294-62543-00001E83B5", rd.DestGUID);
            Assert.Equal("Blade Lord Ta'yak", rd.DestName);
            Assert.Equal(0x10a48, rd.DestFlags);
            Assert.Equal(0x80000000, rd.DestRaidFlags);
            Assert.Equal(75, rd.SpellId);
            Assert.Equal("Auto Shot", rd.SpellName);
            Assert.Equal(0x1, rd.SpellSchool);
            Assert.Equal(21353, rd.Amount);
            Assert.Equal(27954, rd.Overkill);
        }

        [Fact]
        public void ParseLine_RangeMissed_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:28:25.230-6  RANGE_MISSED,Player-4385-05E55270,""Snippss-Immerseus-US"",0x512,0x80000000,Vehicle-0-4392-1008-12040-60009-00001E9849,""Feng the Accursed"",0x10a48,0x80000000,75,""Auto Shot"",0x1,MISS,nil";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.RANGE_MISSED, evt.EventType);

            var rm = Assert.IsType<RangeMissed>(evt.EventData);
            Assert.Equal("Player-4385-05E55270", rm.SourceGUID);
            Assert.Equal("Snippss-Immerseus-US", rm.SourceName);
            Assert.Equal(0x512, rm.SourceFlags);
            Assert.Equal(0x80000000, rm.SourceRaidFlags);
            Assert.Equal("Vehicle-0-4392-1008-12040-60009-00001E9849", rm.DestGUID);
            Assert.Equal("Feng the Accursed", rm.DestName);
            Assert.Equal(0x10a48, rm.DestFlags);
            Assert.Equal(0x80000000, rm.DestRaidFlags);
            Assert.Equal(75, rm.SpellId);
            Assert.Equal("Auto Shot", rm.SpellName);
            Assert.Equal(0x1, rm.SpellSchool);
            Assert.Equal("MISS", rm.MissType);
        }

        [Fact]
        public void ParseLine_SpellAbsorbed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.117-6  SPELL_ABSORBED,Creature-0-4392-1009-10294-64339-00001E83B5,""Instructor Tak'thok"",0xa48,0x80000000,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000000,123474,""Overwhelming Assault"",0x1,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000000,115069,""Stance of the Sturdy Ox"",0x1,191945,202481";

            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_ABSORBED, evt.EventType);

            var sa = Assert.IsType<SpellAbsorbed>(evt.EventData);
            Assert.Equal("Creature-0-4392-1009-10294-64339-00001E83B5", sa.SourceGUID);
            Assert.Equal("Instructor Tak'thok", sa.SourceName);
            Assert.Equal(0xa48, sa.SourceFlags);
            Assert.Equal(0x80000000, sa.SourceRaidFlags);
            Assert.Equal("Player-4385-05E60F02", sa.DestGUID);
            Assert.Equal("Holygran-Immerseus-US", sa.DestName);
            Assert.Equal(0x40512, sa.DestFlags);
            Assert.Equal(0x80000000, sa.DestRaidFlags);
            Assert.Equal(123474, sa.SpellId);
            Assert.Equal("Overwhelming Assault", sa.SpellName);
            Assert.Equal(0x1, sa.SpellSchool);
            Assert.Equal(115069, sa.AbsorbSpellId);
            Assert.Equal("Stance of the Sturdy Ox", sa.AbsorbSpellName);
            Assert.Equal(0x1, sa.AbsorbSpellSchool);
            Assert.Equal(191945, sa.Amount);
        }

        [Fact]
        public void ParseLine_SpellAuraApplied_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:32.938-6  SPELL_AURA_APPLIED,Player-4385-05E528FE,""Ugali-Immerseus-US"",0x511,0x80000000,Player-4385-05E528FE,""Ugali-Immerseus-US"",0x511,0x80000000,25780,""Righteous Fury"",0x0,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_APPLIED, evt.EventType);

            var aura = Assert.IsType<SpellAuraApplied>(evt.EventData);
            Assert.Equal("Player-4385-05E528FE", aura.SourceGUID);
            Assert.Equal("Ugali-Immerseus-US", aura.SourceName);
            Assert.Equal(0x511, aura.SourceFlags);
            Assert.Equal(0x80000000, aura.SourceRaidFlags);
            Assert.Equal("Player-4385-05E528FE", aura.DestGUID);
            Assert.Equal("Ugali-Immerseus-US", aura.DestName);
            Assert.Equal(0x511, aura.DestFlags);
            Assert.Equal(0x80000000, aura.DestRaidFlags);
            Assert.Equal(25780, aura.SpellId);
            Assert.Equal("Righteous Fury", aura.SpellName);
            Assert.Equal(0x0, aura.SpellSchool);
            Assert.Equal("BUFF", aura.AuraType);
        }

        [Fact]
        public void ParseLine_SpellAuraAppliedDose_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.143-6  SPELL_AURA_APPLIED_DOSE,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,117828,""Backdraft"",0x1,BUFF,4";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_APPLIED_DOSE, evt.EventType);

            var ad = Assert.IsType<SpellAuraAppliedDose>(evt.EventData);
            Assert.Equal(117828, ad.SpellId);
            Assert.Equal("Backdraft", ad.SpellName);
            Assert.Equal(0x1, ad.SpellSchool);
            Assert.Equal("BUFF", ad.AuraType);
            Assert.Equal("4", ad.AuraDose);
        }

        [Fact]
        public void ParseLine_SpellAuraBroken_ParsesCorrectly()
        {
            var line = @"11/19/2025 23:28:24.576-6  SPELL_AURA_BROKEN,0000000000000000,nil,0x80000000,0x80000000,Player-4385-05E62478,""Megasourass-LeiShen-US"",0x518,0x80000000,546,""Water Walking"",0x8,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_BROKEN, evt.EventType);

            var ab = Assert.IsType<SpellAuraBroken>(evt.EventData);
            Assert.Equal("0000000000000000", ab.SourceGUID);
            Assert.Null(ab.SourceName);
            Assert.Equal(0x80000000, ab.SourceFlags);
            Assert.Equal(0x80000000, ab.SourceRaidFlags);
            Assert.Equal("Player-4385-05E62478", ab.DestGUID);
            Assert.Equal("Megasourass-LeiShen-US", ab.DestName);
            Assert.Equal(0x518, ab.DestFlags);
            Assert.Equal(0x80000000, ab.DestRaidFlags);
            Assert.Equal(546, ab.SpellId);
            Assert.Equal("Water Walking", ab.SpellName);
            Assert.Equal(0x8, ab.SpellSchool);
            Assert.Equal("BUFF", ab.AuraType);
        }

        [Fact]
        public void ParseLine_SpellAuraBrokenSpell_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:59:06.022-6  SPELL_AURA_BROKEN_SPELL,Player-4385-05E528FE,""Ugali-Immerseus-US"",0x40511,0x80000000,Creature-0-4392-1008-12040-62618-00001EA00A,""Cosmic Spark"",0x12248,0x80000000,3355,""Freezing Trap"",0x10,20271,""Judgment"",2,DEBUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_BROKEN_SPELL, evt.EventType);

            var asb = Assert.IsType<SpellAuraBrokenSpell>(evt.EventData);
            Assert.Equal("Player-4385-05E528FE", asb.SourceGUID);
            Assert.Equal("Ugali-Immerseus-US", asb.SourceName);
            Assert.Equal(0x40511, asb.SourceFlags);
            Assert.Equal(0x80000000, asb.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1008-12040-62618-00001EA00A", asb.DestGUID);
            Assert.Equal("Cosmic Spark", asb.DestName);
            Assert.Equal(0x12248, asb.DestFlags);
            Assert.Equal(0x80000000, asb.DestRaidFlags);
            Assert.Equal(3355, asb.SpellId);
            Assert.Equal("Freezing Trap", asb.SpellName);
            Assert.Equal(0x10, asb.SpellSchool);
            Assert.Equal(20271, asb.BreakingSpellId);
            Assert.Equal("Judgment", asb.BreakingSpellName);
            Assert.Equal(2, asb.BreakingSpellSchool);
            Assert.Equal("DEBUFF", asb.AuraType);
        }

        [Fact]
        public void ParseLine_SpellAuraRefresh_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.127-6  SPELL_AURA_REFRESH,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,123254,""Twist of Fate"",0x1,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_REFRESH, evt.EventType);

            var ar = Assert.IsType<SpellAuraRefresh>(evt.EventData);
            Assert.Equal(123254, ar.SpellId);
            Assert.Equal("Twist of Fate", ar.SpellName);
            Assert.Equal(0x1, ar.SpellSchool);
            Assert.Equal("BUFF", ar.AuraType);
        }

        [Fact]
        public void ParseLine_SpellAuraRemoved_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.113-6  SPELL_AURA_REMOVED,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,104232,""Rain of Fire"",0x4,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_REMOVED, evt.EventType);

            var sr = Assert.IsType<SpellAuraRemoved>(evt.EventData);
            Assert.Equal(104232, sr.SpellId);
            Assert.Equal("Rain of Fire", sr.SpellName);
            Assert.Equal(0x4, sr.SpellSchool);
            Assert.Equal("BUFF", sr.AuraType);
        }

        [Fact]
        public void ParseLine_SpellAuraRemovedDose_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.084-6  SPELL_AURA_REMOVED_DOSE,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,117828,""Backdraft"",0x1,BUFF,1";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_AURA_REMOVED_DOSE, evt.EventType);

            var rdose = Assert.IsType<SpellAuraRemovedDose>(evt.EventData);
            Assert.Equal(117828, rdose.SpellId);
            Assert.Equal("Backdraft", rdose.SpellName);
            Assert.Equal(0x1, rdose.SpellSchool);
            Assert.Equal("BUFF", rdose.AuraType);
            Assert.Equal(1, rdose.AuraDose);
        }

        [Fact]
        public void ParseLine_SpellCastFailed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:13:07.143-6  SPELL_CAST_FAILED,Player-4385-05E528FE,""Ugali-Immerseus-US"",0x40511,0x80000000,0000000000000000,nil,0x80000000,0x80000000,31801,""Seal of Truth"",0x2,""Not enough mana""";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_CAST_FAILED, evt.EventType);

            var cf = Assert.IsType<SpellCastFailed>(evt.EventData);
            Assert.Equal("Player-4385-05E528FE", cf.SourceGUID);
            Assert.Equal("Ugali-Immerseus-US", cf.SourceName);
            Assert.Equal(0x40511, cf.SourceFlags);
            Assert.Equal("0000000000000000", cf.DestGUID);
            Assert.Null(cf.DestName);
            Assert.Equal(0x80000000, cf.DestFlags);
            Assert.Equal(31801, cf.SpellId);
            Assert.Equal("Seal of Truth", cf.SpellName);
            Assert.Equal(0x2, cf.SpellSchool);
            Assert.Equal("Not enough mana", cf.FailMessage);
        }

        [Fact]
        public void ParseLine_SpellCastStart_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.145-6  SPELL_CAST_START,Player-4385-05E74D63,""Spiraled-Immerseus-US"",0x514,0x80000000,0000000000000000,nil,0x80000000,0x80000000,78674,""Starsurge"",0x48";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_CAST_START, evt.EventType);

            var cs = Assert.IsType<SpellCastStart>(evt.EventData);
            Assert.Equal(78674, cs.SpellId);
            Assert.Equal("Starsurge", cs.SpellName);
            Assert.Equal(0x48, cs.SpellSchool);
        }

                [Fact]
        public void ParseLine_SpellCastSuccess_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.084-6  SPELL_CAST_SUCCESS,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Creature-0-4392-1009-10294-64339-00001E83B5,""Instructor Tak'thok"",0xa48,0x80000000,29722,""Incinerate"",0x4,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_CAST_SUCCESS, evt.EventType);

            var sc = Assert.IsType<SpellCastSuccess>(evt.EventData);
            Assert.Equal("Player-4385-05E55B5C", sc.SourceGUID);
            Assert.Equal("Jiglyball-Immerseus-US", sc.SourceName);
            Assert.Equal(0x514, sc.SourceFlags);
            Assert.Equal(0x80000000, sc.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1009-10294-64339-00001E83B5", sc.DestGUID);
            Assert.Equal("Instructor Tak'thok", sc.DestName);
            Assert.Equal(0xa48, sc.DestFlags);
            Assert.Equal(0x80000000, sc.DestRaidFlags);
            Assert.Equal(29722, sc.SpellId);
            Assert.Equal("Incinerate", sc.SpellName);
            Assert.Equal(0x4, sc.SpellSchool);
        }

        [Fact]
        public void ParseLine_SpellCreate_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:51.621-6  SPELL_CREATE,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,GameObject-0-4392-1009-10294-181621-00001E8733,""Soulwell"",0x4228,0x80000000,29893,""Create Soulwell"",0x20";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_CREATE, evt.EventType);

            var sc = Assert.IsType<SpellCreate>(evt.EventData);
            Assert.Equal("Player-4385-05E55B5C", sc.SourceGUID);
            Assert.Equal("Jiglyball-Immerseus-US", sc.SourceName);
            Assert.Equal(0x514, sc.SourceFlags);
            Assert.Equal("GameObject-0-4392-1009-10294-181621-00001E8733", sc.DestGUID);
            Assert.Equal("Soulwell", sc.DestName);
            Assert.Equal(0x4228, sc.DestFlags);
            Assert.Equal(29893, sc.SpellId);
            Assert.Equal("Create Soulwell", sc.SpellName);
            Assert.Equal(0x20, sc.SpellSchool);
        }

        [Fact]
        public void ParseLine_SpellDamage_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.104-6  SPELL_DAMAGE,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Creature-0-4392-1009-10294-64339-00001E83B5,""Instructor Tak'thok"",0xa48,0x80000000,17877,""Shadowburn"",0x20,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,256322,244116,-1,32,0,0,0,nil,nil,nil,ST";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_DAMAGE, evt.EventType);

            var sd = Assert.IsType<SpellDamage>(evt.EventData);
            Assert.Equal("Player-4385-05E55B5C", sd.SourceGUID);
            Assert.Equal("Jiglyball-Immerseus-US", sd.SourceName);
            Assert.Equal(0x514, sd.SourceFlags);
            Assert.Equal(0x80000000, sd.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1009-10294-64339-00001E83B5", sd.DestGUID);
            Assert.Equal("Instructor Tak'thok", sd.DestName);
            Assert.Equal(0xa48, sd.DestFlags);
            Assert.Equal(0x80000000, sd.DestRaidFlags);
            Assert.Equal(17877, sd.SpellId);
            Assert.Equal("Shadowburn", sd.SpellName);
            Assert.Equal(0x20, sd.SpellSchool);
            Assert.Equal(256322, sd.Amount);
            Assert.Equal(244116, sd.Overkill);
        }

        [Fact]
        public void ParseLine_SpellDispel_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:33:05.934-6  SPELL_DISPEL,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,Creature-0-4392-1009-10294-62408-00011E8BA5,""Zar'thik Battle-Mender"",0xa48,0x80000020,32592,""Mass Dispel"",0x2,122149,""Quickening"",1,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_DISPEL, evt.EventType);

            var dispel = Assert.IsType<SpellDispel>(evt.EventData);
            Assert.Equal(32592, dispel.SpellId);
            Assert.Equal("Mass Dispel", dispel.SpellName);
            Assert.Equal(0x2, dispel.SpellSchool);
            Assert.Equal(122149, dispel.DispelledSpellId);
            Assert.Equal("Quickening", dispel.DispelledSpellName);
            Assert.Equal(1, dispel.DispelledSpellSchool);
            Assert.Equal("BUFF", dispel.DispelledType);
        }

        [Fact]
        public void ParseLine_SpellEnergize_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.128-6  SPELL_ENERGIZE,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,47755,""Rapture"",0x2,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,13725.0000,0.0000,0,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_ENERGIZE, evt.EventType);

            var e = Assert.IsType<SpellEnergize>(evt.EventData);
            Assert.Equal(47755, e.SpellId);
            Assert.Equal("Rapture", e.SpellName);
            Assert.Equal(0x2, e.SpellSchool);
            Assert.Equal(13725, e.Amount);
        }

        [Fact]
        public void ParseLine_SpellHeal_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.121-6  SPELL_HEAL,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,47750,""Penance"",0x2,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,72543,72543,72543,0,nil";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_HEAL, evt.EventType);

            var heal = Assert.IsType<SpellHeal>(evt.EventData);
            Assert.Equal(47750, heal.SpellId);
            Assert.Equal("Penance", heal.SpellName);
            Assert.Equal(0x2, heal.SpellSchool);
            Assert.Equal(72543, heal.Amount);
            Assert.Equal(72543, heal.OverHeal);
        }

        [Fact]
        public void ParseLine_SpellHealAbsorbed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:53:45.623-6  SPELL_HEAL_ABSORBED,Vehicle-0-4392-1009-10294-62847-00001E90C9,""Dissonance Field"",0xa48,0x80000000,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,123184,""Dissonance Field"",0x1,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,127802,""Touch of the Grave"",0x20,13712,13712";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_HEAL_ABSORBED, evt.EventType);

            var ha = Assert.IsType<SpellHealAbsorbed>(evt.EventData);
            Assert.Equal(123184, ha.SpellId);
            Assert.Equal("Dissonance Field", ha.SpellName);
            Assert.Equal(0x1, ha.SpellSchool);
            Assert.Equal(127802, ha.HealSpellId);
            Assert.Equal("Touch of the Grave", ha.HealSpellName);
            Assert.Equal(0x20, ha.HealSpellSchool);
            Assert.Equal(13712, ha.Amount);
        }

        [Fact]
        public void ParseLine_SpellInstakill_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:25:22.050-6  SPELL_INSTAKILL,Player-4385-05E55B5C,""Jiglyball-Immerseus-US"",0x514,0x80000000,Pet-0-4392-1009-10294-416-0100C3170C,""Abatuk"",0x1114,0x80000000,108503,""Grimoire of Sacrifice"",0x20,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_INSTAKILL, evt.EventType);

            var ik = Assert.IsType<SpellInstakill>(evt.EventData);
            Assert.Equal(108503, ik.SpellId);
            Assert.Equal("Grimoire of Sacrifice", ik.SpellName);
            Assert.Equal(0x20, ik.SpellSchool);
        }

        [Fact]
        public void ParseLine_SpellInterrupt_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:19:35.755-6  SPELL_INTERRUPT,Player-4385-05E52D32,""Craigxecute-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-63592-00009E83B5,""Set'thik Gustwing"",0xa48,0x80000000,102060,""Disrupting Shout"",0x1,124072,""Gust"",8";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_INTERRUPT, evt.EventType);

            var interrupt = Assert.IsType<SpellInterrupt>(evt.EventData);
            Assert.Equal(102060, interrupt.SpellId);
            Assert.Equal("Disrupting Shout", interrupt.SpellName);
            Assert.Equal(0x1, interrupt.SpellSchool);
            Assert.Equal(124072, interrupt.InterruptedSpellId);
            Assert.Equal("Gust", interrupt.InterruptedSpellName);
            Assert.Equal(8, interrupt.InterruptedSpellSchool);
        }

        [Fact]
        public void ParseLine_SpellMissed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:19.850-6  SPELL_MISSED,Player-4385-05E52D32,""Craigxecute-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-62543-00001E83B5,""Blade Lord Ta'yak"",0x10a48,0x80000000,7922,""Charge Stun"",0x1,IMMUNE,nil,ST";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_MISSED, evt.EventType);

            var sm = Assert.IsType<SpellMissed>(evt.EventData);
            Assert.Equal(7922, sm.SpellId);
            Assert.Equal("Charge Stun", sm.SpellName);
            Assert.Equal(0x1, sm.SpellSchool);
            Assert.Equal("IMMUNE", sm.MissType);
        }

        [Fact]
        public void ParseLine_SpellPeriodicDamage_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.077-6  SPELL_PERIODIC_DAMAGE,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000000,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000000,124255,""Stagger"",0x1,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,31279,31279,-1,1,0,0,0,nil,nil,nil,ST";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_PERIODIC_DAMAGE, evt.EventType);

            var pd = Assert.IsType<SpellPeriodicDamage>(evt.EventData);
            Assert.Equal(124255, pd.SpellId);
            Assert.Equal("Stagger", pd.SpellName);
            Assert.Equal(0x1, pd.SpellSchool);
            Assert.Equal(31279, pd.Amount);
            Assert.Equal(31279, pd.Overkill);
        }

        [Fact]
        public void ParseLine_SpellPeriodicEnergize_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:22.613-6  SPELL_PERIODIC_ENERGIZE,Player-4385-05E55270,""Snippss-Immerseus-US"",0x512,0x80000000,Player-4385-05E55270,""Snippss-Immerseus-US"",0x512,0x80000000,82726,""Fervor"",0x1,Player-4385-05E55270,0000000000000000,100,100,82501,181,25412,0,0,2,8,100,0,-2103.18,300.95,474,4.5173,508,5.0000,0.0000,2,100";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_PERIODIC_ENERGIZE, evt.EventType);

            var pe = Assert.IsType<SpellPeriodicEnergize>(evt.EventData);
            Assert.Equal(82726, pe.SpellId);
            Assert.Equal("Fervor", pe.SpellName);
            Assert.Equal(0x1, pe.SpellSchool);
            Assert.Equal(2, pe.School);
            Assert.Equal(5, pe.Amount);
        }

        [Fact]
        public void ParseLine_SpellPeriodicHeal_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.127-6  SPELL_PERIODIC_HEAL,Player-4385-05E5E88C,""Kalleth-Immerseus-US"",0x514,0x80000000,Player-4385-05E6580C,""Heathedger-Immerseus-US"",0x512,0x80000000,51945,""Earthliving"",0x8,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,13040,13040,13040,0,1";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_PERIODIC_HEAL, evt.EventType);

            var ph = Assert.IsType<SpellPeriodicHeal>(evt.EventData);
            Assert.Equal(51945, ph.SpellId);
            Assert.Equal("Earthliving", ph.SpellName);
            Assert.Equal(0x8, ph.SpellSchool);
            Assert.Equal(13040, ph.Amount);
            Assert.Equal(13040, ph.OverHeal);
            Assert.False(ph.Critical);
        }

        [Fact]
        public void ParseLine_SpellPeriodicMissed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:14:23.054-6  SPELL_PERIODIC_MISSED,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000040,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000040,124255,""Stagger"",0x1,ABSORB,nil,6120,6120,ST";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_PERIODIC_MISSED, evt.EventType);

            var pm = Assert.IsType<SpellPeriodicMissed>(evt.EventData);
            Assert.Equal(124255, pm.SpellId);
            Assert.Equal("Stagger", pm.SpellName);
            Assert.Equal(0x1, pm.SpellSchool);
            Assert.Equal("ABSORB", pm.MissType);
            Assert.Equal(6120, pm.amountFullTick);
        }

        [Fact]
        public void ParseLine_SpellResurrect_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:51.261-6  SPELL_RESURRECT,Player-4385-05E54138,""Nepriesto-Immerseus-US"",0x514,0x80000000,Player-4385-05E52D32,""Craigxecute-Immerseus-US"",0x512,0x80000000,83968,""Mass Resurrection"",0x2";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_RESURRECT, evt.EventType);

            var sr = Assert.IsType<SpellResurrect>(evt.EventData);
            Assert.Equal(83968, sr.SpellId);
            Assert.Equal("Mass Resurrection", sr.SpellName);
            Assert.Equal(0x2, sr.SpellSchool);
        }

        [Fact]
        public void ParseLine_SpellStolen_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:29:47.667-6  SPELL_STOLEN,Player-4385-05E54EFC,""Hsojie-Immerseus-US"",0x514,0x80000040,Creature-0-4392-1008-12040-60402-00001E9917,""Zandalari Fire-Dancer"",0xa48,0x80000000,30449,""Spellsteal"",0x40,116592,""Blazing Speed"",4,BUFF";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_STOLEN, evt.EventType);

            var ss = Assert.IsType<SpellStolen>(evt.EventData);
            Assert.Equal(30449, ss.SpellId);
            Assert.Equal("Spellsteal", ss.SpellName);
            Assert.Equal(0x40, ss.SpellSchool);
            Assert.Equal(116592, ss.StolenSpellId);
            Assert.Equal("Blazing Speed", ss.StolenSpellName);
            Assert.Equal(4, ss.StolenSpellSchool);
            Assert.Equal("BUFF", ss.StolenType);
        }

        [Fact]
        public void ParseLine_SpellSummon_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:13:05.841-6  SPELL_SUMMON,Player-4385-05E55270,""Snippss-Immerseus-US"",0x512,0x80000000,Pet-0-4392-1009-10294-22052-0600C30EAD,""UpKeep"",0x1228,0x80000000,83245,""Call Pet 5"",0x1";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SPELL_SUMMON, evt.EventType);

            var sum = Assert.IsType<SpellSummon>(evt.EventData);
            Assert.Equal(83245, sum.SpellId);
            Assert.Equal("Call Pet 5", sum.SpellName);
            Assert.Equal(0x1, sum.SpellSchool);
        }

        [Fact]
        public void ParseLine_SwingDamage_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.151-6  SWING_DAMAGE,Player-4385-05E6580C,""Heathedger-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-64338-00001E83B5,""Instructor Kli'thak"",0xa48,0x80000000,0000000000000000,0000000000000000,0,0,0,0,0,0,0,-1,0,0,0,0.00,0.00,475,0.0000,0,12288,8946,-1,1,0,0,0,1,nil,nil";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SWING_DAMAGE, evt.EventType);

            var sd = Assert.IsType<SwingDamage>(evt.EventData);
            Assert.Equal("Player-4385-05E6580C", sd.SourceGUID);
            Assert.Equal("Heathedger-Immerseus-US", sd.SourceName);
            Assert.Equal(0x512, sd.SourceFlags);
            Assert.Equal(0x80000000, sd.SourceRaidFlags);
            Assert.Equal("Creature-0-4392-1009-10294-64338-00001E83B5", sd.DestGUID);
            Assert.Equal("Instructor Kli'thak", sd.DestName);
            Assert.Equal(0xa48, sd.DestFlags);
            Assert.Equal(0x80000000, sd.DestRaidFlags);
            Assert.Equal(12288, sd.Amount);
            Assert.Equal(8946, sd.Overkill);
        }

        [Fact]
        public void ParseLine_SwingDamageLanded_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.152-6  SWING_DAMAGE_LANDED,Player-4385-05E6580C,""Heathedger-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-64338-00001E83B5,""Instructor Kli'thak"",0xa48,0x80000000,12288,8946,-1,1,0,0,0,1,nil,nil";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SWING_DAMAGE_LANDED, evt.EventType);

            var sdl = Assert.IsType<SwingDamageLanded>(evt.EventData);
            Assert.Equal("Player-4385-05E6580C", sdl.SourceGUID);
            Assert.Equal("Instructor Kli'thak", sdl.DestName);
        }

        [Fact]
        public void ParseLine_SwingMissed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.150-6  SWING_MISSED,Player-4385-05E6580C,""Heathedger-Immerseus-US"",0x512,0x80000000,Creature-0-4392-1009-10294-64338-00001E83B5,""Instructor Kli'thak"",0xa48,0x80000000,MISS,nil";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.SWING_MISSED, evt.EventType);

            var sm = Assert.IsType<SwingMissed>(evt.EventData);
            Assert.Equal("MISS", sm.MissType);
        }

        [Fact]
        public void ParseLine_UnitDestroyed_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:36.049-6  UNIT_DESTROYED,0000000000000000,nil,0x80000000,0x80000000,Creature-0-4392-1009-10294-3527-00001E8713,""Healing Stream Totem"",0x2114,0x80000000,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.UNIT_DESTROYED, evt.EventType);

            var ud = Assert.IsType<UnitDestroyed>(evt.EventData);
            Assert.Equal("0000000000000000", ud.SourceGUID);
            Assert.Null(ud.SourceName);
            Assert.Equal(0x80000000, ud.SourceFlags);
            Assert.Equal("Creature-0-4392-1009-10294-3527-00001E8713", ud.DestGUID);
            Assert.Equal("Healing Stream Totem", ud.DestName);
            Assert.Equal(0x2114, ud.DestFlags);
        }

        [Fact]
        public void ParseLine_UnitDied_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:34.122-6  UNIT_DIED,0000000000000000,nil,0x80000000,0x80000000,Player-4385-05E60F02,""Holygran-Immerseus-US"",0x40512,0x80000000,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.UNIT_DIED, evt.EventType);

            var ud = Assert.IsType<UnitDied>(evt.EventData);
            Assert.Equal("Player-4385-05E60F02", ud.DestGUID);
            Assert.Equal("Holygran-Immerseus-US", ud.DestName);
            Assert.Equal(0x40512, ud.DestFlags);
        }

        [Fact]
        public void ParseLine_WorldMarkerPlaced_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:14:11.867-6  WORLD_MARKER_PLACED,1008,1,3923.48,1251.55";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.WORLD_MARKER_PLACED, evt.EventType);

            var wm = Assert.IsType<WorldMarkerPlaced>(evt.EventData);
            Assert.Equal(1008, wm.MapId);
            Assert.Equal(1, wm.MarkerId);
            Assert.Equal(3923.48, wm.X, 2);
            Assert.Equal(1251.55, wm.Y, 2);
        }

        [Fact]
        public void ParseLine_WorldMarkerRemoved_ParsesCorrectly()
        {
            var line = @"11/19/2025 22:53:12.121-6  WORLD_MARKER_REMOVED,0";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.WORLD_MARKER_REMOVED, evt.EventType);

            var wr = Assert.IsType<WorldMarkerRemoved>(evt.EventData);
            Assert.Equal(0, wr.MarkerId);
        }

        [Fact]
        public void ParseLine_ZoneChange_ParsesCorrectly()
        {
            var line = @"11/19/2025 21:12:32.893-6  ZONE_CHANGE,1009,""UNKNOWN AREA"",5";
            var evt = CombatLogService.ParseLine(line);

            Assert.NotNull(evt);
            Assert.Equal(CombatSubEventType.ZONE_CHANGE, evt.EventType);

            var zc = Assert.IsType<ZoneChange>(evt.EventData);
            Assert.Equal(1009, zc.InstanceId);
            Assert.Equal("UNKNOWN AREA", zc.ZoneName);
            Assert.Equal(5, zc.DifficultyId);
        }
    }
}