using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Refrag
    {
        public long MatchId { get; set; }
        public long KillId { get; set; }
        public long RefraggedKillId { get; set; }

        public Kills Kills { get; set; }
        public Kills KillsNavigation { get; set; }
        public MatchStats Match { get; set; }
    }
}
