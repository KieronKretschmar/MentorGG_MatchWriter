using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TeamStrategy
    {
        public long StrategyId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public long? SuperOrdinateId { get; set; }
    }
}
