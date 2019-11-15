using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ItemDropped
    {
        public ItemDropped()
        {
            ItemPickedUp = new HashSet<ItemPickedUp>();
        }

        public long MatchId { get; set; }
        public short Round { get; set; }
        public long PlayerId { get; set; }
        public bool IsCt { get; set; }
        public long ItemDroppedId { get; set; }
        public long ItemId { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public short Equipment { get; set; }
        public bool ByDeath { get; set; }
        public bool Gift { get; set; }

        public MatchStats MatchStats { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
        public ICollection<ItemPickedUp> ItemPickedUp { get; set; }
    }
}
