using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;

namespace Brannstrom.AdventOfCode.Day12
{
    public class Computer
    {
        private readonly IEnumerable<IExecuteInstruction> _instructionsExecutors;
        private readonly List<Register> _registers;
        private readonly List<string> _instructions;

        public Computer(IEnumerable<IExecuteInstruction> instructionExecutors, List<string> instructions)
        {
            _instructionsExecutors = instructionExecutors;
            _registers = new List<Register>();
            _instructions = instructions;
            CreateRegistersInInstructions();
        }

        private void CreateRegistersInInstructions()
        {
            foreach (var instruction in _instructions)
            {
                var values = instruction.Substring(4).Split(' ');
                foreach (var value in values)
                    if (value.Length == 1 && !char.IsDigit(value[0]) && _registers.FirstOrDefault(x => x.Id == value) == null)
                        _registers.Add(new Register(value));                       
            }
        }

        public void ExecuteInstructions()
        {
            for (var i = 0; i < _instructions.Count(); )
            {
                var stepsToMove = _instructionsExecutors
                                        .First(x => x.CanExecute(_instructions[i]))
                                        .Execute(_registers, _instructions[i]);
                i = i + stepsToMove;
            }
        }

        public int GetRegisterValue(string id) => _registers.First(x => x.Id == id).Value;
        public void SetRegisterValue(string id, int value) => _registers.First(x => x.Id == id).SetValue(value);
    }
}
