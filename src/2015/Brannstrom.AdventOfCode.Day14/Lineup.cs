using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day14
{
    public class Lineup
    {
        public IEnumerable<Reindeer> GetContestants()
        {
            var contestants = new List<Reindeer>();
            foreach (var entry in ReadFromFile())
            {
                var name = entry.Substring(0, entry.IndexOf(" ", StringComparison.Ordinal));

                var numbers = Regex.Matches(entry, "[0-9]+");
                var speed = Convert.ToInt32(numbers[0].Value);
                var timeUntilRest = Convert.ToInt32(numbers[1].Value);
                var restTime = Convert.ToInt32(numbers[2].Value);

                contestants.Add(new Reindeer(name, speed, timeUntilRest, restTime));
            }
            return contestants;
        }

        private static IEnumerable<string> ReadFromFile()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day14.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine();
        }
    }
}
