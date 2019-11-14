using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MatchStats
    {
        public MatchStats()
        {
            BombDefused = new HashSet<BombDefused>();
            BombExplosion = new HashSet<BombExplosion>();
            BombPlant = new HashSet<BombPlant>();
            BotTakeOver = new HashSet<BotTakeOver>();
            ConnectDisconnect = new HashSet<ConnectDisconnect>();
            Damage = new HashSet<Damage>();
            Decoy = new HashSet<Decoy>();
            FireNade = new HashSet<FireNade>();
            Flash = new HashSet<Flash>();
            Flashed = new HashSet<Flashed>();
            He = new HashSet<He>();
            HostageDrop = new HashSet<HostageDrop>();
            HostagePickUp = new HashSet<HostagePickUp>();
            HostageRescue = new HashSet<HostageRescue>();
            ItemDropped = new HashSet<ItemDropped>();
            ItemPickedUp = new HashSet<ItemPickedUp>();
            ItemSaved = new HashSet<ItemSaved>();
            Kills = new HashSet<Kills>();
            PlayerMatchStats = new HashSet<PlayerMatchStats>();
            PlayerPosition = new HashSet<PlayerPosition>();
            PlayerRoundStats = new HashSet<PlayerRoundStats>();
            Refrag = new HashSet<Refrag>();
            RoundItem = new HashSet<RoundItem>();
            RoundStats = new HashSet<RoundStats>();
            Smoke = new HashSet<Smoke>();
            WeaponFired = new HashSet<WeaponFired>();
            WeaponReload = new HashSet<WeaponReload>();
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
        public OverTimeStats OverTimeStats { get; set; }
        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<BombExplosion> BombExplosion { get; set; }
        public ICollection<BombPlant> BombPlant { get; set; }
        public ICollection<BotTakeOver> BotTakeOver { get; set; }
        public ICollection<ConnectDisconnect> ConnectDisconnect { get; set; }
        public ICollection<Damage> Damage { get; set; }
        public ICollection<Decoy> Decoy { get; set; }
        public ICollection<FireNade> FireNade { get; set; }
        public ICollection<Flash> Flash { get; set; }
        public ICollection<Flashed> Flashed { get; set; }
        public ICollection<He> He { get; set; }
        public ICollection<HostageDrop> HostageDrop { get; set; }
        public ICollection<HostagePickUp> HostagePickUp { get; set; }
        public ICollection<HostageRescue> HostageRescue { get; set; }
        public ICollection<ItemDropped> ItemDropped { get; set; }
        public ICollection<ItemPickedUp> ItemPickedUp { get; set; }
        public ICollection<ItemSaved> ItemSaved { get; set; }
        public ICollection<Kills> Kills { get; set; }
        public ICollection<PlayerMatchStats> PlayerMatchStats { get; set; }
        public ICollection<PlayerPosition> PlayerPosition { get; set; }
        public ICollection<PlayerRoundStats> PlayerRoundStats { get; set; }
        public ICollection<Refrag> Refrag { get; set; }
        public ICollection<RoundItem> RoundItem { get; set; }
        public ICollection<RoundStats> RoundStats { get; set; }
        public ICollection<Smoke> Smoke { get; set; }
        public ICollection<WeaponFired> WeaponFired { get; set; }
        public ICollection<WeaponReload> WeaponReload { get; set; }
    }
}
