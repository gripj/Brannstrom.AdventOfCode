using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day7
{
    public class Tower
    {
        public List<Program> Programs { get; }

        public Tower(IEnumerable<string> programInformation)
        {
            var programs = programInformation.Select(x => new Program(x)).ToList();

            programs.ForEach(p =>
            {
                var subPrograms = programs.Where(d => p.SubProgramNames.Any(c => c.Equals(d.Name))).ToList();
                p.AssignSubPrograms(subPrograms);
            });

            Programs = programs;
        }

        public (int RequiredWeight, Program program) FindProgramWeightNeededForBalance()
        {
            var program = GetBottomProgram();
            var targetWeight = 0;

            while (!program.IsBalanced())
                (program, targetWeight) = program.GetUnbalancedSubProgram();

            var weightDelta = targetWeight - program.GetTotalWeight();
            var requiredWeight = program.Weight + weightDelta;

            return (requiredWeight, program);
        }

        public Program GetBottomProgram()
        {
            return Programs.Single(p => !Programs.Any(x => x.SubProgramNames.Contains(p.Name)));
        }

        public Program GetProgram(string name) => Programs.Single(x => x.Name == name);
    }
}
