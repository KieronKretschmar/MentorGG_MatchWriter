using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class DemoStats
    {
        public DemoStats()
        {
            MatchStats = new HashSet<MatchStats>();
        }

        public long DemoId { get; set; }
        public long? MatchId { get; set; }
        public string DemoUrl { get; set; }
        public string DemoFileName { get; set; }
        public string DemoFilePath { get; set; }
        public string DemoFileHashMd5 { get; set; }
        public DateTime MatchDate { get; set; }
        public short Status { get; set; }
        public short Attempts { get; set; }
        public DateTime DemoAnalyzerVersion { get; set; }
        public DateTime PyAnalyzerVersion { get; set; }
        public string FaceItMatchId { get; set; }
        public long UploadedBy { get; set; }
        public short UploadType { get; set; }
        public string Source { get; set; }

        public ICollection<MatchStats> MatchStats { get; set; }
    }
}
