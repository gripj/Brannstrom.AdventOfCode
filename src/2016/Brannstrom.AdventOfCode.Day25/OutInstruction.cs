using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;

namespace Brannstrom.AdventOfCode.Day25
{
    public class OutInstruction : IExecuteInstruction
    {
        public bool CanExecute(string instruction) => instruction.Contains("out");

        public int Execute(List<Register> registers, string instruction)
        {
            var input = instruction.Split(' ')[1];

            var value = IsNumber(input)
                ? int.Parse(input)
                : registers.First(x => x.Id == input).Value;
            
            return value;
        }

        public static bool IsNumber(string input)
        {
            int n;
            return int.TryParse(input, out n);
        }
    }
}
