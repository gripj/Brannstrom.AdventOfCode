namespace Brannstrom.AdventOfCode.Day23.Instructions
{
    public class UnconditionalRelativeJumpInstruction : IInstruction
    {
        private readonly int _targetRegistryIndex;

        public UnconditionalRelativeJumpInstruction(int targetRegistryIndex)
        {
            _targetRegistryIndex = targetRegistryIndex;
        }

        public uint Calculate(uint[] registers)
        {
            return registers[0];
        }

        public int Destination() => 0;

        public int NextInstruction(int position)
        {
            return position + _targetRegistryIndex;
        }
    }
}
