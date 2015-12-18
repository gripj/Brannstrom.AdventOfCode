using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day16
{
    public class Sue
    {
        private const string NumberPattern = @"\d+";

        public Sue(string information)
        {
            Id = Convert.ToInt32(Regex.Match(information, NumberPattern).Value);
            ExtractCompounds(information);
        }

        private void ExtractCompounds(string information)
        {
            Compounds = new Dictionary<string, int>();
            var parts = information.Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 2; i < parts.Length; i += 2)
                Compounds.Add(parts[i], int.Parse(parts[i + 1]));
        }

        public int Id { get; set; }
        public Dictionary<string, int> Compounds { get; set; }

        public bool HasCompounds(Dictionary<string, int> compounds)
        {
            return Compounds.All(c => compounds[c.Key] == c.Value);
        }

        public bool HasCompoundsWhenSomeValuesIndicateRanges(Dictionary<string, int> found)
        {
            var greaterThanCompounds = new List<string> { "cats", "trees" };
            var fewerThanCompounds = new List<string> { "pomeranians", "goldfish" };

            return Compounds.All(c =>
            {
                if (greaterThanCompounds.Contains(c.Key))
                    return found[c.Key] < c.Value;

                if (fewerThanCompounds.Contains(c.Key))
                    return found[c.Key] > c.Value;

                return found[c.Key] == c.Value;
            });
        }
    }
}
