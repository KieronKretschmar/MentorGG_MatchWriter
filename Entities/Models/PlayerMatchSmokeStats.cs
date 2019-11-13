using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PlayerMatchSmokeStats
    {
        public long MatchId { get; set; }
        public long PlayerId { get; set; }
        public int Category { get; set; }
        public byte Attempts { get; set; }
        public byte Misses { get; set; }
        public byte Insides { get; set; }
        public byte Gapfrees { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
    }
}
