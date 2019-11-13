using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SmokeTarget
    {
        public SmokeTarget()
        {
            SmokeCategory = new HashSet<SmokeCategory>();
        }

        public int TargetId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public int GrenadePosXpixel { get; set; }
        public int GrenadePosYpixel { get; set; }
        public int GrenadePosX { get; set; }
        public int GrenadePosY { get; set; }
        public int GrenadePosZ { get; set; }
        public int GrenadePosXmin { get; set; }
        public int GrenadePosYmin { get; set; }
        public int GrenadePosZmin { get; set; }
        public int GrenadePosXmax { get; set; }
        public int GrenadePosYmax { get; set; }
        public int GrenadePosZmax { get; set; }

        public ICollection<SmokeCategory> SmokeCategory { get; set; }
    }
}
