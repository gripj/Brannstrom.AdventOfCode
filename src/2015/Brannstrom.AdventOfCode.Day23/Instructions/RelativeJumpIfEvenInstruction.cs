namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public class RelativeJumpIfEvenInstruction : IInstruction
    {
        private readonly int _jumpOffset;
        private readonly int _targetRegistryIndex;
        private int _calculatedJumpOffset;

        public RelativeJumpIfEvenInstruction(int targetRegistryIndex, int jumpOffset)
        {
            _targetRegistryIndex = targetRegistryIndex;
            _jumpOffset = jumpOffset;
        }

        public uint Calculate(uint[] registers)
        {
            _calculatedJumpOffset = registers[_targetRegistryIndex] % 2 == 0 ? _jumpOffset : 1;

            return registers[_targetRegistryIndex];
        }

        public int Destination() => _targetRegistryIndex;

        public int NextInstruction(int position)
        {
            return position + _calculatedJumpOffset;
        }
    }
}
