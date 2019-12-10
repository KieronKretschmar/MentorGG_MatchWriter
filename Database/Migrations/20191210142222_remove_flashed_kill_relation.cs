using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class remove_flashed_kill_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flashed_Kills_MatchId_AssistedKillId",
                table: "Flashed");

            migrationBuilder.DropIndex(
                name: "IX_Flashed_MatchId_AssistedKillId",
                table: "Flashed");

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_AssistedKillId",
                table: "Flashed",
                columns: new[] { "MatchId", "AssistedKillId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flashed_MatchId_AssistedKillId",
                table: "Flashed");

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_AssistedKillId",
                table: "Flashed",
                columns: new[] { "MatchId", "AssistedKillId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flashed_Kills_MatchId_AssistedKillId",
                table: "Flashed",
                columns: new[] { "MatchId", "AssistedKillId" },
                principalTable: "Kills",
                principalColumns: new[] { "MatchId", "KillId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
