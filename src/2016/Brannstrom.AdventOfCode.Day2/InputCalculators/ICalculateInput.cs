namespace Brannstrom.AdventOfCode.Day2.InputCalculators
{
    public interface ICalculateInput
    {
        bool CanHandle(char input);
        string CalculateNextKey(string[,] keyPad, string currentKey);
    }
}
