using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day24
{
    public class Place
    {
        public Location Location { get; }
        public char Name { get; }
        public Dictionary<Place, int> Connections { get; }

        public Place(Location location, char name)
        {
            Location = location;
            Name = name;
            Connections = new Dictionary<Place, int>();
        }

        public void AddConnection(Place loc, int steps)
        {
            Connections.Add(loc, steps);
        }
    }
}
