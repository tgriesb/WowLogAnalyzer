using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowLogAnalyzer.Migrations
{
    /// <inheritdoc />
    public partial class INcommingDam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "amount_incoming",
                table: "combat_events",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "amount_incoming_type",
                table: "combat_events",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount_incoming",
                table: "combat_events");

            migrationBuilder.DropColumn(
                name: "amount_incoming_type",
                table: "combat_events");
        }
    }
}
