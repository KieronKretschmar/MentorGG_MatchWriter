using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PlayerStats
    {
        public PlayerStats()
        {
            PlayerMatchStats = new HashSet<PlayerMatchStats>();
            PlayerRoundStats = new HashSet<PlayerRoundStats>();
        }

        public long SteamId { get; set; }
        public string SteamName { get; set; }
        public string AvatarIcon { get; set; }
        public bool Banned { get; set; }
        public int NumOfVacbans { get; set; }
        public int NumOfGameBans { get; set; }
        public int LastVacBan { get; set; }
        public int LastGameBan { get; set; }
        public int BlameCounter { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public byte Rank { get; set; }
        public DateTime LastRankUpdate { get; set; }
        public long Kills { get; set; }
        public long Assists { get; set; }
        public long Deaths { get; set; }
        public long Score { get; set; }
        public long Mvps { get; set; }
        public long Hs { get; set; }
        public long Hskills { get; set; }
        public long Shots { get; set; }
        public long Hits { get; set; }
        public long Hsvictim { get; set; }
        public long Hsdeaths { get; set; }
        public long Enemy2K { get; set; }
        public long Enemy3K { get; set; }
        public long Enemy4K { get; set; }
        public long Enemy5K { get; set; }
        public long Damage { get; set; }
        public int DamageVictim { get; set; }
        public long BombPlants { get; set; }
        public long BombExplosions { get; set; }
        public long BombDefuses { get; set; }
        public long MoneyEarned { get; set; }
        public long MoneySpent { get; set; }
        public long MoneyLost { get; set; }
        public long DecoysUsed { get; set; }
        public long FireNadesUsed { get; set; }
        public long FireNadesDamage { get; set; }
        public long FireNadesDamageVictim { get; set; }
        public long FlashesUsed { get; set; }
        public long FlashesSucceeded { get; set; }
        public long FlashVictim { get; set; }
        public long TeamFlashed { get; set; }
        public long TeamFlashVictim { get; set; }
        public long SelfFlashed { get; set; }
        public long HesUsed { get; set; }
        public long HesDamage { get; set; }
        public long HesDamageVictim { get; set; }
        public long SmokesUsed { get; set; }
        public long FirstBloods { get; set; }
        public long FirstBloodVictim { get; set; }
        public double AvgtimeAlive { get; set; }
        public long TeamDamage { get; set; }
        public long TeamKills { get; set; }
        public long EntryKills { get; set; }
        public long EntryKillVictim { get; set; }
        public long Suicides { get; set; }
        public long BombVictim { get; set; }
        public double Hltvrating1 { get; set; }
        public double Hltvrating2 { get; set; }

        public ICollection<PlayerMatchStats> PlayerMatchStats { get; set; }
        public ICollection<PlayerRoundStats> PlayerRoundStats { get; set; }
    }
}
