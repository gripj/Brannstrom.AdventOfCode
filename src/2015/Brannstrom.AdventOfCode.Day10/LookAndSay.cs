using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day10
{
    public class LookAndSay
    {
        private static readonly Regex SameDigitPattern = new Regex(@"((.)\2*)");

        public string Do(string input)
        {
            var matches = SameDigitPattern.Matches(input);

            var s = new StringBuilder();
            foreach (var m in matches)
            {
                var match = m as Match;

                var value = match?.Value[0];
                var amount = match?.Value.Length;

                s.Append(amount);
                s.Append(value);
            }

            return s.ToString();
        }

        public int GetLengthOfIterationResult(string input, int iterations)
        {
            return Iterate(input).Take(iterations).Last().Length;
        }

        private IEnumerable<string> Iterate(string input)
        {
            var current = input;
            while (true)
            {
                current = Do(current);
                yield return current;
            }
        }
    }
}
