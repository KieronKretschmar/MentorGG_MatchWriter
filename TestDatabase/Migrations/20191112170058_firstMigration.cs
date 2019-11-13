using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDatabase.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DemoId = table.Column<long>(nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Map = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    WinnerTeam = table.Column<byte>(nullable: false),
                    Score1 = table.Column<short>(nullable: false),
                    Score2 = table.Column<short>(nullable: false),
                    NumRoundsT1 = table.Column<short>(nullable: false),
                    NumRoundsCT1 = table.Column<short>(nullable: false),
                    NumRoundsT2 = table.Column<short>(nullable: false),
                    NumRoundsCT2 = table.Column<short>(nullable: false),
                    BombPlants1 = table.Column<short>(nullable: false),
                    BombPlants2 = table.Column<short>(nullable: false),
                    BombExplodes1 = table.Column<short>(nullable: false),
                    BombExplodes2 = table.Column<short>(nullable: false),
                    BombDefuses1 = table.Column<short>(nullable: false),
                    BombDefuses2 = table.Column<short>(nullable: false),
                    MoneyEarned1 = table.Column<int>(nullable: false),
                    MoneyEarned2 = table.Column<int>(nullable: false),
                    MoneySpent1 = table.Column<int>(nullable: false),
                    MoneySpent2 = table.Column<int>(nullable: false),
                    AVGRoundTime = table.Column<int>(nullable: true),
                    RoundTimer = table.Column<int>(nullable: false),
                    BombTimer = table.Column<int>(nullable: false),
                    StartMoney = table.Column<int>(nullable: false),
                    DemoTickRate = table.Column<short>(nullable: false),
                    SourceTickRate = table.Column<short>(nullable: false),
                    Source = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    GameType = table.Column<byte>(nullable: false),
                    AVGRank = table.Column<double>(nullable: true),
                    RealScore1 = table.Column<short>(nullable: false),
                    RealScore2 = table.Column<short>(nullable: false),
                    Event = table.Column<string>(nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStats", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "BombDefused",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    BombTimeLeft = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombDefused", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_BombDefused_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombDefused_MatchStats",
                table: "BombDefused",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombDefused_PlayerMatchStats",
                table: "BombDefused",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombDefused_RoundStats",
                table: "BombDefused",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombDefused_PlayerRoundStats",
                table: "BombDefused",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_MatchStats_DemoStats",
                table: "MatchStats",
                column: "DemoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BombDefused");

            migrationBuilder.DropTable(
                name: "MatchStats");
        }
    }
}
