namespace Brannstrom.AdventOfCode.Day21.Operations
{
    public interface IScrambleOperation
    {
        bool CanHandle(string instruction);
        string Scramble(string password, string instruction);
        string Unscramble(string password, string instruction);
    }
}
