using System.Linq;

namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class RotateOnPositionOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction) => instruction.Contains("rotate based on position");

        public string Scramble(string password, string instruction)
        {
            var letter = instruction.Last();
            var index = password.IndexOf(letter);

            return ShiftRight(password, index);
        }

        private static string ShiftRight(string s, int index)
        {
            s = index >= 4 ? ShiftRight(s, 0) : s;
            var steps = index + 1;
            return s.Substring(s.Length - steps) + s.Substring(0, s.Length - steps);
        }

        public string Unscramble(string password, string instruction)
        {
            var currentTrialPassword = password;
            while (true)
            {
                var test = ShiftLeft(currentTrialPassword, 1);
                if (Scramble(test, instruction).Equals(password))
                    return test;

                currentTrialPassword = test;
            }
        }

        private static string ShiftLeft(string s, int steps)
        {
            return s.Substring(steps, s.Length - steps) + s.Substring(0, steps);
        }
    }
}
