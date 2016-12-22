using System;

namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class RotateNumberOfStepsOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction)
            => instruction.Contains("rotate right") || instruction.Contains("rotate left");

        public string Scramble(string password, string instruction)
        {
            var values = GetValues(instruction);
            var direction = values.Item1;
            var steps = values.Item2;

            return direction == "left" ? 
                ShiftLeft(password, steps) : 
                ShiftRight(password, steps);
        }

        private static Tuple<string, int> GetValues(string instruction)
        {
            var parts = instruction
                .Replace("rotate ", "")
                .Replace(" steps", "")
                .Replace(" step", "")
                .Split(' ');

            return new Tuple<string, int>(parts[0], int.Parse(parts[1]));
        }

        private static string ShiftLeft(string s, int steps)
        {
            return s.Substring(steps, s.Length - steps) + s.Substring(0, steps);
        }

        private static string ShiftRight(string s, int steps)
        {
            return s.Substring(s.Length - steps) + s.Substring(0, s.Length - steps);
        }

        public string Unscramble(string password, string instruction)
        {
            var values = GetValues(instruction);
            var direction = values.Item1;
            var steps = values.Item2;

            return direction == "right" ?
                ShiftLeft(password, steps) :
                ShiftRight(password, steps);
        }
    }
}
