using System;

namespace Brannstrom.AdventOfCode.Day20
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int DistanceToOrigin() => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        public override bool Equals(object obj)
        {
            var other = (obj as Vector);

            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }
    }
}
