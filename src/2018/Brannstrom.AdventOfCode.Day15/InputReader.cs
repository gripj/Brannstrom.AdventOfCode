using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day15
{
    public static class InputReader
    {
        public static IEnumerable<string> Read()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day15.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
