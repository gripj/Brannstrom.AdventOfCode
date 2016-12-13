using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12.InstructionExecutors
{
    public class JumpInstruction : IExecuteInstruction
    {
        public bool CanExecute(string instruction) => instruction.Contains("jnz");

        public int Execute(List<Register> registers, string instruction)
        {
            var instructionValue = char.IsDigit(instruction.Substring(4, 1)[0])
                ? int.Parse(instruction.Substring(4, 1))
                : registers.First(x => x.Id == instruction.Substring(4, 1)).Value;

            var value = int.Parse(instruction.Substring(6));

            return instructionValue != 0 ? value : 1;
        }
    }
}
