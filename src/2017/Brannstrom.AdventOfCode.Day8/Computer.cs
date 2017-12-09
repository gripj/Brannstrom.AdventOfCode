using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day8
{
    public class Computer
    {
        public Dictionary<string, int> Registers { get; }
        public int HighestValue { get; private set; }
        private Dictionary<string, Func<int, int, bool>> _conditions;

        public Computer(IEnumerable<string> instructions)
        {
            Registers = new Dictionary<string, int>();
            CreateConditionCheckers();
            ExecuteInstructions(instructions);
        }

        private void CreateConditionCheckers()
        {
            _conditions = new Dictionary<string, Func<int, int, bool>> {
                { "<" , (a, b) => a < b },
                { ">" , (a, b) => a > b },
                { "<=" , (a, b) => a <= b },
                { ">=" , (a, b) => a >= b },
                { "==" , (a, b) => a == b },
                { "!=" , (a, b) => a != b }
            };
        }

        private void ExecuteInstructions(IEnumerable<string> instructions)
        {
            HighestValue = int.MinValue;

            instructions
                .Select(InstructionValues)
                .ToList()
                .ForEach(x =>
                {
                    TryAddRegisters(new [] { x.Target, x.RegistryToEvaluate });

                    if (_conditions[x.ComparisonType](Registers[x.RegistryToEvaluate], x.ComparisonAmount))
                    {
                        if (x.Type == "inc")
                            Registers[x.Target] += x.Amount;
                        else
                            Registers[x.Target] -= x.Amount;

                        if (Registers[x.Target] > HighestValue)
                            HighestValue = Registers[x.Target];
                    }
                });
        }

        private static (string Target, string Type, int Amount, string RegistryToEvaluate, string ComparisonType, int
            ComparisonAmount) InstructionValues(string instruction)
        {
            var parts = instruction.Split(' ');

            return (parts[0], parts[1], int.Parse(parts[2]), parts[4], parts[5], int.Parse(parts[6]));
        }

        private void TryAddRegisters(IEnumerable<string> registerNames)
        {
            foreach (var name in registerNames)
                if (!Registers.ContainsKey(name))
                    Registers.Add(name, 0);
        }
    }
}
