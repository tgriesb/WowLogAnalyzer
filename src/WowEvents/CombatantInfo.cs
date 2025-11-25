using WowLogAnalyzer.Attributes;
using WowLogAnalyzer.Enums;

namespace WowLogAnalyzer.WowEvents;

public class CombatantInfo : ICombatEvent
{
    public CombatSubEventType EventType => CombatSubEventType.COMBATANT_INFO;
    //COMBATANT_INFO,playerGUID,Strength,Agility,Stamina,Intelligence,Dodge,Parry,Block,CritMelee,CritRanged,CritSpell,Speed,Lifesteal,HasteMelee,HasteRanged,HasteSpell,Avoidance,Mastery,VersatilityDamageDone,VersatilityHealingDone,VersatilityDamageTaken,Armor,CurrentSpecID,(Class Talent 1, ...),(PvP Talent 1, ...),[Artifact Trait ID 1, Trait Effective Level 1, ...],[(Equipped Item ID 1,Equipped Item iLvL 1,(Permanent Enchant ID, Temp Enchant ID, On Use Spell Enchant ID),(Bonus List ID 1, ...),(Gem ID 1, Gem iLvL 1, ...)) ...],[Interesting Aura Caster GUID 1, Interesting Aura Spell ID 1, ...]
    // COMBATANT_INFO,Player-4385-05E5E88C,0,233,172,23296,23008,8971,0,0,0,5741,5741,5741,3529,3529,3529,0,0,0,0,0,0,25560,1,(,2,2,0,1,2,1,-1),(),[(85351,504,(),(),(76885,90,76686,90)),(86976,517,(),(),()),(87133,517,(4806,0,0),(),(76686,90)),(0,0,(),(),()),(85353,504,(4419,0,0),(),(76668,90,76668,90)),(87030,510,(0,0,4223),(),(76668,90,76686,90,76694,90)),(87042,510,(4826,0,0),(),(76694,90,76686,90)),(87154,517,(4429,0,0),(),(76668,90)),(86962,517,(4414,0,0),(),()),(87130,517,(4430,0,4898),(),()),(87151,517,(),(),()),(86982,517,(),(),()),(87163,517,(),(),()),(79330,484,(),(),()),(87018,510,(4423,0,4897),(),()),(87170,517,(4442,3345,0),(),(89882,513,76694,90)),(0,0,(),(),()),(0,0,(),(),())],[Player-4385-05E5E88C,105691,1,Player-4385-05E5E88C,77747,1,Player-4385-05E5E88C,116956,1,Player-4385-05E54EFC,61316,1,Player-4385-05E6580C,113742,1,Player-4385-05E55270,19506,1,Player-4385-05E55B5C,109773,1,Player-4385-05E5E88C,104276,1,Player-4385-05E5ECE1,49868,1,Player-4385-05E52D32,6673,1,Player-4385-05E528FE,19740,1],0,0,(470,223,1092,226,471,222)
    [LogField(1)] public string PlayerGUID { get; set; } = "";
    [LogField(2)] public int Strength { get; set; }
    [LogField(3)] public int Agility { get; set; }
    [LogField(4)] public int Stamina { get; set; }
    [LogField(5)] public int Intelligence { get; set; }
    [LogField(6)] public int Dodge { get; set; }
    [LogField(7)] public int Parry { get; set; }
    [LogField(8)] public int Block { get; set; }
    [LogField(9)] public int CritMelee { get; set; }
    [LogField(10)] public int CritRanged { get; set; }
    [LogField(11)] public int CritSpell { get; set; }
    [LogField(12)] public int Speed { get; set; }
    [LogField(13)] public int Lifesteal { get; set; }
    [LogField(14)] public int HasteMelee { get; set; }
    [LogField(15)] public int HasteRanged { get; set; }
    [LogField(16)] public int HasteSpell { get; set; }
    [LogField(17)] public int Avoidance { get; set; }
    [LogField(18)] public int Mastery { get; set; }
    [LogField(19)] public int VersatilityDamageDone { get; set; }
    [LogField(20)] public int VersatilityHealingDone { get; set; }
    [LogField(21)] public int VersatilityDamageTaken { get; set; }
    [LogField(22)] public int Armor { get; set; }

    //TODO Add the rest of the fields

}