using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Damage
    {
        public Damage()
        {
            Kills = new HashSet<Kills>();
        }

        public long MatchId { get; set; }
        public long DamageId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public long PlayerId { get; set; }
        public double PlayerPosX { get; set; }
        public double PlayerPosY { get; set; }
        public double PlayerPosZ { get; set; }
        public bool IsCt { get; set; }
        public long VictimId { get; set; }
        public double VictimPosX { get; set; }
        public double VictimPosY { get; set; }
        public double VictimPosZ { get; set; }
        public int AmountHealth { get; set; }
        public int AmountHealthPotential { get; set; }
        public int AmountArmor { get; set; }
        public byte HitGroup { get; set; }
        public short Weapon { get; set; }
        public bool Fatal { get; set; }
        public bool TeamAttack { get; set; }
        public long? WeaponFiredId { get; set; }
        public long? HegrenadeId { get; set; }
        public long? FireNadeId { get; set; }
        public long? DecoyId { get; set; }
        public int? PlayerZoneByTeam { get; set; }
        public int? VictimZoneByTeam { get; set; }

        public Decoy Decoy { get; set; }
        public FireNade FireNade { get; set; }
        public He He { get; set; }
        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerMatchStats PlayerMatchStatsNavigation { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public PlayerRoundStats PlayerRoundStatsNavigation { get; set; }
        public RoundStats RoundStats { get; set; }
        public WeaponFired WeaponFired { get; set; }
        public ICollection<Kills> Kills { get; set; }
    }
}
