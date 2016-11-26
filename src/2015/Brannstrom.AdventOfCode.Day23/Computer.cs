using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day23.Instructions;

namespace Brannstrom.AdventOfCode.Day23
{
    public class Computer
    {
        public uint CalculateRegistryValue(uint startingValue)
        {
            var instructions = new List<IInstruction>();
            foreach (var line in new Reader().ReadInstructions())
            {
                var registry = line.Substring(4);
                if (line.Contains("hlf"))
                {
                    var index = registry[0] - 'a';
                    instructions.Add(new HalfInstruction(index));
                }
                if (line.Contains("tpl"))
                {
                    var index = registry[0] - 'a';
                    instructions.Add(new TripleInstruction(index));

                }
                if (line.Contains("inc"))
                {
                    var index = registry[0] - 'a';
                    instructions.Add(new IncrementInstruction(index));

                }
                if (line.Contains("jmp"))
                {
                    var jumpOffset = int.Parse(registry);
                    instructions.Add(new UnconditionalRelativeJumpInstruction(jumpOffset));
                }
                if (line.Contains("jie"))
                {
                    var split = registry.Split(',');
                    var registerIndex = split[0][0] - 'a';
                    var jumpOffset = int.Parse(split[1]);
                    instructions.Add(new RelativeJumpIfEvenInstruction(registerIndex, jumpOffset));
                }
                if (line.Contains("jio"))
                {
                    var split = registry.Split(',');
                    var registerIndex = split[0][0] - 'a';
                    var jumpOffset = int.Parse(split[1]);
                    instructions.Add(new RelativeJumpIfOneInstruction(registerIndex, jumpOffset));
                }
            }
            var processor = new Processor(instructions.ToArray());
            processor.SetRegister(0, startingValue);
            return processor.Execute();
        }
    }
}
