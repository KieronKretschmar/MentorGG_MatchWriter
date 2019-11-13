using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PositionZone
    {
        public PositionZone()
        {
            PositionPolygonPoint = new HashSet<PositionPolygonPoint>();
        }

        public int ZoneId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public short Team { get; set; }
        public string VideoUrl { get; set; }
        public double? Zmin { get; set; }
        public double? Zmax { get; set; }
        public double CenterXingame { get; set; }
        public double CenterYingame { get; set; }
        public int CenterXpixel { get; set; }
        public int CenterYpixel { get; set; }
        public int ParentZoneId { get; set; }
        public int ZoneDepth { get; set; }

        public ICollection<PositionPolygonPoint> PositionPolygonPoint { get; set; }
    }
}
