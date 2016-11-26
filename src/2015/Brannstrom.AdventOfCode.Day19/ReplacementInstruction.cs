namespace Brannstrom.AdventOfCode.Day19
{
    public class ReplacementInstruction
    {
        public ReplacementInstruction(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }
        public string To { get; }
    }
}
