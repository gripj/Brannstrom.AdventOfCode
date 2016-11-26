namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public class IncrementInstruction : IInstruction
    {
        private readonly int _targetRegistryIndex;

        public IncrementInstruction(int target)
        {
            _targetRegistryIndex = target;
        }

        public uint Calculate(uint[] registers)
        {
            return registers[_targetRegistryIndex] + 1;
        }

        public int Destination() => _targetRegistryIndex;

        public int NextInstruction(int position)
        {
            return position + 1;
        }
    }
}
