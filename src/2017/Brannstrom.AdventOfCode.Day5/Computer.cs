using System.Linq;
using Brannstrom.AdventOfCode.Day5.Instructions;

namespace Brannstrom.AdventOfCode.Day5
{
    public class Computer
    {
        private readonly JumpInstruction[] _instructions;

        public Computer(JumpInstruction[] instructions)
        {
            _instructions = instructions;
        }

        public int CalculateStepsToReachExit()
        {
            var currentPosition = 0;
            var steps = 0;

            while (currentPosition < _instructions.Count())
            {
                steps++;
                currentPosition = currentPosition + _instructions[currentPosition].Jump();
            }

            return steps;
        }
    }
}
