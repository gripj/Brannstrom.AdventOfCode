namespace Brannstrom.AdventOfCode.Day23.ToggleInstructions
{
    public interface IToggleInstruction
    {
        bool CanHandle(string instruction);
        string ToggleInstruction(string instruction);
    }
}
