using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ConnectDisconnect
    {
        public long MatchId { get; set; }
        public long ConnectDisconnectId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public int Time { get; set; }
        public bool Connect { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
