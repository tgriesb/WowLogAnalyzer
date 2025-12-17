using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowLogAnalyzer.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_encounters_logs_log_id",
                table: "encounters");

            migrationBuilder.AddForeignKey(
                name: "fk_encounters_logs_log_id",
                table: "encounters",
                column: "log_id",
                principalTable: "logs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_encounters_logs_log_id",
                table: "encounters");

            migrationBuilder.AddForeignKey(
                name: "fk_encounters_logs_log_id",
                table: "encounters",
                column: "log_id",
                principalTable: "logs",
                principalColumn: "id");
        }
    }
}
