using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day9
{
    public class DecompressorV2
    {
        public ulong GetDecompressedLength(string input)
        {
            ulong decompressedLength = 0;
            ulong lengthWithoutMarkers;

            foreach (var markerData in GetMarkers(input, out lengthWithoutMarkers))
                decompressedLength += GetDecompressedLength(markerData.Value) * (ulong)markerData.Key.Repeat;

            return decompressedLength + lengthWithoutMarkers;
        }

        private static Dictionary<Marker, string> GetMarkers(string input, out ulong lengthWithoutMarkers)
        {
            var i = 0;
            lengthWithoutMarkers = 0;
            var markerDataLookup = new Dictionary<Marker, string>();

            while (i < input.Length)
            {
                if (input[i] == '(')
                {
                    var marker = Marker.Parse(input, i);
                    var startPosition = i + marker.Length + 2;
                    var compressedData = input.Substring(startPosition, marker.NumberOfCharacters);

                    markerDataLookup.Add(marker, compressedData);

                    i = startPosition + compressedData.Length;
                    continue;
                }

                lengthWithoutMarkers++;
                i++;
            }

            return markerDataLookup;
        }
    }
}
