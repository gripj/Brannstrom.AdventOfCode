using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day7
{
    public class Program
    {
        public string Name { get; }
        public int Weight { get; }
        public List<string> SubProgramNames { get; }
        public List<Program> SubPrograms { get; private set; }

        public Program(string program)
        {
            Weight = Convert.ToInt32(Regex.Match(program, @"([0-9])+").Value);
            Name = program.Substring(0, program.IndexOf(' '));
            SubProgramNames = program.Contains("->")
                ? program.Substring(program.IndexOf('>') + 2).Replace(" ", "").Split(',').ToList()
                : new List<string>();
        }

        public void AssignSubPrograms(List<Program> subPrograms) => SubPrograms = subPrograms;

        public int GetTotalWeight() => Weight + SubPrograms.Sum(x => x.GetTotalWeight());

        public bool IsBalanced() => SubPrograms.GroupBy(x => x.GetTotalWeight()).Count() == 1;

        public (Program program, int targetWeight) GetUnbalancedSubProgram()
        {
            var groups = SubPrograms.GroupBy(x => x.GetTotalWeight());
            var unbalancedSubProgram = groups.First(x => x.Count() == 1).First();
            var targetWeight = groups.First(x => x.Count() > 1).Key;

            return (unbalancedSubProgram, targetWeight);
        }
    }
}
