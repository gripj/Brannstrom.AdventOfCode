using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day24
{
    public class Location
    {
        public int X { get; }
        public int Y { get; }
        public Location Previous { get; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Location(int x, int y, Location previous) : this(x, y)
        {
            Previous = previous;
        }

        public int GetDistanceToStart()
        {
            return 1 + Previous?.GetDistanceToStart() ?? 0;
        }

        public List<Location> GetSurroundingLocations()
        {
            var surroundingLocations = new List<Location>
            {
                new Location(X + 1, Y, this),
                new Location(X - 1, Y, this),
                new Location(X, Y + 1, this),
                new Location(X, Y - 1, this)
            };

            return surroundingLocations;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Location;

            return (other != null) && (X.Equals(other.X) && Y.Equals(other.Y));
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
