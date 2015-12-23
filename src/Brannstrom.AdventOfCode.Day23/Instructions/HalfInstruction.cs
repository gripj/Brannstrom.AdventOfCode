namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public class HalfInstruction : IInstruction
    {
        private readonly int _targetRegistryIndex;

        public HalfInstruction(int target)
        {
            _targetRegistryIndex = target;
        }

        public uint Calculate(uint[] registers)
        {
            return registers[_targetRegistryIndex] / 2;
        }

        public int Destination() => _targetRegistryIndex;

        public int NextInstruction(int position)
        {
            return position + 1;
        }
    }
}
