using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day12
{
    public class Program
    {
        public string Id { get; }
        public List<Program> Neighbors { get; }

        public Program(string id, List<Program> neighbors = null)
        {
            Id = id;
            Neighbors = neighbors ?? new List<Program>();
        }

        public void AddNeighbor(Program program)
        {
            if (Neighbors.All(x => x.Id != program.Id))
                Neighbors.Add(program);
        }
    }
}
