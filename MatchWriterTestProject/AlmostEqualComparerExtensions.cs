using System;
using System.Numerics;

namespace MatchWriterTestProject
{
    public static class AlmostEqualComparerExtensions
    {
        public static bool AlmostEquals(this Vector2 left, Vector2 right, double tolerance = 0.01)
        {
            var almostEqualX = Math.Abs(left.X - right.X) <= tolerance;
            var almostEqualY = Math.Abs(left.Y - right.Y) <= tolerance;
            return almostEqualX && almostEqualY;
        }
        public static bool AlmostEquals(this Vector3 left, Vector3 right, double tolerance = 0.01)
        {
            var almostEqualX = Math.Abs(left.X - right.X) <= tolerance;
            var almostEqualY = Math.Abs(left.Y - right.Y) <= tolerance;
            return almostEqualX && almostEqualY;
        }

        public static bool AlmostEquals(this long left, long right, double tolerance = 0.01)
        {
            long diff = Math.Abs(left - right);
            return (diff <= tolerance);
        }
    }
}
