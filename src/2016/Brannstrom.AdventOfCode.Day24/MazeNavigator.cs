using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day24
{
    public class MazeNavigator
    {
        private int ShortestPathToVisitAllPlaces { get; set; }
        private int ShortestRoundtripDistance { get; set; }

        public char[,] Maze { get; private set; }
        public HashSet<Place> Places { get; private set; } 

        public MazeNavigator(IEnumerable<string> mapRows)
        {
            GenerateMaze(mapRows);
            Navigate();
        }

        public void GenerateMaze(IEnumerable<string> mapRows)
        {
            var mapRowArray = mapRows.ToArray();

            Maze = new char[mapRowArray.Length, mapRowArray[0].Length];
            Places = new HashSet<Place>();

            for (var i = 0; i < mapRowArray.Length; i++)
                for (var j = 0; j < mapRowArray[i].Length; j++)
                {
                    if (char.IsNumber(mapRowArray[i][j]))
                        Places.Add(new Place(new Location(i, j), mapRowArray[i][j]));

                    Maze[i, j] = mapRowArray[i][j];
                }
        }

        private void Navigate()
        {
            FindConnections();
            CalculateShortestPaths();
        }

        private void FindConnections()
        {
            var placesToVisit = Places.ToList();
            for (var i = 0; i < placesToVisit.Count; i++)
            {
                var start = placesToVisit[i];
                for (var j = i + 1; j < placesToVisit.Count; j++)
                {
                    var target = placesToVisit[j];
                    var shortestPath = GetShortestPathUsingBreadthFirst(start.Location, target.Location);
                    foreach (var p in Places)
                    {
                        if (p.Equals(start))
                            p.AddConnection(target, shortestPath);
                        else if (p.Equals(target))
                            p.AddConnection(start, shortestPath);
                    }
                }
            }
        }

        private void CalculateShortestPaths()
        {
            var paths = Places
                            .Permute()
                            .Where(p => p.ElementAt(0).Name.Equals('0'))
                            .ToList();

            ShortestPathToVisitAllPlaces = int.MaxValue;
            ShortestRoundtripDistance = int.MaxValue;

            foreach (var p in paths)
            {
                var places = p.ToList();

                var shortestPathDistance = GetDistance(places);

                places.Add(places[0]);
                var shortestRoundtripDistance = GetDistance(places);

                if (shortestPathDistance < ShortestPathToVisitAllPlaces)
                    ShortestPathToVisitAllPlaces = shortestPathDistance;

                if (shortestRoundtripDistance < ShortestRoundtripDistance)
                    ShortestRoundtripDistance = shortestRoundtripDistance;
            }
        }

        private static int GetDistance(IReadOnlyList<Place> places)
        {
            var distance = 0;

            for (var i = 0; i < places.Count - 1; i++)
                distance += places[i].Connections[places[i + 1]];

            return distance;
        }

        private int GetShortestPathUsingBreadthFirst(Location start, Location goal)
        {
            var closed = new HashSet<Location>();
            var open = new Queue<Location>();
            open.Enqueue(start);
            Location lastLocationInShortestPath = null;

            while (open.Count > 0)
            {
                var current = open.Dequeue();
                if (current.Equals(goal))
                {
                    lastLocationInShortestPath = current;
                    break;
                }
                closed.Add(current);

                foreach (var p in current.GetSurroundingLocations().Where(p => !closed.Contains(p)))
                {
                    closed.Add(p);

                    if (!IsWall(p))
                        open.Enqueue(p);
                }
            }

            return lastLocationInShortestPath.GetDistanceToStart();
        }

        private bool IsWall(Location p) => Maze[p.X, p.Y] == '#';

        public int GetFewestNumberOfStepsToVisitAllPlaces() => ShortestPathToVisitAllPlaces;
        public int GetShortestRoundtripDistance() => ShortestRoundtripDistance;
    }
}
