using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class minor_spelling_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvgroundTime",
                table: "MatchStats",
                newName: "AvgRoundTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvgRoundTime",
                table: "MatchStats",
                newName: "AvgroundTime");
        }
    }
}
