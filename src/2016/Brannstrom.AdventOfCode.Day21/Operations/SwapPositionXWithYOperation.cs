using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class SwapPositionXWithYOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction) => instruction.Contains("swap position");

        public string Scramble(string password, string instruction)
        {
            var regex = new Regex("swap position (\\d+) with position (\\d+)");
            var matches = regex.Match(instruction);

            var x = int.Parse(matches.Groups[1].Value);
            var y = int.Parse(matches.Groups[2].Value);

            var passwordAsChars = password.ToCharArray();
            var newY = passwordAsChars[x];
            var newX = passwordAsChars[y];
            passwordAsChars[x] = newX;
            passwordAsChars[y] = newY;

            return new string(passwordAsChars);
        }

        public string Unscramble(string password, string instruction) => Scramble(password, instruction);
    }
}
