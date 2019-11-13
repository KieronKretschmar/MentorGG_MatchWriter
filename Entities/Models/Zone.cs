﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Zone
    {
        public int ZoneId { get; set; }
        public string Map { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public double? Zmin { get; set; }
        public double? Zmax { get; set; }
        public double CenterXingame { get; set; }
        public double CenterYingame { get; set; }
        public int CenterXpixel { get; set; }
        public int CenterYpixel { get; set; }
    }
}
