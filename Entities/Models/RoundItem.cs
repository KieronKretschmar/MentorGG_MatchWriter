using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class RoundItem
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public bool IsCt { get; set; }
        public long RoundItemId { get; set; }
        public long ItemId { get; set; }
        public short Equipment { get; set; }

        public MatchStats MatchStats { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
