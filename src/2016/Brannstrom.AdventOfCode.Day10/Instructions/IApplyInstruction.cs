namespace Brannstrom.AdventOfCode.Day10.Instructions
{
    public interface IApplyInstruction
    {
        bool CanApply(string instruction);
        bool Apply(BotFactory factory, string instruction);
    }
}
