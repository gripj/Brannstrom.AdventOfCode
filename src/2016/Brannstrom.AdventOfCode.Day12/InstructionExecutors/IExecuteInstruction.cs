using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day12.InstructionExecutors
{
    public interface IExecuteInstruction
    {
        bool CanExecute(string instruction);
        int Execute(List<Register> registers, string instruction);
    }
}
