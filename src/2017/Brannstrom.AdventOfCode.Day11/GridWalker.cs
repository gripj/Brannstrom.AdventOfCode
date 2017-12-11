using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day11
{
    public class GridWalker
    {
        private readonly Dictionary<string, (int x, int y, int z)> _deltas;

        public GridWalker()
        {
            _deltas = new Dictionary<string, (int x, int y, int z)>()
            {
                { "n", (0, 1, -1) },
                { "ne", (1, 0, -1) },
                { "se", (1, -1, 0) },
                { "s", (0, -1, 1) },
                { "sw", (-1, 0, 1) },
                { "nw", (-1, 1, 0) }
            };
        }

        public IEnumerable<int> WalkedDistances(string directions)
        {
            return Walk(directions.Split(','))
                    .Select(ToDistance);
        }

        private IEnumerable<(int x, int y, int z)> Walk(IEnumerable<string> directions)
        {
            var (x, y, z) = (0, 0, 0);
            foreach (var direction in directions)
            {
                var delta = _deltas[direction];
                (x, y, z) = (x + delta.x, y + delta.y, z + delta.z);
                yield return (x, y, z);
            }
        }

        private static int ToDistance((int x, int y, int z) coord)
        {
            return (Math.Abs(coord.x) + Math.Abs(coord.y) + Math.Abs(coord.z)) / 2;
        }
    }
}
