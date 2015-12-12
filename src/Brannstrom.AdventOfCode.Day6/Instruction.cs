using System;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day6
{
    public class Instruction
    {
        public InstructionType Type { get; set; }
        public int FromX { get; set; }
        public int ToX { get; set; }
        public int FromY { get; set; }
        public int ToY { get; set; }

        public Instruction(string instruction)
        {
            SetInstructionType(instruction);

            char[] separators = { 't', 'u', 'r', 'n', 'o', 'f', 'g', 'l', 'e', 'h', ',' };
            var lightPositions = instruction.Replace(" ", "").Split(separators).Where(x => !x.Equals("")).ToList();

            FromX = Convert.ToInt32(lightPositions[0]);
            ToX = Convert.ToInt32(lightPositions[2]);
            FromY = Convert.ToInt32(lightPositions[1]);
            ToY = Convert.ToInt32(lightPositions[3]);
        }

        public Instruction() {}

        private void SetInstructionType(string instruction)
        {
            if (instruction.Contains("turn on"))
                Type = InstructionType.On;
            else if (instruction.Contains("turn off"))
                Type = InstructionType.Off;
            else if (instruction.Contains("toggle"))
                Type = InstructionType.Toggle;
        }
    }
}
