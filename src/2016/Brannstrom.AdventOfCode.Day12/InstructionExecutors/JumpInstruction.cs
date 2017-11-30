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

            int n;
            var value = int.TryParse(instruction.Substring(6), out n)
                ? int.Parse(instruction.Substring(6))
                : registers.First(x => x.Id == instruction.Substring(6)).Value;

            return instructionValue != 0 ? value : 1;
        }
    }
}
