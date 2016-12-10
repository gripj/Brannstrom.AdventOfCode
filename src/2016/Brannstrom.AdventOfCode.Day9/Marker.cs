using System;
using System.Text;

namespace Brannstrom.AdventOfCode.Day9
{
    public class Marker
    {
        public int NumberOfCharacters { get; }
        public int Repeat { get; }
        public int Length { get; }

        public Marker(string marker)
        {
            var markerParts = marker.Split('x');

            NumberOfCharacters = int.Parse(markerParts[0]);
            Repeat = int.Parse(markerParts[1]);
            Length = marker.Length;
        }

        public static Marker Parse(string input, int startPosition)
        {
            var endPosition = input.IndexOf(")", startPosition, StringComparison.CurrentCultureIgnoreCase);
            var marker = input.Substring(startPosition + 1, endPosition - startPosition - 1);

            return new Marker(marker);
        }

        public string Decompress(string compressedData)
        {
            var decompressedResult = new StringBuilder();

            for (var i = 0; i < Repeat; i++)
                decompressedResult.Append(compressedData);

            return decompressedResult.ToString();
        }
    }
}
