using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day23.Instructions;

namespace Brannstrom.AdventOfCode.Day23
{
    public class Processor
    {
        private readonly uint[] _registers;
        private readonly IInstruction[] _instructions;
        private int Position { get; set; }

        public Processor(IInstruction[] instructions)
        {
            _instructions = instructions;
            _registers = new uint[2];
        }

        public void SetRegister(int index, uint value)
        {
            _registers[index] = value;
        }

        public uint Execute()
        {
            while (ExecuteInstruction()) { }
            return _registers[1];
        }

        private bool ExecuteInstruction()
        {
            var currentInstruction = _instructions[Position];
            _registers[currentInstruction.Destination()] = currentInstruction.Calculate(_registers);
            Position = currentInstruction.NextInstruction(Position);

            return Position < _instructions.Length;
        }

        public uint CalculateRegistryValue(uint startingValue)
        {
            var instructions = new List<IInstruction>();
            foreach (var line in new Reader().ReadInstructions())
            {
                var reg = line.Substring(4);
                if (line.Contains("hlf"))
                {
                    var index = reg[0] - 'a';
                    instructions.Add(new HalfInstruction(index));

                }
                if (line.Contains("tpl"))
                {
                    var index = reg[0] - 'a';
                    instructions.Add(new TripleInstruction(index));

                }
                if (line.Contains("inc"))
                {
                    var index = reg[0] - 'a';
                    instructions.Add(new IncrementInstruction(index));

                }
                if (line.Contains("jmp"))
                {
                    var jumpOffset = int.Parse(reg);
                    instructions.Add(new UnconditionalRelativeJumpInstruction(jumpOffset));
                }
                if (line.Contains("jie"))
                {
                    var splitted = reg.Split(',');
                    var registerIndex = splitted[0][0] - 'a';
                    var jumpOffset = int.Parse(splitted[1]);
                    instructions.Add(new RelativeJumpIfEvenInstruction(registerIndex, jumpOffset));
                }
                if (line.Contains("jio"))
                {
                    var splitted = reg.Split(',');
                    var registerIndex = splitted[0][0] - 'a';
                    var jumpOffset = int.Parse(splitted[1]);
                    instructions.Add(new RelativeJumpIfOneInstruction(registerIndex, jumpOffset));
                }
            }
            var proc = new Processor(instructions.ToArray());
            proc.SetRegister(0, startingValue);
            return proc.Execute();
        }
    }
}