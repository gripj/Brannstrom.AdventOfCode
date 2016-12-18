using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
    public class CubicleNavigator
    {
        public List<Cubicle> FindPath(Cubicle start, Cubicle end)
        {
            var visited = new HashSet<Cubicle> { start };

            var shortestPath = new List<Cubicle> { start };
            while (!shortestPath.Any(s => s.Equals(end)))
            {
                var next = shortestPath
                                .SelectMany(s => s.Next())
                                .Distinct()
                                .ToList()
                                .Where(s => !visited.Contains(s))
                                .ToList();

                visited.UnionWith(next);

                shortestPath = next;
            }

            var endCubicle = shortestPath.First(s => s.Equals(end));

            return GetPathToStart(endCubicle);
        }

        private static List<Cubicle> GetPathToStart(Cubicle cubicle)
        {
            var path = new List<Cubicle> { cubicle };
            while (cubicle.Previous != null)
            {
                cubicle = cubicle.Previous;
                path.Add(cubicle);
            }
            path.Reverse();

            return path;
        } 

        public int FindShortestPathToCubicle(Cubicle start, Cubicle end) => FindPath(start, end).Count - 1;

        public HashSet<Cubicle> FindReachable(Cubicle start, int steps)
        {
            var visited = new HashSet<Cubicle> { start };

            var current = new List<Cubicle> { start };
            for (var i = 0; i < steps; i++)
            {
                var next = current
                            .SelectMany(s => s.Next())
                            .Distinct()
                            .ToList()
                            .Where(s => !visited.Contains(s))
                            .ToList();

                visited.UnionWith(next);

                current = next;
            }

            return visited;
        }
    }
}
