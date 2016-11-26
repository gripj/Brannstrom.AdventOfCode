namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public interface IInstruction
    {
        int Destination();
        uint Calculate(uint[] registers);
        int NextInstruction(int position);
    }
}
