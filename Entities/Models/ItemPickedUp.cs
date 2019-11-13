using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ItemPickedUp
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public bool IsCt { get; set; }
        public long ItemPickedUpId { get; set; }
        public long ItemId { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public short Equipment { get; set; }
        public long? ItemDroppedId { get; set; }
        public bool Gift { get; set; }
        public bool Buy { get; set; }

        public ItemDropped ItemDropped { get; set; }
        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
