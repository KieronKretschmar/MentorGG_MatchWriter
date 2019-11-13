using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Friends
    {
        public long SteamId { get; set; }
        public long FriendSteamId { get; set; }
        public DateTime FriendsSince { get; set; }
        public bool Steam { get; set; }
        public bool FaceIt { get; set; }
    }
}
