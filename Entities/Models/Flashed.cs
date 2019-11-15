using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Flashed
    {
        public long MatchId { get; set; }
        public long GrenadeId { get; set; }
        public long VictimId { get; set; }
        public short Round { get; set; }
        public double VictimPosX { get; set; }
        public double VictimPosY { get; set; }
        public double VictimPosZ { get; set; }
        public double VictimViewX { get; set; }
        public double VictimViewY { get; set; }
        public bool IsCt { get; set; }
        public int TimeFlashed { get; set; }
        public bool TeamAttack { get; set; }
        public long? AssistedKillId { get; set; }
        public int? TimeUntilAssistedKill { get; set; }
        public int AngleToCrosshair { get; set; }

        public Flash Flash { get; set; }
        public Kill AssistedKill { get; set; }
        public MatchStats MatchStats { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
