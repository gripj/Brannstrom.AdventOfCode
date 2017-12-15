using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12
{
    public class Village
    {
        public List<Program> Programs { get; } = new List<Program>();
        private Dictionary<string, string> _parentPrograms;

        public Village(IEnumerable<string> pipeInformation)
        {
            foreach (var connection in pipeInformation)
            {
                var programs = connection
                                .Replace("<-> ", "")
                                .Replace(",", "")
                                .Split(' ')
                                .ToList();

                TryCreate(programs);

                var origin = Programs.Single(x => x.Id == programs[0]);

                Programs
                    .Where(x => programs.Skip(1).Contains(x.Id))
                    .ToList()
                    .ForEach(x =>
                    {
                        origin.AddNeighbor(x);
                    });
            }
        }

        public IEnumerable<HashSet<string>> GetConnectedPrograms()
        {
            _parentPrograms = new Dictionary<string, string>();

            foreach (var programA in Programs)
            {
                var rootA = GetRootProgram(programA.Id);
                foreach (var neighbor in programA.Neighbors)
                {
                    var rootB = GetRootProgram(neighbor.Id);
                    if (rootB != rootA)
                        _parentPrograms[rootB] = rootA;
                }
            }

            return
                from program in Programs
                let rootProgram = GetRootProgram(program.Id)
                group program.Id by rootProgram into connections
                select new HashSet<string>(connections.ToArray());
        }

        private void TryCreate(IEnumerable<string> ids)
        {
            foreach (var id in ids)
                if (Programs.All(x => x.Id != id))
                    Programs.Add(new Program(id));
        }

        private string GetRootProgram(string id)
        {
            var rootProgramId = id;

            while (_parentPrograms.ContainsKey(rootProgramId))
                rootProgramId = _parentPrograms[rootProgramId];

            return rootProgramId;
        }
    }
}
