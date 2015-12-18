using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day16
{
    public class Reader
    {
        public IEnumerable<string> ReadList()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day16.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }

        public Dictionary<string, int> GetKnownCompounds()
        {
            return new Dictionary<string, int>
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 }
            };
        } 
    }
}
