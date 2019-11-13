using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class SmokeCategory
    {
        public int CategoryId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public int TargetId { get; set; }
        public byte ThrowType { get; set; }
        public string Setpos { get; set; }
        public int PlayerPosXpixel { get; set; }
        public int PlayerPosYpixel { get; set; }
        public int PlayerPosX { get; set; }
        public int PlayerPosY { get; set; }
        public int PlayerPosZ { get; set; }
        public int PlayerViewX { get; set; }
        public int PlayerViewY { get; set; }
        public int GrenadePosX { get; set; }
        public int GrenadePosY { get; set; }
        public int GrenadePosZ { get; set; }
        public int PlayerPosXmin { get; set; }
        public int PlayerPosYmin { get; set; }
        public int PlayerPosZmin { get; set; }
        public int PlayerViewXmin { get; set; }
        public int PlayerViewYmin { get; set; }
        public int PlayerPosXmax { get; set; }
        public int PlayerPosYmax { get; set; }
        public int PlayerPosZmax { get; set; }
        public int PlayerViewXmax { get; set; }
        public int PlayerViewYmax { get; set; }
        public bool ViewXcontainsPole { get; set; }

        public SmokeTarget Target { get; set; }
    }
}
