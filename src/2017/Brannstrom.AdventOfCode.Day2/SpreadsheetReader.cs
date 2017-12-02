using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day2
{
    public static class SpreadsheetReader
    {
        public static int[][] ReadSpreadsheet()
        {
            return ReadFile().Select(x => x.ToNumbersArray()).ToArray();
        }

        private static IEnumerable<string> ReadFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day2.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }

        public static int[] ToNumbersArray(this string @string)
        {
            return @string
                    .Replace('\t', ' ')
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
        }
    }
}
