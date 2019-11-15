using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
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
                    MatchDate = table.Column<DateTime>(nullable: false),
                    Map = table.Column<string>(nullable: false),
                    WinnerTeam = table.Column<byte>(nullable: false),
                    Score1 = table.Column<short>(nullable: false),
                    Score2 = table.Column<short>(nullable: false),
                    NumRoundsT1 = table.Column<short>(nullable: false),
                    NumRoundsCt1 = table.Column<short>(nullable: false),
                    NumRoundsT2 = table.Column<short>(nullable: false),
                    NumRoundsCt2 = table.Column<short>(nullable: false),
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
                    AvgroundTime = table.Column<int>(nullable: true),
                    RoundTimer = table.Column<int>(nullable: false),
                    BombTimer = table.Column<int>(nullable: false),
                    StartMoney = table.Column<int>(nullable: false),
                    DemoTickRate = table.Column<short>(nullable: false),
                    SourceTickRate = table.Column<short>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    GameType = table.Column<byte>(nullable: false),
                    AvgRank = table.Column<double>(nullable: true),
                    RealScore1 = table.Column<short>(nullable: false),
                    RealScore2 = table.Column<short>(nullable: false),
                    Event = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStats", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "OverTimeStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    StartT = table.Column<byte>(nullable: false),
                    StartCt = table.Column<byte>(nullable: false),
                    StartMoney = table.Column<int>(nullable: false),
                    NumRounds = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimeStats", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_OverTimeStats_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatchStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    SteamId = table.Column<long>(nullable: false),
                    Team = table.Column<byte>(nullable: false),
                    KillCount = table.Column<short>(nullable: false),
                    AssistCount = table.Column<short>(nullable: false),
                    DeathCount = table.Column<short>(nullable: false),
                    Score = table.Column<short>(nullable: false),
                    Mvps = table.Column<short>(nullable: false),
                    Hs = table.Column<short>(nullable: false),
                    HsKills = table.Column<short>(nullable: false),
                    Shots = table.Column<short>(nullable: false),
                    Hits = table.Column<short>(nullable: false),
                    HsVictim = table.Column<short>(nullable: false),
                    HsDeaths = table.Column<short>(nullable: false),
                    Enemy2K = table.Column<short>(nullable: false),
                    Enemy3K = table.Column<short>(nullable: false),
                    Enemy4K = table.Column<short>(nullable: false),
                    Enemy5K = table.Column<short>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    DamageVictim = table.Column<int>(nullable: false),
                    BombPlants = table.Column<short>(nullable: false),
                    BombExplosions = table.Column<short>(nullable: false),
                    BombDefuses = table.Column<short>(nullable: false),
                    MoneyEarned = table.Column<int>(nullable: false),
                    MoneySpent = table.Column<int>(nullable: false),
                    MoneyLost = table.Column<int>(nullable: false),
                    DecoysUsed = table.Column<short>(nullable: false),
                    FireNadesUsed = table.Column<short>(nullable: false),
                    FireNadesDamage = table.Column<int>(nullable: false),
                    FireNadesDamageVictim = table.Column<int>(nullable: false),
                    FlashesUsed = table.Column<short>(nullable: false),
                    FlashesSucceeded = table.Column<short>(nullable: false),
                    FlashVictim = table.Column<short>(nullable: false),
                    TeamFlashed = table.Column<short>(nullable: false),
                    TeamFlashVictim = table.Column<short>(nullable: false),
                    SelfFlashed = table.Column<short>(nullable: false),
                    HesUsed = table.Column<short>(nullable: false),
                    HesDamage = table.Column<int>(nullable: false),
                    HesDamageVictim = table.Column<int>(nullable: false),
                    SmokesUsed = table.Column<short>(nullable: false),
                    FirstBloods = table.Column<short>(nullable: false),
                    FirstBloodVictim = table.Column<short>(nullable: false),
                    AvgTimeAlive = table.Column<double>(nullable: false),
                    TeamDamage = table.Column<int>(nullable: false),
                    TeamKills = table.Column<int>(nullable: false),
                    EntryKills = table.Column<int>(nullable: false),
                    EntryKillVictim = table.Column<int>(nullable: false),
                    Suicides = table.Column<short>(nullable: false),
                    BombVictim = table.Column<short>(nullable: false),
                    HltvRating1 = table.Column<double>(nullable: false),
                    HltvRating2 = table.Column<double>(nullable: false),
                    RankBeforeMatch = table.Column<byte>(nullable: false),
                    RankAfterMatch = table.Column<byte>(nullable: false),
                    RealKills = table.Column<short>(nullable: false),
                    RealDeaths = table.Column<short>(nullable: false),
                    RealAssists = table.Column<short>(nullable: false),
                    RealScore = table.Column<short>(nullable: false),
                    RealMvps = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchStats", x => new { x.MatchId, x.SteamId });
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    WinnerTeam = table.Column<byte>(nullable: false),
                    OriginalSide = table.Column<bool>(nullable: false),
                    BombPlanted = table.Column<bool>(nullable: false),
                    WinType = table.Column<byte>(nullable: true),
                    RoundTime = table.Column<int>(nullable: false),
                    StartTime = table.Column<int>(nullable: false),
                    EndTime = table.Column<int>(nullable: false),
                    RealEndTime = table.Column<int>(nullable: false),
                    StartTick = table.Column<int>(nullable: false),
                    EndTick = table.Column<int>(nullable: false),
                    RealEndTick = table.Column<int>(nullable: false),
                    TerrorStrategyId = table.Column<int>(nullable: false),
                    CtStrategyId = table.Column<int>(nullable: false),
                    CtPlayedValue = table.Column<int>(nullable: false),
                    TPlayedValue = table.Column<int>(nullable: false),
                    CtBuyStrat = table.Column<int>(nullable: false),
                    TBuyStrat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundStats", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_RoundStats_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BombExplosion",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombExplosion", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_BombExplosion_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombExplosion_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectDisconnect",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ConnectDisconnectId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Connect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectDisconnect", x => new { x.MatchId, x.ConnectDisconnectId });
                    table.ForeignKey(
                        name: "FK_ConnectDisconnect_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectDisconnect_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectDisconnect_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRoundStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayedEquipmentValue = table.Column<int>(nullable: false),
                    MoneyInitial = table.Column<int>(nullable: false),
                    MoneySaved = table.Column<int>(nullable: false),
                    MoneyEarned = table.Column<int>(nullable: false),
                    MoneySpent = table.Column<int>(nullable: false),
                    MoneyLost = table.Column<int>(nullable: false),
                    GiftedValue = table.Column<int>(nullable: false),
                    ReceivedGiftValue = table.Column<int>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    ArmorType = table.Column<short>(nullable: false),
                    PathId = table.Column<int>(nullable: false),
                    RoundStartKills = table.Column<short>(nullable: false),
                    RoundStartDeaths = table.Column<short>(nullable: false),
                    RoundStartAssists = table.Column<short>(nullable: false),
                    RoundStartScore = table.Column<short>(nullable: false),
                    RoundStartMvps = table.Column<short>(nullable: false),
                    RoundStartDamage = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundStats", x => new { x.MatchId, x.Round, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_BombDefused_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombDefused_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombDefused_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BombPlant",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Site = table.Column<byte>(nullable: false),
                    PosX = table.Column<double>(nullable: false),
                    PosY = table.Column<double>(nullable: false),
                    PosZ = table.Column<double>(nullable: false),
                    PlantZone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombPlant", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_BombPlant_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombPlant_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombPlant_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombPlant_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BotTakeOver",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    BotTakeOverId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    BotId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotTakeOver", x => new { x.MatchId, x.BotTakeOverId });
                    table.ForeignKey(
                        name: "FK_BotTakeOver_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decoy",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoy", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_Decoy_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decoy_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decoy_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decoy_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireNade",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    NadeType = table.Column<byte>(nullable: false),
                    DetonationZoneByTeam = table.Column<int>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false),
                    IsMolotov = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireNade", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_FireNade_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireNade_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireNade_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireNade_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flash",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    DetonationZoneByTeam = table.Column<int>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flash", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_Flash_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flash_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flash_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flash_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "He",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    DetonationZoneByTeam = table.Column<int>(nullable: false),
                    Trajectory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_He", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_He_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_He_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_He_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_He_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostageDrop",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PosX = table.Column<double>(nullable: false),
                    PosY = table.Column<double>(nullable: false),
                    PosZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostageDrop", x => new { x.MatchId, x.Round, x.PlayerId, x.Time });
                    table.ForeignKey(
                        name: "FK_HostageDrop_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageDrop_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageDrop_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageDrop_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostagePickUp",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PosX = table.Column<double>(nullable: false),
                    PosY = table.Column<double>(nullable: false),
                    PosZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostagePickUp", x => new { x.MatchId, x.Round, x.PlayerId, x.Time });
                    table.ForeignKey(
                        name: "FK_HostagePickUp_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HostageRescue",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PosX = table.Column<double>(nullable: false),
                    PosY = table.Column<double>(nullable: false),
                    PosZ = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostageRescue", x => new { x.MatchId, x.Round, x.PlayerId, x.Time });
                    table.ForeignKey(
                        name: "FK_HostageRescue_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageRescue_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageRescue_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageRescue_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDropped",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemDroppedId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    Equipment = table.Column<short>(nullable: false),
                    ByDeath = table.Column<bool>(nullable: false),
                    Gift = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDropped", x => new { x.MatchId, x.ItemDroppedId });
                    table.ForeignKey(
                        name: "FK_ItemDropped_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDropped_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDropped_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDropped_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSaved",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemSavedId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Equipment = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSaved", x => new { x.MatchId, x.ItemSavedId });
                    table.ForeignKey(
                        name: "FK_ItemSaved_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSaved_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSaved_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSaved_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPosition",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    PlayerVeloX = table.Column<double>(nullable: false),
                    PlayerVeloY = table.Column<double>(nullable: false),
                    PlayerVeloZ = table.Column<double>(nullable: false),
                    Weapon = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPosition", x => new { x.MatchId, x.Round, x.PlayerId, x.Time });
                    table.ForeignKey(
                        name: "FK_PlayerPosition_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoundItem",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    RoundItemId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Equipment = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundItem", x => new { x.MatchId, x.RoundItemId });
                    table.ForeignKey(
                        name: "FK_RoundItem_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundItem_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundItem_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundItem_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smoke",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Target = table.Column<int>(nullable: false),
                    Result = table.Column<byte>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smoke", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_Smoke_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Smoke_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Smoke_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Smoke_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponFired",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    WeaponFiredId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    PlayerVeloX = table.Column<double>(nullable: false),
                    PlayerVeloY = table.Column<double>(nullable: false),
                    PlayerVeloZ = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    InAccuracyFromFiring = table.Column<double>(nullable: false),
                    InAccuracyFromMoving = table.Column<double>(nullable: false),
                    PlayerState = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponFired", x => new { x.MatchId, x.WeaponFiredId });
                    table.ForeignKey(
                        name: "FK_WeaponFired_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponFired_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponFired_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponFired_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponReload",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    WeaponReloadId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerViewX = table.Column<double>(nullable: false),
                    PlayerViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    AmmoBefore = table.Column<short>(nullable: false),
                    AmmoAfter = table.Column<short>(nullable: false),
                    ReserveAmmo = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponReload", x => new { x.MatchId, x.WeaponReloadId });
                    table.ForeignKey(
                        name: "FK_WeaponReload_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponReload_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponReload_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponReload_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPickedUp",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemPickedUpId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    Equipment = table.Column<short>(nullable: false),
                    ItemDroppedId = table.Column<long>(nullable: true),
                    Gift = table.Column<bool>(nullable: false),
                    Buy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPickedUp", x => new { x.MatchId, x.ItemPickedUpId });
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_ItemDropped_MatchId_ItemDroppedId",
                        columns: x => new { x.MatchId, x.ItemDroppedId },
                        principalTable: "ItemDropped",
                        principalColumns: new[] { "MatchId", "ItemDroppedId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Damage",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    DamageId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    VictimId = table.Column<long>(nullable: false),
                    VictimPosX = table.Column<double>(nullable: false),
                    VictimPosY = table.Column<double>(nullable: false),
                    VictimPosZ = table.Column<double>(nullable: false),
                    AmountHealth = table.Column<int>(nullable: false),
                    AmountHealthPotential = table.Column<int>(nullable: false),
                    AmountArmor = table.Column<int>(nullable: false),
                    HitGroup = table.Column<byte>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    Fatal = table.Column<bool>(nullable: false),
                    TeamAttack = table.Column<bool>(nullable: false),
                    WeaponFiredId = table.Column<long>(nullable: true),
                    HeGrenadeId = table.Column<long>(nullable: true),
                    FireNadeId = table.Column<long>(nullable: true),
                    DecoyId = table.Column<long>(nullable: true),
                    PlayerZoneByTeam = table.Column<int>(nullable: true),
                    VictimZoneByTeam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => new { x.MatchId, x.DamageId });
                    table.ForeignKey(
                        name: "FK_Damage_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_Decoy_MatchId_DecoyId",
                        columns: x => new { x.MatchId, x.DecoyId },
                        principalTable: "Decoy",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_FireNade_MatchId_FireNadeId",
                        columns: x => new { x.MatchId, x.FireNadeId },
                        principalTable: "FireNade",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_He_MatchId_HeGrenadeId",
                        columns: x => new { x.MatchId, x.HeGrenadeId },
                        principalTable: "He",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerMatchStats_MatchId_VictimId",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_WeaponFired_MatchId_WeaponFiredId",
                        columns: x => new { x.MatchId, x.WeaponFiredId },
                        principalTable: "WeaponFired",
                        principalColumns: new[] { "MatchId", "WeaponFiredId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerRoundStats_MatchId_Round_VictimId",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kills",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    KillId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Tick = table.Column<int>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    PlayerPosX = table.Column<double>(nullable: false),
                    PlayerPosY = table.Column<double>(nullable: false),
                    PlayerPosZ = table.Column<double>(nullable: false),
                    PlayerPrimary = table.Column<short>(nullable: false),
                    PlayerSecondary = table.Column<short>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    VictimId = table.Column<long>(nullable: false),
                    VictimPosX = table.Column<double>(nullable: false),
                    VictimPosY = table.Column<double>(nullable: false),
                    VictimPosZ = table.Column<double>(nullable: false),
                    VictimPrimary = table.Column<short>(nullable: false),
                    VictimSecondary = table.Column<short>(nullable: false),
                    AssistByFlash = table.Column<bool>(nullable: false),
                    AssisterId = table.Column<long>(nullable: true),
                    AssisterPosX = table.Column<double>(nullable: true),
                    AssisterPosY = table.Column<double>(nullable: true),
                    AssisterPosZ = table.Column<double>(nullable: true),
                    KillType = table.Column<byte>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    TeamKill = table.Column<bool>(nullable: false),
                    DamageId = table.Column<long>(nullable: false),
                    PlayerZoneByTeam = table.Column<int>(nullable: true),
                    VictimZoneByTeam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kills", x => new { x.MatchId, x.KillId });
                    table.ForeignKey(
                        name: "FK_Kills_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_Damage_MatchId_DamageId",
                        columns: x => new { x.MatchId, x.DamageId },
                        principalTable: "Damage",
                        principalColumns: new[] { "MatchId", "DamageId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerMatchStats_MatchId_PlayerId",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerMatchStats_MatchId_VictimId",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerRoundStats_MatchId_Round_PlayerId",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerRoundStats_MatchId_Round_VictimId",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flashed",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    GrenadeId = table.Column<long>(nullable: false),
                    VictimId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    VictimPosX = table.Column<double>(nullable: false),
                    VictimPosY = table.Column<double>(nullable: false),
                    VictimPosZ = table.Column<double>(nullable: false),
                    VictimViewX = table.Column<double>(nullable: false),
                    VictimViewY = table.Column<double>(nullable: false),
                    IsCt = table.Column<bool>(nullable: false),
                    TimeFlashed = table.Column<int>(nullable: false),
                    TeamAttack = table.Column<bool>(nullable: false),
                    AssistedKillId = table.Column<long>(nullable: true),
                    TimeUntilAssistedKill = table.Column<int>(nullable: true),
                    AngleToCrosshair = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashed", x => new { x.MatchId, x.GrenadeId, x.VictimId });
                    table.ForeignKey(
                        name: "FK_Flashed_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashed_Kills_MatchId_AssistedKillId",
                        columns: x => new { x.MatchId, x.AssistedKillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flashed_Flash_MatchId_GrenadeId",
                        columns: x => new { x.MatchId, x.GrenadeId },
                        principalTable: "Flash",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashed_RoundStats_MatchId_Round",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashed_PlayerMatchStats_MatchId_VictimId",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashed_PlayerRoundStats_MatchId_Round_VictimId",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refrag",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    KillId = table.Column<long>(nullable: false),
                    RefraggedKillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refrag", x => new { x.MatchId, x.KillId });
                    table.ForeignKey(
                        name: "FK_Refrag_MatchStats_MatchId",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refrag_Kills_MatchId_KillId",
                        columns: x => new { x.MatchId, x.KillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Refrag_Kills_MatchId_RefraggedKillId",
                        columns: x => new { x.MatchId, x.RefraggedKillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BombDefused_MatchId",
                table: "BombDefused",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BombDefused_MatchId_PlayerId",
                table: "BombDefused",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BombDefused_MatchId_Round",
                table: "BombDefused",
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BombDefused_MatchId_Round_PlayerId",
                table: "BombDefused",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BombExplosion_MatchId",
                table: "BombExplosion",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BombExplosion_MatchId_Round",
                table: "BombExplosion",
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BombPlant_MatchId",
                table: "BombPlant",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BombPlant_MatchId_PlayerId",
                table: "BombPlant",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BombPlant_MatchId_Round",
                table: "BombPlant",
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BombPlant_MatchId_Round_PlayerId",
                table: "BombPlant",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BotTakeOver_MatchId",
                table: "BotTakeOver",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BotTakeOver_MatchId_PlayerId",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BotTakeOver_MatchId_Round",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_BotTakeOver_MatchId_Round_PlayerId",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectDisconnect_MatchId",
                table: "ConnectDisconnect",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectDisconnect_MatchId_PlayerId",
                table: "ConnectDisconnect",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectDisconnect_MatchId_Round",
                table: "ConnectDisconnect",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId",
                table: "Damage",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_DecoyId",
                table: "Damage",
                columns: new[] { "MatchId", "DecoyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_FireNadeId",
                table: "Damage",
                columns: new[] { "MatchId", "FireNadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_HeGrenadeId",
                table: "Damage",
                columns: new[] { "MatchId", "HeGrenadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_PlayerId",
                table: "Damage",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_Round",
                table: "Damage",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_VictimId",
                table: "Damage",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_WeaponFiredId",
                table: "Damage",
                columns: new[] { "MatchId", "WeaponFiredId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_Round_PlayerId",
                table: "Damage",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_Round_VictimId",
                table: "Damage",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_Decoy_MatchId",
                table: "Decoy",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Decoy_MatchId_PlayerId",
                table: "Decoy",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Decoy_MatchId_Round",
                table: "Decoy",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Decoy_MatchId_Round_PlayerId",
                table: "Decoy",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FireNade_MatchId",
                table: "FireNade",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FireNade_MatchId_PlayerId",
                table: "FireNade",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FireNade_MatchId_Round",
                table: "FireNade",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FireNade_MatchId_Round_PlayerId",
                table: "FireNade",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flash_MatchId",
                table: "Flash",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Flash_MatchId_PlayerId",
                table: "Flash",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flash_MatchId_Round",
                table: "Flash",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Flash_MatchId_Round_PlayerId",
                table: "Flash",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId",
                table: "Flashed",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_AssistedKillId",
                table: "Flashed",
                columns: new[] { "MatchId", "AssistedKillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_Round",
                table: "Flashed",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_VictimId",
                table: "Flashed",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_Flashed_MatchId_Round_VictimId",
                table: "Flashed",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_He_MatchId",
                table: "He",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_He_MatchId_PlayerId",
                table: "He",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_He_MatchId_Round",
                table: "He",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_He_MatchId_Round_PlayerId",
                table: "He",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageDrop_MatchId",
                table: "HostageDrop",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_HostageDrop_MatchId_PlayerId",
                table: "HostageDrop",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageDrop_MatchId_Round",
                table: "HostageDrop",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageDrop_MatchId_Round_PlayerId",
                table: "HostageDrop",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostagePickUp_MatchId",
                table: "HostagePickUp",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_HostagePickUp_MatchId_PlayerId",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostagePickUp_MatchId_Round",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_HostagePickUp_MatchId_Round_PlayerId",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageRescue_MatchId",
                table: "HostageRescue",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_HostageRescue_MatchId_PlayerId",
                table: "HostageRescue",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageRescue_MatchId_Round",
                table: "HostageRescue",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_HostageRescue_MatchId_Round_PlayerId",
                table: "HostageRescue",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDropped_MatchId",
                table: "ItemDropped",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDropped_MatchId_PlayerId",
                table: "ItemDropped",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDropped_MatchId_Round",
                table: "ItemDropped",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDropped_MatchId_Round_PlayerId",
                table: "ItemDropped",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPickedUp_MatchId",
                table: "ItemPickedUp",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPickedUp_MatchId_ItemDroppedId",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "ItemDroppedId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPickedUp_MatchId_PlayerId",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPickedUp_MatchId_Round",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPickedUp_MatchId_Round_PlayerId",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaved_MatchId",
                table: "ItemSaved",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaved_MatchId_PlayerId",
                table: "ItemSaved",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaved_MatchId_Round",
                table: "ItemSaved",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSaved_MatchId_Round_PlayerId",
                table: "ItemSaved",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId",
                table: "Kills",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_DamageId",
                table: "Kills",
                columns: new[] { "MatchId", "DamageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_PlayerId",
                table: "Kills",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_Round",
                table: "Kills",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_VictimId",
                table: "Kills",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_Round_PlayerId",
                table: "Kills",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_Round_VictimId",
                table: "Kills",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchStats_DemoId",
                table: "MatchStats",
                column: "DemoId");

            migrationBuilder.CreateIndex(
                name: "IX_OverTimeStats_MatchId",
                table: "OverTimeStats",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_MatchId",
                table: "PlayerMatchStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatchStats_SteamId",
                table: "PlayerMatchStats",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPosition_MatchId",
                table: "PlayerPosition",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPosition_MatchId_PlayerId",
                table: "PlayerPosition",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundStats_MatchId",
                table: "PlayerRoundStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundStats_PlayerId",
                table: "PlayerRoundStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundStats_MatchId_PlayerId",
                table: "PlayerRoundStats",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRoundStats_MatchId_Round",
                table: "PlayerRoundStats",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Refrag_MatchId",
                table: "Refrag",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Refrag_MatchId_KillId",
                table: "Refrag",
                columns: new[] { "MatchId", "KillId" });

            migrationBuilder.CreateIndex(
                name: "IX_Refrag_MatchId_RefraggedKillId",
                table: "Refrag",
                columns: new[] { "MatchId", "RefraggedKillId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoundItem_MatchId",
                table: "RoundItem",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundItem_MatchId_PlayerId",
                table: "RoundItem",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoundItem_MatchId_Round",
                table: "RoundItem",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_RoundItem_MatchId_Round_PlayerId",
                table: "RoundItem",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoundStats_MatchId",
                table: "RoundStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Smoke_MatchId",
                table: "Smoke",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Smoke_MatchId_PlayerId",
                table: "Smoke",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Smoke_MatchId_Round",
                table: "Smoke",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Smoke_MatchId_Round_PlayerId",
                table: "Smoke",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponFired_MatchId",
                table: "WeaponFired",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponFired_MatchId_PlayerId",
                table: "WeaponFired",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponFired_MatchId_Round_PlayerId",
                table: "WeaponFired",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponReload_MatchId",
                table: "WeaponReload",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponReload_MatchId_PlayerId",
                table: "WeaponReload",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponReload_MatchId_Round",
                table: "WeaponReload",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponReload_MatchId_Round_PlayerId",
                table: "WeaponReload",
                columns: new[] { "MatchId", "Round", "PlayerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BombDefused");

            migrationBuilder.DropTable(
                name: "BombExplosion");

            migrationBuilder.DropTable(
                name: "BombPlant");

            migrationBuilder.DropTable(
                name: "BotTakeOver");

            migrationBuilder.DropTable(
                name: "ConnectDisconnect");

            migrationBuilder.DropTable(
                name: "Flashed");

            migrationBuilder.DropTable(
                name: "HostageDrop");

            migrationBuilder.DropTable(
                name: "HostagePickUp");

            migrationBuilder.DropTable(
                name: "HostageRescue");

            migrationBuilder.DropTable(
                name: "ItemPickedUp");

            migrationBuilder.DropTable(
                name: "ItemSaved");

            migrationBuilder.DropTable(
                name: "OverTimeStats");

            migrationBuilder.DropTable(
                name: "PlayerPosition");

            migrationBuilder.DropTable(
                name: "Refrag");

            migrationBuilder.DropTable(
                name: "RoundItem");

            migrationBuilder.DropTable(
                name: "Smoke");

            migrationBuilder.DropTable(
                name: "WeaponReload");

            migrationBuilder.DropTable(
                name: "Flash");

            migrationBuilder.DropTable(
                name: "ItemDropped");

            migrationBuilder.DropTable(
                name: "Kills");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropTable(
                name: "Decoy");

            migrationBuilder.DropTable(
                name: "FireNade");

            migrationBuilder.DropTable(
                name: "He");

            migrationBuilder.DropTable(
                name: "WeaponFired");

            migrationBuilder.DropTable(
                name: "PlayerRoundStats");

            migrationBuilder.DropTable(
                name: "PlayerMatchStats");

            migrationBuilder.DropTable(
                name: "RoundStats");

            migrationBuilder.DropTable(
                name: "MatchStats");
        }
    }
}
