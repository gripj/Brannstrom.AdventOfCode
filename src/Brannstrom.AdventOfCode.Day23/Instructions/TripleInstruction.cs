namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public class TripleInstruction : IInstruction
    {
        private readonly int _targetRegistryIndex;

        public TripleInstruction(int target)
        {
            _targetRegistryIndex = target;
        }

        public uint Calculate(uint[] registers)
        {
            return registers[_targetRegistryIndex] * 3;
        }

        public int Destination()
        {
            return _targetRegistryIndex;
        }

        public int NextInstruction(int position)
        {
            return position + 1;
        }
    }
}
