using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PlayerPosition
    {
        public long MatchId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public long PlayerId { get; set; }
        public double PlayerPosX { get; set; }
        public double PlayerPosY { get; set; }
        public double PlayerPosZ { get; set; }
        public double PlayerViewX { get; set; }
        public double PlayerViewY { get; set; }
        public double PlayerVeloX { get; set; }
        public double PlayerVeloY { get; set; }
        public double PlayerVeloZ { get; set; }
        public short Weapon { get; set; }

        public MatchStats Match { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
