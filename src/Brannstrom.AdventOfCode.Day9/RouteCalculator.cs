using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day9
{
    public class RouteCalculator
    {
        private Dictionary<string, Dictionary<string, int>> Distances { get; set; }
        private Dictionary<string[], int> RouteDistances { get; set; }
        private const string DirectionsPattern = @"^(\w+) to (\w+) = (\d+)";
        private IEnumerable<string> Directions { get; set; }

        private void CalculateRoutes(IEnumerable<string> directions)
        {
            Directions = directions;
            Distances = new Dictionary<string, Dictionary<string, int>>();
            RouteDistances = new Dictionary<string[], int>();

            FindRoutes();
            FindRouteDistances();
        }

        private void FindRoutes()
        {
            foreach (var matches in Directions.Select(direction => Regex.Match(direction, DirectionsPattern).Groups))
            {
                if (!Distances.ContainsKey(matches[1].Value))
                    Distances[matches[1].Value] = new Dictionary<string, int>();

                if (!Distances.ContainsKey(matches[2].Value))
                    Distances[matches[2].Value] = new Dictionary<string, int>();

                Distances[matches[1].Value][matches[2].Value] = int.Parse(matches[3].Value);
                Distances[matches[2].Value][matches[1].Value] = int.Parse(matches[3].Value);
            }
        }

        private void FindRouteDistances()
        {
            var routes = GetRoutePermutations(Distances.Keys, Distances.Count);

            foreach (var route in routes.Select(r => r.ToArray()))
                RouteDistances[route] = GetRouteDistance(route);
        }

        public static IEnumerable<IEnumerable<T>> GetRoutePermutations<T>(IEnumerable<T> list, int length)
        {
            return length == 1 ?
                list.Select(t => new T[] { t }) :
                GetRoutePermutations(list, length - 1).SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private int GetRouteDistance(IReadOnlyList<string> route)
        {
            var distance = 0;
            for (var i = 1; i < route.Count; i++)
                distance += Distances[route[i - 1]][route[i]];

            return distance;
        }

        public int CalculateShortestRouteInSantasList()
        {
            CalculateRoutes(ReadDirectionsFromFile());
            return RouteDistances.Values.Min();
        }

        public int CalculateLongestRouteInSantasList()
        {
            CalculateRoutes(ReadDirectionsFromFile());
            return RouteDistances.Values.Max();
        }

        public IEnumerable<string> ReadDirectionsFromFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day9.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
