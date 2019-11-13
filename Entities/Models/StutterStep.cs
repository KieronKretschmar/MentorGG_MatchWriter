using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class StutterStep
    {
        public long MatchId { get; set; }
        public long StutterStepId { get; set; }
        public long PlayerId { get; set; }
        public short Round { get; set; }
        public long WeaponFiredId { get; set; }
        public int StutterStartTime { get; set; }
        public int Under34Time { get; set; }
        public short Lag { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public RoundStats RoundStats { get; set; }
        public WeaponFired WeaponFired { get; set; }
    }
}
