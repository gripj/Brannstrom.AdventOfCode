using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12.InstructionExecutors
{
    public class CopyInstruction : IExecuteInstruction
    {
        public bool CanExecute(string instruction) => instruction.Contains("cpy");

        public int Execute(List<Register> registers, string instruction)
        {
            var splitInstructions = instruction.Substring(4).Split(' ');
            var value = splitInstructions[0];
            var targetRegisterId = splitInstructions[1];

            var targetRegister = registers.First(x => x.Id == targetRegisterId);

            if (IsNumber(value))
                targetRegister.SetValue(int.Parse(value));
            else
            {
                var fromRegistry = registers.First(x => x.Id == value);
                targetRegister.SetValue(fromRegistry.Value);
            }

            return 1;
        }

        public static bool IsNumber(string input)
        {
            int n;
            return int.TryParse(input, out n);
        }
    }
}
