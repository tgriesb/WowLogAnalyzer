using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowLogAnalyzer.Migrations
{
    /// <inheritdoc />
    public partial class SpecChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "spec",
                table: "character_encounters",
                newName: "spec_id");

            migrationBuilder.CreateIndex(
                name: "ix_character_encounters_spec_id",
                table: "character_encounters",
                column: "spec_id");

            migrationBuilder.AddForeignKey(
                name: "fk_character_encounters_specs_spec_id",
                table: "character_encounters",
                column: "spec_id",
                principalTable: "specs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_character_encounters_specs_spec_id",
                table: "character_encounters");

            migrationBuilder.DropIndex(
                name: "ix_character_encounters_spec_id",
                table: "character_encounters");

            migrationBuilder.RenameColumn(
                name: "spec_id",
                table: "character_encounters",
                newName: "spec");
        }
    }
}
