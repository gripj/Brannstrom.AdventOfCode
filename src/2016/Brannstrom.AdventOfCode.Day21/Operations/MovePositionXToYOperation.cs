using System;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class MovePositionXToYOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction) => instruction.Contains("move");

        public string Scramble(string password, string instruction)
        {
            var values = ExtractValuesFromInstruction(instruction);

            return MoveXToY(password, values.Item1, values.Item2);
        }

        public string Unscramble(string password, string instruction)
        {
            var values = ExtractValuesFromInstruction(instruction);

            return MoveXToY(password, values.Item2, values.Item1);
        }

        private static Tuple<int, int> ExtractValuesFromInstruction(string instruction)
        {
            var regex = new Regex("move position (\\d+) to position (\\d+)");
            var matches = regex.Match(instruction);

            return new Tuple<int, int>(int.Parse(matches.Groups[1].Value), int.Parse(matches.Groups[2].Value));
        }

        private static string MoveXToY(string password, int x, int y)
        {
            return password
                    .Remove(x, 1)
                    .Insert(y, password[x].ToString());
        }
    }
}
