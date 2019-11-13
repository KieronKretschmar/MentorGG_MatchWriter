using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ItemSaved
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public bool IsCt { get; set; }
        public long ItemSavedId { get; set; }
        public long ItemId { get; set; }
        public short Equipment { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
