using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day12;
using Brannstrom.AdventOfCode.Day12.InstructionExecutors;
using Brannstrom.AdventOfCode.Day23.ToggleInstructions;

namespace Brannstrom.AdventOfCode.Day23
{
    public class AdvancedComputer
    {
        private readonly IEnumerable<IExecuteInstruction> _instructionsExecutors;
        private readonly IEnumerable<IToggleInstruction> _instructionTogglers; 
        private readonly List<Register> _registers;
        private readonly List<string> _instructions;

        public AdvancedComputer(
            IEnumerable<IExecuteInstruction> instructionExecutors, 
            IEnumerable<IToggleInstruction> instructionTogglers,
            List<string> instructions)
        {
            _instructionsExecutors = instructionExecutors;
            _instructionTogglers = instructionTogglers;
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
                    if (value.Length == 1 && !char.IsDigit(value[0]) &&
                        _registers.FirstOrDefault(x => x.Id == value) == null)
                        _registers.Add(new Register(value));
            }
        }

        public void ExecuteInstructions()
        {
            for (var i = 0; i < _instructions.Count();)
            {
                if (_instructions[i].Contains("tgl"))
                {
                    var value = _registers.First(x => x.Id == _instructions[i].Substring(4)).Value;

                    if (i + value > 0 && i + value < _instructions.Count)
                        _instructions[i + value] =
                            _instructionTogglers
                                .First(x => x.CanHandle(_instructions[i + value]))
                                .ToggleInstruction(_instructions[i + value]);

                    i = i + 1;
                }
                else
                {
                    var stepsToMove = _instructionsExecutors
                        .First(x => x.CanExecute(_instructions[i]))
                        .Execute(_registers, _instructions[i]);

                    i = i + stepsToMove;
                }
            }
        }

        public int GetRegisterValue(string id) => _registers.First(x => x.Id == id).Value;
        public void SetRegisterValue(string id, int value) => _registers.First(x => x.Id == id).SetValue(value);
    }
}