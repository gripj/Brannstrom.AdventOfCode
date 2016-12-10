namespace Brannstrom.AdventOfCode.Day8.Instructions
{
    public interface IInstruction
    {
        void Execute(string instruction, Pixel[,] view);
        bool CanHandle(string instruction);
    }
}
