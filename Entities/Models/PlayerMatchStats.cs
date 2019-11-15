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
            Damages = new HashSet<Damage>();
            DamagesReceived = new HashSet<Damage>();
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
            Kills = new HashSet<Kill>();
            Deaths = new HashSet<Kill>();
            PlayerPosition = new HashSet<PlayerPosition>();
            PlayerRoundStats = new HashSet<PlayerRoundStats>();
            RoundItem = new HashSet<RoundItem>();
            Smoke = new HashSet<Smoke>();
            WeaponFired = new HashSet<WeaponFired>();
            WeaponReload = new HashSet<WeaponReload>();
        }

        public long MatchId { get; set; }
        public long SteamId { get; set; }
        public byte Team { get; set; }
        public short KillCount { get; set; }
        public short AssistCount { get; set; }
        public short DeathCount { get; set; }
        public short Score { get; set; }
        public short Mvps { get; set; }
        public short Hs { get; set; }
        public short HsKills { get; set; }
        public short Shots { get; set; }
        public short Hits { get; set; }
        public short HsVictim { get; set; }
        public short HsDeaths { get; set; }
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
        public double AvgTimeAlive { get; set; }
        public int TeamDamage { get; set; }
        public int TeamKills { get; set; }
        public int EntryKills { get; set; }
        public int EntryKillVictim { get; set; }
        public short Suicides { get; set; }
        public short BombVictim { get; set; }
        public double HltvRating1 { get; set; }
        public double HltvRating2 { get; set; }
        public byte RankBeforeMatch { get; set; }
        public byte RankAfterMatch { get; set; }
        public short RealKills { get; set; }
        public short RealDeaths { get; set; }
        public short RealAssists { get; set; }
        public short RealScore { get; set; }
        public short RealMvps { get; set; }

        public MatchStats MatchStats { get; set; }
        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<BombPlant> BombPlant { get; set; }
        public ICollection<BotTakeOver> BotTakeOver { get; set; }
        public ICollection<ConnectDisconnect> ConnectDisconnect { get; set; }
        public ICollection<Damage> Damages { get; set; }
        public ICollection<Damage> DamagesReceived { get; set; }
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
        public ICollection<Kill> Kills { get; set; }
        public ICollection<Kill> Deaths { get; set; }
        public ICollection<PlayerPosition> PlayerPosition { get; set; }
        public ICollection<PlayerRoundStats> PlayerRoundStats { get; set; }
        public ICollection<RoundItem> RoundItem { get; set; }
        public ICollection<Smoke> Smoke { get; set; }
        public ICollection<WeaponFired> WeaponFired { get; set; }
        public ICollection<WeaponReload> WeaponReload { get; set; }
    }
}
