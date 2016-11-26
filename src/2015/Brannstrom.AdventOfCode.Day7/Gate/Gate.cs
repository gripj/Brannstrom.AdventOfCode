using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day7.Gate
{
    public abstract class Gate
    {
        public List<string> Inputs;
        public string Output;

        abstract public ushort Value(Dictionary<string, ushort> signals);

        public bool IsConstant(string input)
        {
            ushort value;
            return ushort.TryParse(input, out value);
        }

        public bool HasValue(Dictionary<string, ushort> signals)
        {
            return Inputs.Where(i => !IsConstant(i)).All(signals.ContainsKey);
        }

        public ushort GetValue(Dictionary<string, ushort> signals, int index)
        {
            var input = Inputs[index];
            return IsConstant(input) ? ushort.Parse(input) : signals[input];
        }

        public static Gate Parse(string instruction)
        {
            var parts = instruction.Split(' ');

            if (instruction.Contains("NOT"))
                return new Not
                {
                    Inputs = new List<string> { parts[1] },
                    Output = parts[3]
                };

            else if (instruction.Contains("AND"))
                return new And
                {
                    Inputs = new List<string> { parts[0], parts[2] },
                    Output = parts[4]
                };

            else if (instruction.Contains("OR"))
                return new Or
                {
                    Inputs = new List<string> { parts[0], parts[2] },
                    Output = parts[4]
                };

            else if (instruction.Contains("LSHIFT"))
                return new LShift
                {
                    Amount = ushort.Parse(parts[2]),
                    Inputs = new List<string> { parts[0] },
                    Output = parts[4]
                };

            else if (instruction.Contains("RSHIFT"))
                return new RShift
                {
                    Amount = ushort.Parse(parts[2]),
                    Inputs = new List<string> { parts[0] },
                    Output = parts[4]
                };

            return new Wire
            {
                Inputs = new List<string> { parts[0] },
                Output = parts[2]
            };
        }
    }
}