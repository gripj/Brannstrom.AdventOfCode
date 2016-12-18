using System;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
    public class Cubicle
    {
        public int X { get; }
        public int Y { get; }
        private int FavoriteNumber { get; }

        public Cubicle Previous { get; }

        public Cubicle(int x, int y, int favoriteNumber)
        {
            X = x;
            Y = y;
            FavoriteNumber = favoriteNumber;
        }

        public Cubicle(int x, int y, int favoriteNumber, Cubicle previous)
        {
            X = x;
            Y = y;
            FavoriteNumber = favoriteNumber;
            Previous = previous;
        }

        public bool IsOpenSpace()
        {
            if (X < 0 || Y < 0)
                return false;

            var magicNumber = (X*X + 3*X + 2*X*Y + Y + Y*Y) + FavoriteNumber;
            var binaryRepresentation = Convert.ToString(magicNumber, 2);

            return binaryRepresentation.Count(x => x == ('1')) % 2 == 0;
        }

        public Cubicle[] Next()
        {
            var surroundingCubicles = new[] {
                new Cubicle(X - 1, Y, FavoriteNumber, this),
                new Cubicle(X + 1, Y, FavoriteNumber, this),
                new Cubicle(X, Y - 1, FavoriteNumber, this),
                new Cubicle(X, Y + 1, FavoriteNumber, this)
            };

            return surroundingCubicles
                    .Where(s => s.IsOpenSpace())
                    .ToArray();
        }

        public override int GetHashCode() => X^Y;

        public override bool Equals(object obj)
        {
            var other = obj as Cubicle;

            return X == other.X && Y == other.Y;
        }
    }
}
