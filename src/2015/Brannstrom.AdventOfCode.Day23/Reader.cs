using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day23
{
    public class Reader
    {
        public IEnumerable<string> ReadInstructions()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day23.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
