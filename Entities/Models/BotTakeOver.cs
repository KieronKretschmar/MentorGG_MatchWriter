using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class BotTakeOver
    {
        public long MatchId { get; set; }
        public long BotTakeOverId { get; set; }
        public long PlayerId { get; set; }
        public long BotId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
