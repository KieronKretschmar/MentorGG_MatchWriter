using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class OverTimeStats
    {
        public long MatchId { get; set; }
        public byte StartT { get; set; }
        public byte StartCt { get; set; }
        public int StartMoney { get; set; }
        public short NumRounds { get; set; }

        public MatchStats MatchStats { get; set; }
    }
}
