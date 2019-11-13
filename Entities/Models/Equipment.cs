using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Equipment
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Source { get; set; }
        public short Type { get; set; }
        public string DisplayName { get; set; }
        public string InGameName { get; set; }
        public double WeaporArmorRatio { get; set; }
        public int Damage { get; set; }
        public double RangeModifier { get; set; }
        public double CycleTime { get; set; }
        public double Penetration { get; set; }
        public int KillAward { get; set; }
        public int MaxPlayerSpeed { get; set; }
        public int ClipSize { get; set; }
        public int Price { get; set; }
        public int Range { get; set; }
        public string WeaponClass { get; set; }
        public double FullAuto { get; set; }
        public double Bullets { get; set; }
        public double TracerFrequency { get; set; }
        public double FlinchVelocityModifierLarge { get; set; }
        public double FlinchVelocityModifierSmall { get; set; }
        public double Spread { get; set; }
        public double InaccuracyCrouch { get; set; }
        public double InaccuracyStand { get; set; }
        public double InaccuracyFire { get; set; }
        public double InaccuracyMove { get; set; }
        public double InaccuracyJump { get; set; }
        public double InaccuracyJumpIntial { get; set; }
        public double InaccuracyLand { get; set; }
        public double InaccuracyLadder { get; set; }
        public double RecoveryTimeCrouch { get; set; }
        public double RecoveryTimeCrouchFinal { get; set; }
        public double RecoveryTimeStand { get; set; }
        public double RecoveryTimeStandFinal { get; set; }
        public double RecoilAngleVariance { get; set; }
        public double RecoilMagnitude { get; set; }
        public double RecoilMagnitudeVariance { get; set; }
        public double SpreadAlt { get; set; }
        public double InaccuracyCrouchAlt { get; set; }
        public double InaccuracyStandAlt { get; set; }
        public double InaccuracyFireAlt { get; set; }
        public double InaccuracyMoveAlt { get; set; }
        public double InaccuracyJumpAlt { get; set; }
        public double InaccuracyLandAlt { get; set; }
        public double InaccuracyLadderAlt { get; set; }
        public double RecoilAngleVarianceAlt { get; set; }
        public double RecoilMagnitudeAlt { get; set; }
        public double RecoilMagnitudeVarianceAlt { get; set; }
        public double MaxPlayerSpeedAlt { get; set; }
        public double TracerFrequencyAlt { get; set; }
        public double ZoomFov { get; set; }
        public double ZoomFovAlt { get; set; }
        public double CycleTimeAlt { get; set; }
        public double CycletimeBurst { get; set; }
        public double TimeInbetweenBurstShots { get; set; }
    }
}
