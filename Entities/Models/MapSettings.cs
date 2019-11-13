using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class MapSettings
    {
        public int Id { get; set; }
        public string Map { get; set; }
        public double ConversionOffsetX { get; set; }
        public double ConversionOffsetY { get; set; }
        public double ConversionScaleX { get; set; }
        public double ConversionScaleY { get; set; }
        public double CropXmin { get; set; }
        public double CropYmin { get; set; }
        public double CropXmax { get; set; }
        public double CropYmax { get; set; }
    }
}
