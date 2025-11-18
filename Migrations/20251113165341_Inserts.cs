using Microsoft.EntityFrameworkCore.Migrations;
using WowLogAnalyzer.Enums;

#nullable disable

namespace WowLogAnalyzer.Migrations
{
    /// <inheritdoc />
    public partial class Inserts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 // Death Knight
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.BLOOD, "Blood", "Death Knight" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.FROST_DK, "Frost", "Death Knight" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.UNHOLY, "Unholy", "Death Knight" });

            // Druid
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.BALANCE, "Balance", "Druid" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.FERAL, "Feral", "Druid" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.GUARDIAN, "Guardian", "Druid" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, "Restoration", "Druid" });

            // Hunter
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.BEAST_MASTERY, "Beast Mastery", "Hunter" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.MARKSMANSHIP, "Marksmanship", "Hunter" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.SURVIVAL, "Survival", "Hunter" });

            // Mage
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.ARCANE, "Arcane", "Mage" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.FIRE_MAGE, "Fire", "Mage" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.FROST_MAGE, "Frost", "Mage" });

            // Monk
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.BREWMASTER, "Brewmaster", "Monk" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.WINDWALKER, "Windwalker", "Monk" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.MISTWEAVER, "Mistweaver", "Monk" });

            // Paladin
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.HOLY_PALADIN, "Holy", "Paladin" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, "Protection", "Paladin" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.RETRIBUTION, "Retribution", "Paladin" });

            // Priest
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.DISCIPLINE, "Discipline", "Priest" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.HOLY_PRIEST, "Holy", "Priest" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.SHADOW, "Shadow", "Priest" });

            // Rogue
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.ASSASSINATION, "Assassination", "Rogue" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.COMBAT, "Combat", "Rogue" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.SUBTLETY, "Subtlety", "Rogue" });

            // Shaman
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.ELEMENTAL, "Elemental", "Shaman" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.ENHANCEMENT, "Enhancement", "Shaman" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.RESTORATION_SHAMAN, "Restoration", "Shaman" });

            // Warlock
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.AFFLICTION, "Affliction", "Warlock" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.DEMONOLOGY, "Demonology", "Warlock" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.DESTRUCTION, "Destruction", "Warlock" });

            // Warrior
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.ARMS, "Arms", "Warrior" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.FURY, "Fury", "Warrior" });
            migrationBuilder.InsertData("specs", new[] { "id", "name", "class" }, new object[] { (int)ClassSpec.PROTECTION_WARRIOR, "Protection", "Warrior" });


            // === DEATH KNIGHT - BLOOD ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49542, "Blood Parasite" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 49542 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50034, "Blood Rites" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 50034 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49222, "Bone Shield" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 49222 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81136, "Crimson Scourge" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 81136 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49028, "Dancing Rune Weapon" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 49028 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 56222, "Dark Command" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 56222 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 55050, "Heart Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 55050 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50371, "Improved Blood Presence" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 50371 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77513, "Mastery Blood Shield" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 77513 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 56815, "Rune Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 56815 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48982, "Rune Tap" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 48982 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81127, "Sanguine Fortitude" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 81127 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81132, "Scarlet Fever" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 81132 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 55233, "Vampiric Blood" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 55233 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50029, "Veteran Of The Third War" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 50029 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81164, "Will Of The Necropolis" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BLOOD, 81164 });


            // === DEATH KNIGHT - FROST ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 54637, "Blood Of The North" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 54637 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81328, "Brittle Bones" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 81328 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49143, "Frost Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 49143 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49184, "Howling Blast" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 49184 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50887, "Icy Talons" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 50887 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50385, "Improved Frost Presence" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 50385 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 51128, "Killing Machine" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 51128 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77514, "Mastery Frozen Heart" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 77514 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81333, "Might Of The Frozen Wastes" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 81333 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49020, "Obliterate" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 49020 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 51271, "Pillar Of Frost" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 51271 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 59057, "Rime" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 59057 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 66192, "Threat Of Thassarian" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 66192 });

            // === DEATH KNIGHT - FROST / UNHOLY SHARED ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 55610, "Unholy Aura" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_DK, 55610 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 55610 });

            // === DEATH KNIGHT - UNHOLY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 63560, "Dark Transformation" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 63560 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 51160, "Ebon Plaguebringer" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 51160 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 85948, "Festering Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 85948 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50392, "Improved Unholy Presence" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 50392 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 52143, "Master Of Ghouls" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 52143 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77515, "Mastery Dreadblade" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 77515 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 56835, "Reaping" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 56835 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 55090, "Scourge Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 55090 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49572, "Shadow Infusion" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 49572 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49530, "Sudden Doom" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 49530 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49206, "Summon Gargoyle" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 49206 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 49016, "Unholy Frenzy" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 49016 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 91107, "Unholy Might" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.UNHOLY, 91107 });


            // === DRUID - BALANCE ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 127663, "Astral Communion" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 127663 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 106732, "Balance Overrides Passive" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 106732 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 33596, "Balance Of Power" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 33596 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 112071, "Celestial Alignment" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 112071 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 84738, "Celestial Focus" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 84738 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 79577, "Eclipse" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 79577 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81062, "Euphoria" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 81062 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 33605, "Lunar Shower" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 33605 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77492, "Mastery Total Eclipse" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 77492 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 24858, "Moonkin Form" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 24858 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48393, "Owlkin Frenzy" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 48393 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 93399, "Shooting Stars" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 93399 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 78675, "Solar Beam" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 78675 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48505, "Starfall" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 48505 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 2912, "Starfire" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 2912 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 78674, "Starsurge" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 78674 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 93402, "Sunfire" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 93402 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 88751, "Wild Mushroom Detonate" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 88751 });

            // === DRUID - BALANCE / FERAL / GUARDIAN ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 2782, "Remove Corruption" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 2782 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 2782 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 2782 });

            // === DRUID - BALANCE / FERAL / RESTORATION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 132158, "Nature's Swiftness" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 132158 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 132158 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 132158 });

            // === DRUID - BALANCE / RESTORATION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 108299, "Killer Instinct" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 108299 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 108299 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 112857, "Natural Insight" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BALANCE, 112857 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 112857 });

            // === DRUID - FERAL ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 16949, "Feral Instinct" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 16949 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 106733, "Feral Overrides Passive" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 106733 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77493, "Mastery Razor Claws" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 77493 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 16974, "Predatory Swiftness" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 16974 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 52610, "Savage Roar" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 52610 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 5221, "Shred" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 5221 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 5217, "Tiger's Fury" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 5217 });

            // === DRUID - FERAL / GUARDIAN ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 106952, "Berserk" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FERAL, 106952 });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 106952 });

            // === DRUID - GUARDIAN ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 102795, "Bear Hug" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 102795 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 5229, "Enrage" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 5229 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 106734, "Guardian Overrides Passive" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 106734 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77494, "Mastery Nature's Guardian" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 77494 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 62606, "Savage Defense" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 62606 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 16931, "Thick Hide" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 16931 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 135288, "Tooth And Claw" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.GUARDIAN, 135288 });

            // === DRUID - RESTORATION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 145518, "Genesis" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 145518 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 102342, "Ironbark" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 102342 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 33763, "Lifebloom" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 33763 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48500, "Living Seed" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 48500 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 92364, "Malfurion's Gift" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 92364 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77495, "Mastery Harmony" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 77495 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 17073, "Naturalist" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 17073 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 88423, "Nature's Cure" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 88423 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 84736, "Nature's Focus" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 84736 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 50464, "Nourish" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 50464 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 8936, "Regrowth" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 8936 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 106735, "Restoration Overrides Passive" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 106735 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 33886, "Swift Rejuvenation" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 33886 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 18562, "Swiftmend" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 18562 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48438, "Wild Growth" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 48438 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 102791, "Wild Mushroom Bloom" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_DRUID, 102791 });

            // === HUNTER - BEAST MASTERY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 115939, "Beast Cleave" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 115939 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 19574, "Bestial Wrath" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 19574 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53260, "Cobra Strikes" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 53260 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53270, "Exotic Beasts" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 53270 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 82692, "Focus Fire" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 82692 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 19623, "Frenzy" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 19623 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34954, "Go For The Throat" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 34954 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53253, "Invigoration" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 53253 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34026, "Kill Command" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 34026 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 56315, "Kindred Spirits" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 56315 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76657, "Mastery Master Of Beasts" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 76657 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34692, "The Beast Within" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BEAST_MASTERY, 34692 });

            // === HUNTER - MARKSMANSHIP ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 19434, "Aimed Shot" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 19434 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 35110, "Bombardment" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 35110 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34483, "Careful Aim" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 34483 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53209, "Chimera Shot" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 53209 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 35102, "Concussive Barrage" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 35102 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34487, "Master Marksman" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 34487 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76659, "Mastery Wild Quiver" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 76659 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53238, "Piercing Shots" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 53238 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53232, "Rapid Recuperation" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 53232 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34490, "Silencing Shot" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 34490 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53224, "Steady Focus" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.MARKSMANSHIP, 53224 });

            // === HUNTER - SURVIVAL ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 19387, "Entrapment" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 19387 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53301, "Explosive Shot" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 53301 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 82834, "Improved Serpent Sting" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 82834 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 56343, "Lock And Load" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 56343 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76658, "Mastery Essence Of The Viper" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 76658 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 87935, "Serpent Spread" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 87935 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 63458, "Trap Mastery" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 63458 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 118976, "Viper Venom" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SURVIVAL, 118976 });

            // === MAGE - ARCANE ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 44425, "Arcane Barrage" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 44425 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 30451, "Arcane Blast" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 30451 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 114664, "Arcane Charge" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 114664 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 12042, "Arcane Power" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 12042 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76547, "Mastery Mana Adept" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 76547 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31589, "Slow" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARCANE, 31589 });

            // === MAGE - FIRE ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 11129, "Combustion" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 11129 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 117216, "Critical Mass" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 117216 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31661, "Dragon's Breath" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 31661 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 133, "Fireball" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 133 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 108853, "Inferno Blast" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 108853 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 12846, "Mastery Ignite" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FIRE_MAGE, 12846 });

            // === MAGE - FROST ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 44549, "Brain Freeze" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 44549 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 112965, "Fingers Of Frost" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 112965 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 116, "Frostbolt" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 116 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 84714, "Frozen Orb" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 84714 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 12472, "Icy Veins" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 12472 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76613, "Mastery Icicles" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FROST_MAGE, 76613 });

            // === MONK - BREWMASTER ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 115213, "Avert Harm" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 115213 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 115181, "Breath Of Fire" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 115181 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 128938, "Brewing Elusive Brew" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 128938 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 117967, "Brewmaster Training" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 117967 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 115308, "Elusive Brew" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 115308 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 117906, "Mastery Elusive Brawler" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.BREWMASTER, 117906 });

            // === PALADIN - HOLY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53563, "Beacon Of Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 53563 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 88821, "Daybreak" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 88821 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 2812, "Denounce" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 2812 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31842, "Divine Favor" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 31842 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 82326, "Divine Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 82326 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 54428, "Divine Plea" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 54428 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 112859, "Holy Insight" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 112859 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 635, "Holy Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 635 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 82327, "Holy Radiance" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 82327 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 20473, "Holy Shock" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 20473 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53576, "Infusion Of Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 53576 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 85222, "Light Of Dawn" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 85222 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76669, "Mastery Illuminated Healing" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PALADIN, 76669 });

            // === PALADIN - PROTECTION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31850, "Ardent Defender" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 31850 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31935, "Avenger's Shield" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 31935 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 26573, "Consecration" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 26573 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 85043, "Grand Crusader" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 85043 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53592, "Guarded By The Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 53592 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 119072, "Holy Wrath" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 119072 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76671, "Mastery Divine Bulwark" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_PALADIN, 76671 });

            // === PALADIN - RETRIBUTION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 879, "Exorcism" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RETRIBUTION, 879 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 84963, "Inquisition" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RETRIBUTION, 84963 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76672, "Mastery Hand Of Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RETRIBUTION, 76672 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 85256, "Templar's Verdict" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RETRIBUTION, 85256 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 87138, "The Art Of War" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RETRIBUTION, 87138 });

            // === PRIEST - DISCIPLINE ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81700, "Archangel" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DISCIPLINE, 81700 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 47515, "Divine Aegis" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DISCIPLINE, 47515 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77484, "Mastery Shield Discipline" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DISCIPLINE, 77484 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 47540, "Penance" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DISCIPLINE, 47540 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 62618, "Power Word Barrier" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DISCIPLINE, 62618 });

            // === PRIEST - HOLY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 81206, "Chakra Sanctuary" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PRIEST, 81206 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 64843, "Divine Hymn" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PRIEST, 64843 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77485, "Mastery Echo Of Light" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PRIEST, 77485 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 34861, "Circle Of Healing" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PRIEST, 34861 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 20711, "Spirit Of Redemption" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.HOLY_PRIEST, 20711 });

            // === PRIEST - SHADOW ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 47585, "Dispersion" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SHADOW, 47585 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77486, "Mastery Shadowy Recall" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SHADOW, 77486 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 8092, "Mind Blast" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SHADOW, 8092 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 73510, "Mind Spike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SHADOW, 73510 });

            // === ROGUE - ASSASSINATION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 79140, "Vendetta" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ASSASSINATION, 79140 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76803, "Mastery Potent Poisons" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ASSASSINATION, 76803 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 32645, "Envenom" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ASSASSINATION, 32645 });

            // === ROGUE - COMBAT ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 13750, "Adrenaline Rush" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.COMBAT, 13750 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 13877, "Blade Flurry" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.COMBAT, 13877 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76806, "Mastery Main Gauche" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.COMBAT, 76806 });

            // === ROGUE - SUBTLETY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 53, "Backstab" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SUBTLETY, 53 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 31223, "Master Of Subtlety" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SUBTLETY, 31223 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76808, "Mastery Executioner" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.SUBTLETY, 76808 });

            // === SHAMAN - ELEMENTAL ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 61882, "Earthquake" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ELEMENTAL, 61882 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 16164, "Elemental Focus" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ELEMENTAL, 16164 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 60188, "Elemental Fury" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ELEMENTAL, 60188 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 88766, "Fulmination" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ELEMENTAL, 88766 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77222, "Mastery Elemental Overload" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ELEMENTAL, 77222 });

            // === SHAMAN - ENHANCEMENT ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 51533, "Feral Spirit" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ENHANCEMENT, 51533 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 60103, "Lava Lash" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ENHANCEMENT, 60103 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77223, "Mastery Enhanced Elements" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ENHANCEMENT, 77223 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 51530, "Maelstrom Weapon" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ENHANCEMENT, 51530 });

            // === SHAMAN - RESTORATION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 974, "Earth Shield" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_SHAMAN, 974 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77472, "Greater Healing Wave" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_SHAMAN, 77472 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77226, "Mastery Deep Healing" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_SHAMAN, 77226 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 61295, "Riptide" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.RESTORATION_SHAMAN, 61295 });

            // === WARLOCK - AFFLICTION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 980, "Agony" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.AFFLICTION, 980 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 48181, "Haunt" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.AFFLICTION, 48181 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77215, "Mastery Potent Afflictions" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.AFFLICTION, 77215 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 86121, "Soul Swap" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.AFFLICTION, 86121 });

            // === WARLOCK - DEMONOLOGY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 103967, "Carrion Swarm" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DEMONOLOGY, 103967 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 113861, "Dark Soul Knowledge" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DEMONOLOGY, 113861 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77219, "Mastery Master Demonologist" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DEMONOLOGY, 77219 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 30146, "Summon Felguard" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DEMONOLOGY, 30146 });

            // === WARLOCK - DESTRUCTION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 116858, "Chaos Bolt" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DESTRUCTION, 116858 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 108683, "Fire And Brimstone" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DESTRUCTION, 108683 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 77220, "Mastery Emberstorm" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DESTRUCTION, 77220 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 80240, "Havoc" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.DESTRUCTION, 80240 });

            // === WARRIOR - ARMS ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 12294, "Mortal Strike" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARMS, 12294 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76838, "Mastery Strikes Of Opportunity" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARMS, 76838 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 7384, "Overpower" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.ARMS, 7384 });

            // === WARRIOR - FURY ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 23881, "Bloodthirst" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FURY, 23881 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76856, "Mastery Unshackled Fury" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FURY, 76856 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 85288, "Raging Blow" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.FURY, 85288 });

            // === WARRIOR - PROTECTION ===
            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 2565, "Shield Block" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_WARRIOR, 2565 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 76857, "Mastery Critical Block" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_WARRIOR, 76857 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 23922, "Shield Slam" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_WARRIOR, 23922 });

            migrationBuilder.InsertData("spells", new[] { "id", "name" }, new object[] { 122509, "Ultimatum" });
            migrationBuilder.InsertData("spec_unique_spells", new[] { "spec_id", "spell_id" }, new object[] { (int)ClassSpec.PROTECTION_WARRIOR, 122509 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
