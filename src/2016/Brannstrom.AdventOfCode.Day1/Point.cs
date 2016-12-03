using System;

namespace Brannstrom.AdventOfCode.Day1
{
    public struct Point
    {
        public int Y { get; }
        public int X { get; }

        public Point(int x, int y)
        {
            Y = y;
            X = x;
        }

        public int GetDistanceToOrigin() => Math.Abs(X) + Math.Abs(Y);
    }
}
