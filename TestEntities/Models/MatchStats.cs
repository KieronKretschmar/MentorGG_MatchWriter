using System;
using System.Collections.Generic;

namespace TestEntities
{
    public partial class MatchStats
    {
        public MatchStats()
        {
            BombDefused = new HashSet<BombDefused>();
            Kills = new HashSet<Kills>();
            PlayerMatchStats = new HashSet<PlayerMatchStats>();
        }

        public long MatchId { get; set; }
        public long DemoId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Map { get; set; }
        public byte WinnerTeam { get; set; }
        public short Score1 { get; set; }
        public short Score2 { get; set; }
        public short NumRoundsT1 { get; set; }
        public short NumRoundsCt1 { get; set; }
        public short NumRoundsT2 { get; set; }
        public short NumRoundsCt2 { get; set; }
        public short BombPlants1 { get; set; }
        public short BombPlants2 { get; set; }
        public short BombExplodes1 { get; set; }
        public short BombExplodes2 { get; set; }
        public short BombDefuses1 { get; set; }
        public short BombDefuses2 { get; set; }
        public int MoneyEarned1 { get; set; }
        public int MoneyEarned2 { get; set; }
        public int MoneySpent1 { get; set; }
        public int MoneySpent2 { get; set; }
        public int? AvgroundTime { get; set; }
        public int RoundTimer { get; set; }
        public int BombTimer { get; set; }
        public int StartMoney { get; set; }
        public short DemoTickRate { get; set; }
        public short SourceTickRate { get; set; }
        public string Source { get; set; }
        public byte GameType { get; set; }
        public double? Avgrank { get; set; }
        public short RealScore1 { get; set; }
        public short RealScore2 { get; set; }
        public string Event { get; set; }

        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<Kills> Kills { get; set; }
        public ICollection<PlayerMatchStats> PlayerMatchStats { get; set; }
    }
}
