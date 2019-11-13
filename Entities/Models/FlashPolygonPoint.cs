using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class FlashPolygonPoint
    {
        public int ZoneId { get; set; }
        public int PointId { get; set; }
        public string Map { get; set; }
        public double Xingame { get; set; }
        public double Yingame { get; set; }
        public int Xpixel { get; set; }
        public int Ypixel { get; set; }

        public FlashZone Zone { get; set; }
    }
}
