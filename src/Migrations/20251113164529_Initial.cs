using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WowLogAnalyzer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    server = table.Column<string>(type: "text", nullable: false),
                    guid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_characters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guilds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    server = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_guilds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    @class = table.Column<string>(name: "class", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spells",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_spells", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    last_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spec_unique_spells",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    spec_id = table.Column<int>(type: "integer", nullable: true),
                    spell_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_spec_unique_spells", x => x.id);
                    table.ForeignKey(
                        name: "fk_spec_unique_spells_specs_spec_id",
                        column: x => x.spec_id,
                        principalTable: "specs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    upload_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    guild_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_logs_guilds_guild_id",
                        column: x => x.guild_id,
                        principalTable: "guilds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_logs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "character_encounters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    spec = table.Column<int>(type: "integer", nullable: false),
                    character_id = table.Column<int>(type: "integer", nullable: false),
                    encounter_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_character_encounters", x => x.id);
                    table.ForeignKey(
                        name: "fk_character_encounters_characters_character_id",
                        column: x => x.character_id,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "combat_events",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    event_type = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: true),
                    amount_type = table.Column<int>(type: "integer", nullable: true),
                    to_guid = table.Column<string>(type: "text", nullable: false),
                    from_guid = table.Column<string>(type: "text", nullable: false),
                    to_character_id = table.Column<int>(type: "integer", nullable: true),
                    from_character_id = table.Column<int>(type: "integer", nullable: true),
                    event_data = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    log_id = table.Column<int>(type: "integer", nullable: false),
                    encounter_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_combat_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_combat_events_characters_from_character_id",
                        column: x => x.from_character_id,
                        principalTable: "characters",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_combat_events_characters_to_character_id",
                        column: x => x.to_character_id,
                        principalTable: "characters",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_combat_events_logs_log_id",
                        column: x => x.log_id,
                        principalTable: "logs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encounters",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    encounter_name = table.Column<string>(type: "text", nullable: false),
                    encounter_id = table.Column<int>(type: "integer", nullable: false),
                    start_combat_event_id = table.Column<int>(type: "integer", nullable: true),
                    end_combat_event_id = table.Column<int>(type: "integer", nullable: true),
                    start_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    difficulty = table.Column<int>(type: "integer", nullable: false),
                    success = table.Column<bool>(type: "boolean", nullable: false),
                    log_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounters", x => x.id);
                    table.ForeignKey(
                        name: "fk_encounters_combat_events_end_combat_event_id",
                        column: x => x.end_combat_event_id,
                        principalTable: "combat_events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_encounters_combat_events_start_combat_event_id",
                        column: x => x.start_combat_event_id,
                        principalTable: "combat_events",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_encounters_logs_log_id",
                        column: x => x.log_id,
                        principalTable: "logs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_character_encounters_character_id",
                table: "character_encounters",
                column: "character_id");

            migrationBuilder.CreateIndex(
                name: "ix_character_encounters_encounter_id",
                table: "character_encounters",
                column: "encounter_id");

            migrationBuilder.CreateIndex(
                name: "idx_combat_events_log_type_time",
                table: "combat_events",
                columns: new[] { "log_id", "event_type", "timestamp" });

            migrationBuilder.CreateIndex(
                name: "ix_combat_events_encounter_id",
                table: "combat_events",
                column: "encounter_id");

            migrationBuilder.CreateIndex(
                name: "ix_combat_events_from_character_id",
                table: "combat_events",
                column: "from_character_id");

            migrationBuilder.CreateIndex(
                name: "ix_combat_events_to_character_id",
                table: "combat_events",
                column: "to_character_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounters_end_combat_event_id",
                table: "encounters",
                column: "end_combat_event_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounters_log_id",
                table: "encounters",
                column: "log_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounters_start_combat_event_id",
                table: "encounters",
                column: "start_combat_event_id");

            migrationBuilder.CreateIndex(
                name: "ix_logs_guild_id",
                table: "logs",
                column: "guild_id");

            migrationBuilder.CreateIndex(
                name: "ix_logs_user_id",
                table: "logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_spec_unique_spells_spec_id",
                table: "spec_unique_spells",
                column: "spec_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_character_encounters_encounters_encounter_id",
                table: "character_encounters",
                column: "encounter_id",
                principalTable: "encounters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_combat_events_encounters_encounter_id",
                table: "combat_events",
                column: "encounter_id",
                principalTable: "encounters",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_combat_events_characters_from_character_id",
                table: "combat_events");

            migrationBuilder.DropForeignKey(
                name: "fk_combat_events_characters_to_character_id",
                table: "combat_events");

            migrationBuilder.DropForeignKey(
                name: "fk_combat_events_encounters_encounter_id",
                table: "combat_events");

            migrationBuilder.DropTable(
                name: "character_encounters");

            migrationBuilder.DropTable(
                name: "spec_unique_spells");

            migrationBuilder.DropTable(
                name: "spells");

            migrationBuilder.DropTable(
                name: "specs");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "encounters");

            migrationBuilder.DropTable(
                name: "combat_events");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "guilds");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
