using System;
using System.Collections.Generic;

namespace TestEntities
{
    public partial class BombDefused
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public long PlayerId { get; set; }
        public int BombTimeLeft { get; set; }

        public MatchStats Match { get; set; }
    }
}
