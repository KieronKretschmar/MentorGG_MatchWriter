using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PlayerMatchStats
    {
        public PlayerMatchStats()
        {
            BombDefused = new HashSet<BombDefused>();
            BombPlant = new HashSet<BombPlant>();
            BotTakeOver = new HashSet<BotTakeOver>();
            ConnectDisconnect = new HashSet<ConnectDisconnect>();
            DamagePlayerMatchStats = new HashSet<Damage>();
            DamagePlayerMatchStatsNavigation = new HashSet<Damage>();
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
            KillsPlayerMatchStats = new HashSet<Kills>();
            KillsPlayerMatchStatsNavigation = new HashSet<Kills>();
            PlayerMatchSmokeStats = new HashSet<PlayerMatchSmokeStats>();
            PlayerPosition = new HashSet<PlayerPosition>();
            PlayerRoundStats = new HashSet<PlayerRoundStats>();
            RoundItem = new HashSet<RoundItem>();
            Smoke = new HashSet<Smoke>();
            StutterStep = new HashSet<StutterStep>();
            WeaponFired = new HashSet<WeaponFired>();
            WeaponReload = new HashSet<WeaponReload>();
        }

        public long MatchId { get; set; }
        public long SteamId { get; set; }
        public byte Team { get; set; }
        public short Kills { get; set; }
        public short Assists { get; set; }
        public short Deaths { get; set; }
        public short Score { get; set; }
        public short Mvps { get; set; }
        public short Hs { get; set; }
        public short Hskills { get; set; }
        public short Shots { get; set; }
        public short Hits { get; set; }
        public short Hsvictim { get; set; }
        public short Hsdeaths { get; set; }
        public short Enemy2K { get; set; }
        public short Enemy3K { get; set; }
        public short Enemy4K { get; set; }
        public short Enemy5K { get; set; }
        public int Damage { get; set; }
        public int DamageVictim { get; set; }
        public short BombPlants { get; set; }
        public short BombExplosions { get; set; }
        public short BombDefuses { get; set; }
        public int MoneyEarned { get; set; }
        public int MoneySpent { get; set; }
        public int MoneyLost { get; set; }
        public short DecoysUsed { get; set; }
        public short FireNadesUsed { get; set; }
        public int FireNadesDamage { get; set; }
        public int FireNadesDamageVictim { get; set; }
        public short FlashesUsed { get; set; }
        public short FlashesSucceeded { get; set; }
        public short FlashVictim { get; set; }
        public short TeamFlashed { get; set; }
        public short TeamFlashVictim { get; set; }
        public short SelfFlashed { get; set; }
        public short HesUsed { get; set; }
        public int HesDamage { get; set; }
        public int HesDamageVictim { get; set; }
        public short SmokesUsed { get; set; }
        public short FirstBloods { get; set; }
        public short FirstBloodVictim { get; set; }
        public double AvgtimeAlive { get; set; }
        public int TeamDamage { get; set; }
        public int TeamKills { get; set; }
        public int EntryKills { get; set; }
        public int EntryKillVictim { get; set; }
        public short Suicides { get; set; }
        public short BombVictim { get; set; }
        public double Hltvrating1 { get; set; }
        public double Hltvrating2 { get; set; }
        public byte RankBeforeMatch { get; set; }
        public byte RankAfterMatch { get; set; }
        public short RealKills { get; set; }
        public short RealDeaths { get; set; }
        public short RealAssists { get; set; }
        public short RealScore { get; set; }
        public short RealMvps { get; set; }

        public MatchStats Match { get; set; }
        public PlayerStats Steam { get; set; }
        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<BombPlant> BombPlant { get; set; }
        public ICollection<BotTakeOver> BotTakeOver { get; set; }
        public ICollection<ConnectDisconnect> ConnectDisconnect { get; set; }
        public ICollection<Damage> DamagePlayerMatchStats { get; set; }
        public ICollection<Damage> DamagePlayerMatchStatsNavigation { get; set; }
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
        public ICollection<Kills> KillsPlayerMatchStats { get; set; }
        public ICollection<Kills> KillsPlayerMatchStatsNavigation { get; set; }
        public ICollection<PlayerMatchSmokeStats> PlayerMatchSmokeStats { get; set; }
        public ICollection<PlayerPosition> PlayerPosition { get; set; }
        public ICollection<PlayerRoundStats> PlayerRoundStats { get; set; }
        public ICollection<RoundItem> RoundItem { get; set; }
        public ICollection<Smoke> Smoke { get; set; }
        public ICollection<StutterStep> StutterStep { get; set; }
        public ICollection<WeaponFired> WeaponFired { get; set; }
        public ICollection<WeaponReload> WeaponReload { get; set; }
    }
}
