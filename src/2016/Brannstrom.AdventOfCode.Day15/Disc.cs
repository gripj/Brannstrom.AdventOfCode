using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Disc
    {
        public int Id { get; }
        public int NumberOfPositions { get; }
        public int StartPosition { get; }

        public Disc(int id, int positions, int startPosition)
        {
            Id = id;
            NumberOfPositions = positions;
            StartPosition = startPosition;
        }

        public static Disc Parse(string input)
        {
            var regex = new Regex("Disc #(\\d+) has (\\d+) positions; at time=0, it is at position (\\d+).");
            var matches = regex.Match(input);

            var id = int.Parse(matches.Groups[1].Value);
            var positions = int.Parse(matches.Groups[2].Value);
            var startPosition = int.Parse(matches.Groups[3].Value);

            return new Disc(id, positions, startPosition);
        }
    }
}
