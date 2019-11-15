using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Refrag
    {
        public long MatchId { get; set; }
        public long KillId { get; set; }
        public long RefraggedKillId { get; set; }

        public Kill Kill { get; set; }
        public Kill RefraggedKill { get; set; }
        public MatchStats MatchStats { get; set; }
    }
}
