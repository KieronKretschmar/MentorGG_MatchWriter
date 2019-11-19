using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class BombExplosion : IMatchDataEntity
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }

        public MatchStats MatchStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
