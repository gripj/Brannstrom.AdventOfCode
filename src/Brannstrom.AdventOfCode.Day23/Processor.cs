using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day23.Instructions;

namespace Brannstrom.AdventOfCode.Day23
{
    public class Processor
    {
        private readonly uint[] _registers;
        private readonly IInstruction[] _instructions;
        private int Position { get; set; }

        public Processor(IInstruction[] instructions)
        {
            _instructions = instructions;
            _registers = new uint[2];
        }

        public void SetRegister(int index, uint value)
        {
            _registers[index] = value;
        }

        public uint Execute()
        {
            while (ExecuteInstruction()) { }
            return _registers[1];
        }

        private bool ExecuteInstruction()
        {
            var currentInstruction = _instructions[Position];
            _registers[currentInstruction.Destination()] = currentInstruction.Calculate(_registers);
            Position = currentInstruction.NextInstruction(Position);

            return Position < _instructions.Length;
        }
    }
}