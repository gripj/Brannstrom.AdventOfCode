using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day1
{
    public class DirectionReader
    {
        private readonly Dictionary<string, WalkDirections>_walkDirectionLookup = new Dictionary<string, WalkDirections>()
        {
            {"L", WalkDirections.Left},
            {"R", WalkDirections.Right}
        };

        public Tuple<WalkDirections, int> ConvertToWalkDirection(string input)
        {
            return new Tuple<WalkDirections, int>(_walkDirectionLookup[input[0].ToString()],
                Convert.ToInt32(input.Substring(1)));
        }

        public List<Tuple<WalkDirections, int>> ReadInstructions()
        {
            return ReadFile()
                    .First()
                    .Replace(" ", "")
                    .Split(',')
                    .Select(ConvertToWalkDirection)
                    .ToList();
        }

        private static IEnumerable<string> ReadFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day1.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
