using System;
using System.Collections.Generic;

namespace TestEntities
{
    public partial class PlayerMatchStats
    {
        public PlayerMatchStats()
        {
            BombDefused = new HashSet<BombDefused>();
            Kills = new HashSet<Kills>();
            Deaths = new HashSet<Kills>();
        }

        public long MatchId { get; set; }
        public long SteamId { get; set; }
        public byte Team { get; set; }
        public short KillCount { get; set; }
        public short Assists { get; set; }
        public short DeathCount { get; set; }
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
        public ICollection<BombDefused> BombDefused { get; set; }
        public ICollection<Kills> Kills { get; set; }
        public ICollection<Kills> Deaths { get; set; }
    }
}
