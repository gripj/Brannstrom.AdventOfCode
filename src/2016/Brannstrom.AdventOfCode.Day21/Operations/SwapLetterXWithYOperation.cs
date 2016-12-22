namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public class SwapLetterXWithYOperation : IScrambleOperation
    {
        public bool CanHandle(string instruction) => instruction.Contains("swap letter");

        public string Scramble(string password, string instruction)
        {
            var parts = instruction.Replace("swap letter ", "").Replace(" with letter ", "");

            var first = parts[0];
            var second = parts[1];

            return password
                    .Replace(first, '#')
                    .Replace(second, first)
                    .Replace('#', second); ;
        }

        public string Unscramble(string password, string instruction) => Scramble(password, instruction);
    }
}
