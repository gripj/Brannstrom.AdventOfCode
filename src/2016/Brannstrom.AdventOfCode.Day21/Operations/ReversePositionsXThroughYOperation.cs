using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class ReversePositionsXThroughYOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction) => instruction.Contains("reverse");

        public string Scramble(string password, string instruction)
        {
            var regex = new Regex("reverse positions (\\d+) through (\\d+)");
            var matches = regex.Match(instruction);

            var x = int.Parse(matches.Groups[1].Value);
            var y = int.Parse(matches.Groups[2].Value);

            return password.Substring(0, x) + 
                    Reverse(password.Substring(x, y-x+1)) + 
                    password.Substring(y + 1);
        }

        public static string Reverse(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        public string Unscramble(string password, string instruction) => Scramble(password, instruction);
    }
}
