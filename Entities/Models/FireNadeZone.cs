using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class FireNadeZone
    {
        public FireNadeZone()
        {
            FireNadePolygonPoint = new HashSet<FireNadePolygonPoint>();
        }

        public int ZoneId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public byte Team { get; set; }
        public double? Zmin { get; set; }
        public double? Zmax { get; set; }
        public double CenterXingame { get; set; }
        public double CenterYingame { get; set; }
        public int CenterXpixel { get; set; }
        public int CenterYpixel { get; set; }
        public int ParentZoneId { get; set; }
        public int ZoneDepth { get; set; }

        public ICollection<FireNadePolygonPoint> FireNadePolygonPoint { get; set; }
    }
}
