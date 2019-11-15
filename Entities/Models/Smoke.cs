using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Smoke
    {
        public long MatchId { get; set; }
        public long GrenadeId { get; set; }
        public short Round { get; set; }
        public int Time { get; set; }
        public int Tick { get; set; }
        public long PlayerId { get; set; }
        public double PlayerPosX { get; set; }
        public double PlayerPosY { get; set; }
        public double PlayerPosZ { get; set; }
        public double PlayerViewX { get; set; }
        public double PlayerViewY { get; set; }
        public bool IsCt { get; set; }
        public double GrenadePosX { get; set; }
        public double GrenadePosY { get; set; }
        public double GrenadePosZ { get; set; }
        public int Category { get; set; }
        public int Target { get; set; }
        public byte Result { get; set; }
        public string Trajectory { get; set; }

        public MatchStats MatchStats { get; set; }
        public PlayerMatchStats PlayerMatchStats { get; set; }
        public PlayerRoundStats PlayerRoundStats { get; set; }
        public RoundStats RoundStats { get; set; }
    }
}
