namespace Brannstrom.AdventOfCode.Day16.DanceMoves
{
    public interface IDanceMove
    {
        bool CanHandleInstruction(string instruction);
        string Move(string instruction, string danceLine);
    }
}
