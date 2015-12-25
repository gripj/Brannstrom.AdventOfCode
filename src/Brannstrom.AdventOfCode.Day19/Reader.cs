using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day19
{
    public class Reader
    {
        public IEnumerable<ReplacementInstruction> GetInstructions()
        {
            return ReadFile()
                .Select(MakeInstruction)
                .Where(instruction => instruction != null)
                .ToList();
        }

        public string GetMolecule()
        {
            return ReadFile().Last();
        }

        public IEnumerable<string> ReadFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day19.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }

        public ReplacementInstruction MakeInstruction(string input)
        {
            var parts = input.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 1 ? 
                new ReplacementInstruction(parts[0].Trim(), parts[1].Trim()) : 
                null;
        }
    }
}
