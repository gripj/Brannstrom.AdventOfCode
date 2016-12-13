using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12.InstructionExecutors
{
    public class DecreaseInstruction : IExecuteInstruction
    {
        public bool CanExecute(string instruction) => instruction.Contains("dec");

        public int Execute(List<Register> registers, string instruction)
        {
            var targetRegister = registers.First(x => x.Id == instruction.Substring(4));
            targetRegister.SetValue(targetRegister.Value - 1);

            return 1;
        }
    }
}
