using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day3
{
    public class Elf
    {
        public string GetDirections()
        {
            return ReadDirectionsList().First();
        }

        private IEnumerable<string> ReadDirectionsList()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day3.input.txt"))
            using (var reader = new StreamReader(stream)) 
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        } 
    }
}
