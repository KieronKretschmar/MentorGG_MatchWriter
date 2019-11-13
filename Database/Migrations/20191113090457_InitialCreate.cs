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
                name: "_BombZone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Team = table.Column<byte>(nullable: false),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false),
                    ParentZoneId = table.Column<int>(nullable: false),
                    ZoneDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BombZone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "_FireNadeZone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Team = table.Column<byte>(nullable: false),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false),
                    ParentZoneId = table.Column<int>(nullable: false),
                    ZoneDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FireNadeZone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "_FlashZone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Team = table.Column<byte>(nullable: false),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false),
                    ParentZoneId = table.Column<int>(nullable: false),
                    ZoneDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FlashZone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "_HEZone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Team = table.Column<byte>(nullable: false),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false),
                    ParentZoneId = table.Column<int>(nullable: false),
                    ZoneDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HEZone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "_MapSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    ConversionOffsetX = table.Column<double>(nullable: false),
                    ConversionOffsetY = table.Column<double>(nullable: false),
                    ConversionScaleX = table.Column<double>(nullable: false),
                    ConversionScaleY = table.Column<double>(nullable: false),
                    CropXMin = table.Column<double>(nullable: false),
                    CropYMin = table.Column<double>(nullable: false),
                    CropXMax = table.Column<double>(nullable: false),
                    CropYMax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MapSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_OpposingZones",
                columns: table => new
                {
                    TZoneId = table.Column<int>(nullable: false),
                    CtZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OpposingZones", x => new { x.TZoneId, x.CtZoneId });
                });

            migrationBuilder.CreateTable(
                name: "_PolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PolygonPoint", x => new { x.ZoneId, x.PointId });
                });

            migrationBuilder.CreateTable(
                name: "_PositionOpposingZones",
                columns: table => new
                {
                    TZoneId = table.Column<int>(nullable: false),
                    CtZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PositionOpposingZones", x => new { x.TZoneId, x.CtZoneId });
                });

            migrationBuilder.CreateTable(
                name: "_PositionZone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Team = table.Column<short>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: true),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false),
                    ParentZoneId = table.Column<int>(nullable: false),
                    ZoneDepth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PositionZone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "_SinglePath",
                columns: table => new
                {
                    PathId = table.Column<long>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SuperOrdinateId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SinglePath", x => x.PathId);
                });

            migrationBuilder.CreateTable(
                name: "_SmokeTarget",
                columns: table => new
                {
                    TargetId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GrenadePosXPixel = table.Column<int>(nullable: false),
                    GrenadePosYPixel = table.Column<int>(nullable: false),
                    GrenadePosX = table.Column<int>(nullable: false),
                    GrenadePosY = table.Column<int>(nullable: false),
                    GrenadePosZ = table.Column<int>(nullable: false),
                    GrenadePosXMin = table.Column<int>(nullable: false),
                    GrenadePosYMin = table.Column<int>(nullable: false),
                    GrenadePosZMin = table.Column<int>(nullable: false),
                    GrenadePosXMax = table.Column<int>(nullable: false),
                    GrenadePosYMax = table.Column<int>(nullable: false),
                    GrenadePosZMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SmokeTarget", x => x.TargetId);
                });

            migrationBuilder.CreateTable(
                name: "_TeamStrategy",
                columns: table => new
                {
                    StrategyId = table.Column<long>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SuperOrdinateId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeamStrategy", x => x.StrategyId);
                });

            migrationBuilder.CreateTable(
                name: "_Zone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    ZMin = table.Column<double>(nullable: true),
                    ZMax = table.Column<double>(nullable: true),
                    CenterXIngame = table.Column<double>(nullable: false),
                    CenterYIngame = table.Column<double>(nullable: false),
                    CenterXPixel = table.Column<int>(nullable: false),
                    CenterYPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Zone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "DemoStats",
                columns: table => new
                {
                    DemoId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<long>(nullable: true),
                    DemoUrl = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    DemoFileName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    DemoFilePath = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    DemoFileHashMD5 = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    MatchDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<short>(nullable: false),
                    Attempts = table.Column<short>(nullable: false),
                    DemoAnalyzerVersion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('1900-01-01 00:00:00')"),
                    PyAnalyzerVersion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('1900-01-01 00:00:00')"),
                    FaceItMatchId = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    UploadedBy = table.Column<long>(nullable: false, defaultValueSql: "((-1))"),
                    UploadType = table.Column<short>(nullable: false, defaultValueSql: "((-1))"),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoStats", x => x.DemoId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Source = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    Type = table.Column<short>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    InGameName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    WeaporArmorRatio = table.Column<double>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    RangeModifier = table.Column<double>(nullable: false),
                    CycleTime = table.Column<double>(nullable: false),
                    Penetration = table.Column<double>(nullable: false),
                    KillAward = table.Column<int>(nullable: false),
                    MaxPlayerSpeed = table.Column<int>(nullable: false),
                    ClipSize = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Range = table.Column<int>(nullable: false),
                    WeaponClass = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    FullAuto = table.Column<double>(nullable: false),
                    Bullets = table.Column<double>(nullable: false),
                    TracerFrequency = table.Column<double>(nullable: false),
                    FlinchVelocityModifierLarge = table.Column<double>(nullable: false),
                    FlinchVelocityModifierSmall = table.Column<double>(nullable: false),
                    Spread = table.Column<double>(nullable: false),
                    InaccuracyCrouch = table.Column<double>(nullable: false),
                    InaccuracyStand = table.Column<double>(nullable: false),
                    InaccuracyFire = table.Column<double>(nullable: false),
                    InaccuracyMove = table.Column<double>(nullable: false),
                    InaccuracyJump = table.Column<double>(nullable: false),
                    InaccuracyJumpIntial = table.Column<double>(nullable: false),
                    InaccuracyLand = table.Column<double>(nullable: false),
                    InaccuracyLadder = table.Column<double>(nullable: false),
                    RecoveryTimeCrouch = table.Column<double>(nullable: false),
                    RecoveryTimeCrouchFinal = table.Column<double>(nullable: false),
                    RecoveryTimeStand = table.Column<double>(nullable: false),
                    RecoveryTimeStandFinal = table.Column<double>(nullable: false),
                    RecoilAngleVariance = table.Column<double>(nullable: false),
                    RecoilMagnitude = table.Column<double>(nullable: false),
                    RecoilMagnitudeVariance = table.Column<double>(nullable: false),
                    SpreadAlt = table.Column<double>(nullable: false),
                    InaccuracyCrouchAlt = table.Column<double>(nullable: false),
                    InaccuracyStandAlt = table.Column<double>(nullable: false),
                    InaccuracyFireAlt = table.Column<double>(nullable: false),
                    InaccuracyMoveAlt = table.Column<double>(nullable: false),
                    InaccuracyJumpAlt = table.Column<double>(nullable: false),
                    InaccuracyLandAlt = table.Column<double>(nullable: false),
                    InaccuracyLadderAlt = table.Column<double>(nullable: false),
                    RecoilAngleVarianceAlt = table.Column<double>(nullable: false),
                    RecoilMagnitudeAlt = table.Column<double>(nullable: false),
                    RecoilMagnitudeVarianceAlt = table.Column<double>(nullable: false),
                    MaxPlayerSpeedAlt = table.Column<double>(nullable: false),
                    TracerFrequencyAlt = table.Column<double>(nullable: false),
                    ZoomFov = table.Column<double>(nullable: false),
                    ZoomFovAlt = table.Column<double>(nullable: false),
                    CycleTimeAlt = table.Column<double>(nullable: false),
                    CycletimeBurst = table.Column<double>(nullable: false),
                    TimeInbetweenBurstShots = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    FriendSteamId = table.Column<long>(nullable: false),
                    FriendsSince = table.Column<DateTime>(type: "datetime", nullable: false),
                    Steam = table.Column<bool>(nullable: false),
                    FaceIt = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.SteamId, x.FriendSteamId });
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    SteamId = table.Column<long>(nullable: false),
                    SteamName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    AvatarIcon = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    Banned = table.Column<bool>(nullable: false),
                    NumOfVACBans = table.Column<int>(nullable: false),
                    NumOfGameBans = table.Column<int>(nullable: false),
                    LastVacBan = table.Column<int>(nullable: false),
                    LastGameBan = table.Column<int>(nullable: false),
                    BlameCounter = table.Column<int>(nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false),
                    GamesWon = table.Column<int>(nullable: false),
                    Rank = table.Column<byte>(nullable: false),
                    LastRankUpdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "('1900-01-01 00:00:00')"),
                    Kills = table.Column<long>(nullable: false),
                    Assists = table.Column<long>(nullable: false),
                    Deaths = table.Column<long>(nullable: false),
                    Score = table.Column<long>(nullable: false),
                    MVPs = table.Column<long>(nullable: false),
                    HS = table.Column<long>(nullable: false),
                    HSKills = table.Column<long>(nullable: false),
                    Shots = table.Column<long>(nullable: false),
                    Hits = table.Column<long>(nullable: false),
                    HSVictim = table.Column<long>(nullable: false),
                    HSDeaths = table.Column<long>(nullable: false),
                    Enemy2K = table.Column<long>(nullable: false),
                    Enemy3K = table.Column<long>(nullable: false),
                    Enemy4K = table.Column<long>(nullable: false),
                    Enemy5K = table.Column<long>(nullable: false),
                    Damage = table.Column<long>(nullable: false),
                    DamageVictim = table.Column<int>(nullable: false),
                    BombPlants = table.Column<long>(nullable: false),
                    BombExplosions = table.Column<long>(nullable: false),
                    BombDefuses = table.Column<long>(nullable: false),
                    MoneyEarned = table.Column<long>(nullable: false),
                    MoneySpent = table.Column<long>(nullable: false),
                    MoneyLost = table.Column<long>(nullable: false),
                    DecoysUsed = table.Column<long>(nullable: false),
                    FireNadesUsed = table.Column<long>(nullable: false),
                    FireNadesDamage = table.Column<long>(nullable: false),
                    FireNadesDamageVictim = table.Column<long>(nullable: false),
                    FlashesUsed = table.Column<long>(nullable: false),
                    FlashesSucceeded = table.Column<long>(nullable: false),
                    FlashVictim = table.Column<long>(nullable: false),
                    TeamFlashed = table.Column<long>(nullable: false),
                    TeamFlashVictim = table.Column<long>(nullable: false),
                    SelfFlashed = table.Column<long>(nullable: false),
                    HEsUsed = table.Column<long>(nullable: false),
                    HEsDamage = table.Column<long>(nullable: false),
                    HEsDamageVictim = table.Column<long>(nullable: false),
                    SmokesUsed = table.Column<long>(nullable: false),
                    FirstBloods = table.Column<long>(nullable: false),
                    FirstBloodVictim = table.Column<long>(nullable: false),
                    AVGTimeAlive = table.Column<double>(nullable: false),
                    TeamDamage = table.Column<long>(nullable: false),
                    TeamKills = table.Column<long>(nullable: false),
                    EntryKills = table.Column<long>(nullable: false),
                    EntryKillVictim = table.Column<long>(nullable: false),
                    Suicides = table.Column<long>(nullable: false),
                    BombVictim = table.Column<long>(nullable: false),
                    HLTVRating1 = table.Column<double>(nullable: false),
                    HLTVRating2 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.SteamId);
                });

            migrationBuilder.CreateTable(
                name: "_BombPolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BombPolygonPoint", x => new { x.ZoneId, x.PointId });
                    table.ForeignKey(
                        name: "FK__BombPolygonPoint__BombZone",
                        column: x => x.ZoneId,
                        principalTable: "_BombZone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_FireNadePolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FireNadePolygonPoint", x => new { x.ZoneId, x.PointId });
                    table.ForeignKey(
                        name: "FK__FireNadePolygonPoint__FireNadeZone",
                        column: x => x.ZoneId,
                        principalTable: "_FireNadeZone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_FlashPolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FlashPolygonPoint", x => new { x.ZoneId, x.PointId });
                    table.ForeignKey(
                        name: "FK__FlashPolygonPoint__FlashZone",
                        column: x => x.ZoneId,
                        principalTable: "_FlashZone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_HEPolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HEPolygonPoint", x => new { x.ZoneId, x.PointId });
                    table.ForeignKey(
                        name: "FK__HEPolygonPoint__HEZone",
                        column: x => x.ZoneId,
                        principalTable: "_HEZone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_PositionPolygonPoint",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    XIngame = table.Column<double>(nullable: false),
                    YIngame = table.Column<double>(nullable: false),
                    XPixel = table.Column<int>(nullable: false),
                    YPixel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PositionPolygonPoint", x => new { x.ZoneId, x.PointId });
                    table.ForeignKey(
                        name: "FK__PositionPolygonPoint__PositionZone",
                        column: x => x.ZoneId,
                        principalTable: "_PositionZone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_SmokeCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    Map = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TargetId = table.Column<int>(nullable: false),
                    ThrowType = table.Column<byte>(nullable: false),
                    Setpos = table.Column<string>(nullable: true),
                    PlayerPosXPixel = table.Column<int>(nullable: false),
                    PlayerPosYPixel = table.Column<int>(nullable: false),
                    PlayerPosX = table.Column<int>(nullable: false),
                    PlayerPosY = table.Column<int>(nullable: false),
                    PlayerPosZ = table.Column<int>(nullable: false),
                    PlayerViewX = table.Column<int>(nullable: false),
                    PlayerViewY = table.Column<int>(nullable: false),
                    GrenadePosX = table.Column<int>(nullable: false),
                    GrenadePosY = table.Column<int>(nullable: false),
                    GrenadePosZ = table.Column<int>(nullable: false),
                    PlayerPosXMin = table.Column<int>(nullable: false),
                    PlayerPosYMin = table.Column<int>(nullable: false),
                    PlayerPosZMin = table.Column<int>(nullable: false),
                    PlayerViewXMin = table.Column<int>(nullable: false),
                    PlayerViewYMin = table.Column<int>(nullable: false),
                    PlayerPosXMax = table.Column<int>(nullable: false),
                    PlayerPosYMax = table.Column<int>(nullable: false),
                    PlayerPosZMax = table.Column<int>(nullable: false),
                    PlayerViewXMax = table.Column<int>(nullable: false),
                    PlayerViewYMax = table.Column<int>(nullable: false),
                    ViewXContainsPole = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SmokeCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK__SmokeCategory__SmokeTarget",
                        column: x => x.TargetId,
                        principalTable: "_SmokeTarget",
                        principalColumn: "TargetId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_MatchStats_DemoStats",
                        column: x => x.DemoId,
                        principalTable: "DemoStats",
                        principalColumn: "DemoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OverTimeStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    StartT = table.Column<byte>(nullable: false),
                    StartCT = table.Column<byte>(nullable: false),
                    StartMoney = table.Column<int>(nullable: false),
                    NumRounds = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverTimeStats", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_OverTimeStats_MatchStats",
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
                    Kills = table.Column<short>(nullable: false),
                    Assists = table.Column<short>(nullable: false),
                    Deaths = table.Column<short>(nullable: false),
                    Score = table.Column<short>(nullable: false),
                    MVPs = table.Column<short>(nullable: false),
                    HS = table.Column<short>(nullable: false),
                    HSKills = table.Column<short>(nullable: false),
                    Shots = table.Column<short>(nullable: false),
                    Hits = table.Column<short>(nullable: false),
                    HSVictim = table.Column<short>(nullable: false),
                    HSDeaths = table.Column<short>(nullable: false),
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
                    HEsUsed = table.Column<short>(nullable: false),
                    HEsDamage = table.Column<int>(nullable: false),
                    HEsDamageVictim = table.Column<int>(nullable: false),
                    SmokesUsed = table.Column<short>(nullable: false),
                    FirstBloods = table.Column<short>(nullable: false),
                    FirstBloodVictim = table.Column<short>(nullable: false),
                    AVGTimeAlive = table.Column<double>(nullable: false),
                    TeamDamage = table.Column<int>(nullable: false),
                    TeamKills = table.Column<int>(nullable: false),
                    EntryKills = table.Column<int>(nullable: false),
                    EntryKillVictim = table.Column<int>(nullable: false),
                    Suicides = table.Column<short>(nullable: false),
                    BombVictim = table.Column<short>(nullable: false),
                    HLTVRating1 = table.Column<double>(nullable: false),
                    HLTVRating2 = table.Column<double>(nullable: false),
                    RankBeforeMatch = table.Column<byte>(nullable: false),
                    RankAfterMatch = table.Column<byte>(nullable: false),
                    RealKills = table.Column<short>(nullable: false),
                    RealDeaths = table.Column<short>(nullable: false),
                    RealAssists = table.Column<short>(nullable: false),
                    RealScore = table.Column<short>(nullable: false),
                    RealMVPs = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatchStats", x => new { x.MatchId, x.SteamId });
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatchStats_PlayerStats",
                        column: x => x.SteamId,
                        principalTable: "PlayerStats",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Restrict);
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
                    _CtBuyStrat = table.Column<int>(nullable: false),
                    _TBuyStrat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundStats", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_RoundStats_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_PlayerMatchSmokeStats",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    _Category = table.Column<int>(nullable: false),
                    _Attempts = table.Column<byte>(nullable: false),
                    _Misses = table.Column<byte>(nullable: false),
                    _Insides = table.Column<byte>(nullable: false),
                    _Gapfrees = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PlayerMatchSmokeStats", x => new { x.MatchId, x.PlayerId, x._Category });
                    table.ForeignKey(
                        name: "FK__PlayerMatchSmokeStats_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__PlayerMatchSmokeStats_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_BombExplosion_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombExplosion_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ConnectDisconnect_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectDisconnect_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConnectDisconnect_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    ArmorType = table.Column<short>(nullable: false),
                    PathId = table.Column<int>(nullable: false),
                    RoundStartKills = table.Column<short>(nullable: false),
                    RoundStartDeaths = table.Column<short>(nullable: false),
                    RoundStartAssists = table.Column<short>(nullable: false),
                    RoundStartScore = table.Column<short>(nullable: false),
                    RoundStartMVPs = table.Column<short>(nullable: false),
                    RoundStartDamage = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoundStats", x => new { x.MatchId, x.Round, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_PlayerStats",
                        column: x => x.PlayerId,
                        principalTable: "PlayerStats",
                        principalColumn: "SteamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerRoundStats_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_BombExplosion_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombDefused_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BombDefused_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BombDefused_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    PlantZone = table.Column<int>(nullable: false, defaultValueSql: "((-1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombPlant", x => new { x.MatchId, x.Round });
                    table.ForeignKey(
                        name: "FK_BombPlant_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BombPlant_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BombPlant_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BombPlant_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_BotTakeOver_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BotTakeOver_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoy", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_Decoy_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decoy_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Decoy_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Decoy_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
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
                        name: "FK_FireNade_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireNade_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FireNade_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FireNade_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
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
                        name: "FK_Flash_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flash_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flash_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flash_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HE",
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
                    IsCT = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    DetonationZoneByTeam = table.Column<int>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HE", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_HE_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HE_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HE_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HE_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_HostageDrop_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageDrop_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostageDrop_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostageDrop_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_HostagePickUp_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostagePickUp_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_HostageRescue_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HostageRescue_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostageRescue_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HostageRescue_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDropped",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemDroppedId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCT = table.Column<bool>(nullable: false),
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
                        name: "FK_ItemDropped_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemDropped_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDropped_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDropped_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSaved",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemSavedId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCT = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Equipment = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSaved", x => new { x.MatchId, x.ItemSavedId });
                    table.ForeignKey(
                        name: "FK_ItemSaved_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSaved_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSaved_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSaved_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_PlayerPosition_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoundItem",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    RoundItemId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCT = table.Column<bool>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Equipment = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundItem", x => new { x.MatchId, x.RoundItemId });
                    table.ForeignKey(
                        name: "FK_RoundItem_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundItem_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundItem_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoundItem_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    GrenadePosX = table.Column<double>(nullable: false),
                    GrenadePosY = table.Column<double>(nullable: false),
                    GrenadePosZ = table.Column<double>(nullable: false),
                    _Category = table.Column<int>(nullable: false),
                    _Target = table.Column<int>(nullable: false),
                    _Result = table.Column<byte>(nullable: false),
                    Trajectory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smoke", x => new { x.MatchId, x.GrenadeId });
                    table.ForeignKey(
                        name: "FK_Smoke_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Smoke_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smoke_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smoke_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    InAccuracyFromFiring = table.Column<double>(nullable: false),
                    InAccuracyFromMoving = table.Column<double>(nullable: false),
                    PlayerState = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponFired", x => new { x.MatchId, x.WeaponFiredId });
                    table.ForeignKey(
                        name: "FK_WeaponFired_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponFired_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponFired_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponFired_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    AmmoBefore = table.Column<short>(nullable: false),
                    AmmoAfter = table.Column<short>(nullable: false),
                    ReserveAmmo = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponReload", x => new { x.MatchId, x.WeaponReloadId });
                    table.ForeignKey(
                        name: "FK_WeaponReload_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponReload_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponReload_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponReload_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPickedUp",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    ItemPickedUpId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    IsCT = table.Column<bool>(nullable: false),
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
                        name: "FK_ItemPickedUp_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_ItemDropped",
                        columns: x => new { x.MatchId, x.ItemDroppedId },
                        principalTable: "ItemDropped",
                        principalColumns: new[] { "MatchId", "ItemDroppedId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPickedUp_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_StutterStep",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    StutterStepId = table.Column<long>(nullable: false),
                    PlayerId = table.Column<long>(nullable: false),
                    Round = table.Column<short>(nullable: false),
                    WeaponFiredId = table.Column<long>(nullable: false),
                    StutterStartTime = table.Column<int>(nullable: false),
                    Under34Time = table.Column<int>(nullable: false),
                    Lag = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StutterStep", x => new { x.MatchId, x.PlayerId, x.StutterStepId });
                    table.ForeignKey(
                        name: "FK__StutterStep_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StutterStep_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__StutterStep_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__StutterStep_WeaponFired",
                        columns: x => new { x.MatchId, x.WeaponFiredId },
                        principalTable: "WeaponFired",
                        principalColumns: new[] { "MatchId", "WeaponFiredId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
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
                    HEGrenadeId = table.Column<long>(nullable: true),
                    FireNadeId = table.Column<long>(nullable: true),
                    DecoyId = table.Column<long>(nullable: true),
                    PlayerZoneByTeam = table.Column<int>(nullable: true),
                    VictimZoneByTeam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => new { x.MatchId, x.DamageId });
                    table.ForeignKey(
                        name: "FK_Damage_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_Decoy",
                        columns: x => new { x.MatchId, x.DecoyId },
                        principalTable: "Decoy",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_FireNade",
                        columns: x => new { x.MatchId, x.FireNadeId },
                        principalTable: "FireNade",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_HE",
                        columns: x => new { x.MatchId, x.HEGrenadeId },
                        principalTable: "HE",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerMatchStats_Victim",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_WeaponFired",
                        columns: x => new { x.MatchId, x.WeaponFiredId },
                        principalTable: "WeaponFired",
                        principalColumns: new[] { "MatchId", "WeaponFiredId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damage_PlayerRoundStats_Victim",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
                    VictimId = table.Column<long>(nullable: false),
                    VictimPosX = table.Column<double>(nullable: false),
                    VictimPosY = table.Column<double>(nullable: false),
                    VictimPosZ = table.Column<double>(nullable: false),
                    VictimPrimary = table.Column<short>(nullable: false),
                    VictimSecondary = table.Column<short>(nullable: false),
                    AssistedFlash = table.Column<bool>(nullable: false),
                    AssisterId = table.Column<long>(nullable: true),
                    AssisterPosX = table.Column<double>(nullable: true),
                    AssisterPosY = table.Column<double>(nullable: true),
                    AssisterPosZ = table.Column<double>(nullable: true),
                    KillType = table.Column<byte>(nullable: false),
                    Weapon = table.Column<short>(nullable: false),
                    TeamKill = table.Column<bool>(nullable: false),
                    DamageId = table.Column<long>(nullable: true),
                    PlayerZoneByTeam = table.Column<int>(nullable: true),
                    VictimZoneByTeam = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kills", x => new { x.MatchId, x.KillId });
                    table.ForeignKey(
                        name: "FK_Kills_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kills_Damage",
                        columns: x => new { x.MatchId, x.DamageId },
                        principalTable: "Damage",
                        principalColumns: new[] { "MatchId", "DamageId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.PlayerId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kills_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerMatchStats_Victim",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.PlayerId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kills_PlayerRoundStats_Victim",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_Refrag",
                columns: table => new
                {
                    MatchId = table.Column<long>(nullable: false),
                    KillId = table.Column<long>(nullable: false),
                    RefraggedKillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Refrag", x => new { x.MatchId, x.KillId });
                    table.ForeignKey(
                        name: "FK__Refrag_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Refrag_Kill",
                        columns: x => new { x.MatchId, x.KillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Refrag_Kill_Refragged",
                        columns: x => new { x.MatchId, x.RefraggedKillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Restrict);
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
                    IsCT = table.Column<bool>(nullable: false),
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
                        name: "FK_Flashed_MatchStats",
                        column: x => x.MatchId,
                        principalTable: "MatchStats",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashed_Kills",
                        columns: x => new { x.MatchId, x.AssistedKillId },
                        principalTable: "Kills",
                        principalColumns: new[] { "MatchId", "KillId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flashed_Flash",
                        columns: x => new { x.MatchId, x.GrenadeId },
                        principalTable: "Flash",
                        principalColumns: new[] { "MatchId", "GrenadeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flashed_RoundStats",
                        columns: x => new { x.MatchId, x.Round },
                        principalTable: "RoundStats",
                        principalColumns: new[] { "MatchId", "Round" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flashed_PlayerMatchStats",
                        columns: x => new { x.MatchId, x.VictimId },
                        principalTable: "PlayerMatchStats",
                        principalColumns: new[] { "MatchId", "SteamId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flashed_PlayerRoundStats",
                        columns: x => new { x.MatchId, x.Round, x.VictimId },
                        principalTable: "PlayerRoundStats",
                        principalColumns: new[] { "MatchId", "Round", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK__BombPolygonPoint__BombZone",
                table: "_BombPolygonPoint",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__FireNadePolygonPoint__FireNadeZone",
                table: "_FireNadePolygonPoint",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__FlashPolygonPoint__FlashZone",
                table: "_FlashPolygonPoint",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__HEPolygonPoint__HEZone",
                table: "_HEPolygonPoint",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__PlayerMatchSmokeStats_MatchStats",
                table: "_PlayerMatchSmokeStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__PlayerMatchSmokeStats_PlayerMatchStats",
                table: "_PlayerMatchSmokeStats",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK__PositionPolygonPoint__PositionZone",
                table: "_PositionPolygonPoint",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__Refrag_MatchStats",
                table: "_Refrag",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__Refrag_Kill",
                table: "_Refrag",
                columns: new[] { "MatchId", "KillId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK__Refrag_Kill_Refragged",
                table: "_Refrag",
                columns: new[] { "MatchId", "RefraggedKillId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK__SmokeCategory__SmokeTarget",
                table: "_SmokeCategory",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__StutterStep_MatchStats",
                table: "_StutterStep",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK__StutterStep_PlayerMatchStats",
                table: "_StutterStep",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK__StutterStep_RoundStats",
                table: "_StutterStep",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK__StutterStep_WeaponFired",
                table: "_StutterStep",
                columns: new[] { "MatchId", "WeaponFiredId" });

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
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombDefused_PlayerRoundStats",
                table: "BombDefused",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombExplosion_MatchStats",
                table: "BombExplosion",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombExplosion_RoundStats",
                table: "BombExplosion",
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombPlant_MatchStats",
                table: "BombPlant",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombPlant_PlayerMatchStats",
                table: "BombPlant",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombPlant_RoundStats",
                table: "BombPlant",
                columns: new[] { "MatchId", "Round" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FK_BombPlant_PlayerRoundStats",
                table: "BombPlant",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BotTakeOver_MatchStats",
                table: "BotTakeOver",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BotTakeOver_PlayerMatchStats",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BotTakeOver_RoundStats",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_BotTakeOver_PlayerRoundStats",
                table: "BotTakeOver",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ConnectDisconnect_MatchStats",
                table: "ConnectDisconnect",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ConnectDisconnect_PlayerMatchStats",
                table: "ConnectDisconnect",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ConnectDisconnect_RoundStats",
                table: "ConnectDisconnect",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_MatchStats",
                table: "Damage",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_Decoy",
                table: "Damage",
                columns: new[] { "MatchId", "DecoyId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_FireNade",
                table: "Damage",
                columns: new[] { "MatchId", "FireNadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_HE",
                table: "Damage",
                columns: new[] { "MatchId", "HEGrenadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_PlayerMatchStats",
                table: "Damage",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_RoundStats",
                table: "Damage",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_VictimId",
                table: "Damage",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_WeaponFired",
                table: "Damage",
                columns: new[] { "MatchId", "WeaponFiredId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Damage_PlayerRoundStats",
                table: "Damage",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Damage_MatchId_Round_VictimId",
                table: "Damage",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Decoy_MatchStats",
                table: "Decoy",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Decoy_PlayerMatchStats",
                table: "Decoy",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Decoy_RoundStats",
                table: "Decoy",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Decoy_PlayerRoundStats",
                table: "Decoy",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_FireNade_MatchStats",
                table: "FireNade",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_FireNade_PlayerMatchStats",
                table: "FireNade",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_FireNade_RoundStats",
                table: "FireNade",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_FireNade_PlayerRoundStats",
                table: "FireNade",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flash_MatchStats",
                table: "Flash",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flash_PlayerMatchStats",
                table: "Flash",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flash_RoundStats",
                table: "Flash",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flash_PlayerRoundStats",
                table: "Flash",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flashed_MatchStats",
                table: "Flashed",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flashed_Kills",
                table: "Flashed",
                columns: new[] { "MatchId", "AssistedKillId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flashed_RoundStats",
                table: "Flashed",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flashed_PlayerMatchStats",
                table: "Flashed",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Flashed_PlayerRoundStats",
                table: "Flashed",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendSteamId",
                table: "Friends",
                column: "FriendSteamId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_HE_MatchStats",
                table: "HE",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_HE_PlayerMatchStats",
                table: "HE",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HE_RoundStats",
                table: "HE",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HE_PlayerRoundStats",
                table: "HE",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageDrop_MatchStats",
                table: "HostageDrop",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageDrop_PlayerMatchStats",
                table: "HostageDrop",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageDrop_RoundStats",
                table: "HostageDrop",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageDrop_PlayerRoundStats",
                table: "HostageDrop",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostagePickUp_MatchStats",
                table: "HostagePickUp",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostagePickUp_PlayerMatchStats",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostagePickUp_RoundStats",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostagePickUp_PlayerRoundStats",
                table: "HostagePickUp",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageRescue_MatchStats",
                table: "HostageRescue",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageRescue_PlayerMatchStats",
                table: "HostageRescue",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageRescue_RoundStats",
                table: "HostageRescue",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_HostageRescue_PlayerRoundStats",
                table: "HostageRescue",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemDropped_MatchStats",
                table: "ItemDropped",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemDropped_PlayerMatchStats",
                table: "ItemDropped",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemDropped_RoundStats",
                table: "ItemDropped",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemDropped_PlayerRoundStats",
                table: "ItemDropped",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemPickedUp_MatchStats",
                table: "ItemPickedUp",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemPickedUp_ItemDropped",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "ItemDroppedId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemPickedUp_PlayerMatchStats",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemPickedUp_RoundStats",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemPickedUp_PlayerRoundStats",
                table: "ItemPickedUp",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemSaved_MatchStats",
                table: "ItemSaved",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemSaved_PlayerMatchStats",
                table: "ItemSaved",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemSaved_RoundStats",
                table: "ItemSaved",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_ItemSaved_PlayerRoundStats",
                table: "ItemSaved",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Kills_MatchStats",
                table: "Kills",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Kills_Damage",
                table: "Kills",
                columns: new[] { "MatchId", "DamageId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Kills_PlayerMatchStats",
                table: "Kills",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Kills_RoundStats",
                table: "Kills",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_VictimId",
                table: "Kills",
                columns: new[] { "MatchId", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Kills_PlayerRoundStats",
                table: "Kills",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kills_MatchId_Round_VictimId",
                table: "Kills",
                columns: new[] { "MatchId", "Round", "VictimId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_MatchStats_DemoStats",
                table: "MatchStats",
                column: "DemoId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_OverTimeStats_MatchStats",
                table: "OverTimeStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerMatchStats_MatchStats",
                table: "PlayerMatchStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerMatchStats_PlayerStats",
                table: "PlayerMatchStats",
                column: "SteamId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerPosition_MatchStats",
                table: "PlayerPosition",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerPosition_PlayerMatchStats",
                table: "PlayerPosition",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerPosition_RoundStats",
                table: "PlayerPosition",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerPosition_PlayerRoundStats",
                table: "PlayerPosition",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerRoundStats_MatchStats",
                table: "PlayerRoundStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerRoundStats_PlayerStats",
                table: "PlayerRoundStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerRoundStats_PlayerMatchStats",
                table: "PlayerRoundStats",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_PlayerRoundStats_RoundStats",
                table: "PlayerRoundStats",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoundItem_MatchStats",
                table: "RoundItem",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoundItem_PlayerMatchStats",
                table: "RoundItem",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoundItem_RoundStats",
                table: "RoundItem",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoundItem_PlayerRoundStats",
                table: "RoundItem",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoundStats_MatchStats",
                table: "RoundStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Smoke_MatchStats",
                table: "Smoke",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_Smoke_PlayerMatchStats",
                table: "Smoke",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Smoke_RoundStats",
                table: "Smoke",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_Smoke_PlayerRoundStats",
                table: "Smoke",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponFired_MatchStats",
                table: "WeaponFired",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponFired_PlayerMatchStats",
                table: "WeaponFired",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponFired_RoundStats",
                table: "WeaponFired",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponFired_PlayerRoundStats",
                table: "WeaponFired",
                columns: new[] { "MatchId", "Round", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponReload_MatchStats",
                table: "WeaponReload",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponReload_PlayerMatchStats",
                table: "WeaponReload",
                columns: new[] { "MatchId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponReload_RoundStats",
                table: "WeaponReload",
                columns: new[] { "MatchId", "Round" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_WeaponReload_PlayerRoundStats",
                table: "WeaponReload",
                columns: new[] { "MatchId", "Round", "PlayerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_BombPolygonPoint");

            migrationBuilder.DropTable(
                name: "_FireNadePolygonPoint");

            migrationBuilder.DropTable(
                name: "_FlashPolygonPoint");

            migrationBuilder.DropTable(
                name: "_HEPolygonPoint");

            migrationBuilder.DropTable(
                name: "_MapSettings");

            migrationBuilder.DropTable(
                name: "_OpposingZones");

            migrationBuilder.DropTable(
                name: "_PlayerMatchSmokeStats");

            migrationBuilder.DropTable(
                name: "_PolygonPoint");

            migrationBuilder.DropTable(
                name: "_PositionOpposingZones");

            migrationBuilder.DropTable(
                name: "_PositionPolygonPoint");

            migrationBuilder.DropTable(
                name: "_Refrag");

            migrationBuilder.DropTable(
                name: "_SinglePath");

            migrationBuilder.DropTable(
                name: "_SmokeCategory");

            migrationBuilder.DropTable(
                name: "_StutterStep");

            migrationBuilder.DropTable(
                name: "_TeamStrategy");

            migrationBuilder.DropTable(
                name: "_Zone");

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
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Flashed");

            migrationBuilder.DropTable(
                name: "Friends");

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
                name: "RoundItem");

            migrationBuilder.DropTable(
                name: "Smoke");

            migrationBuilder.DropTable(
                name: "WeaponReload");

            migrationBuilder.DropTable(
                name: "_BombZone");

            migrationBuilder.DropTable(
                name: "_FireNadeZone");

            migrationBuilder.DropTable(
                name: "_FlashZone");

            migrationBuilder.DropTable(
                name: "_HEZone");

            migrationBuilder.DropTable(
                name: "_PositionZone");

            migrationBuilder.DropTable(
                name: "_SmokeTarget");

            migrationBuilder.DropTable(
                name: "Kills");

            migrationBuilder.DropTable(
                name: "Flash");

            migrationBuilder.DropTable(
                name: "ItemDropped");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropTable(
                name: "Decoy");

            migrationBuilder.DropTable(
                name: "FireNade");

            migrationBuilder.DropTable(
                name: "HE");

            migrationBuilder.DropTable(
                name: "WeaponFired");

            migrationBuilder.DropTable(
                name: "PlayerRoundStats");

            migrationBuilder.DropTable(
                name: "PlayerMatchStats");

            migrationBuilder.DropTable(
                name: "RoundStats");

            migrationBuilder.DropTable(
                name: "PlayerStats");

            migrationBuilder.DropTable(
                name: "MatchStats");

            migrationBuilder.DropTable(
                name: "DemoStats");
        }
    }
}
