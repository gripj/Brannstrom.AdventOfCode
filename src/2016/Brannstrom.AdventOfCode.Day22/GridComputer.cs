using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day22
{
    public class GridComputer
    {
        public long CountViablePairsOfNodes(IEnumerable<Node> nodes)
        {
            return GetAllPermutations(nodes)
                        .ToList()
                        .FindAll(n => (n.Item1.Used > 0 && n.Item2.Avail >= n.Item1.Used) || 
                                        (n.Item2.Used > 0 && n.Item1.Avail >= n.Item2.Used))
                        .Count;
        }

        public int CalculateFewestNumberOfStepsToMoveGoalData(IEnumerable<Node> nodes, int size)
        {
            var goal = nodes
                        .Where(n => n.Y == 0)
                        .Aggregate((first, second) => first.X > second.X ? first : second);

            var emptyNode = nodes.Aggregate((first, second) => first.Avail > second.Avail ? first : second);
            var edgeNodes = nodes.Where(n => n.Used > emptyNode.Avail).ToList();
            var edgeNodeWithSmallestXCoordinate = edgeNodes.Aggregate((first, second) => first.X < second.X ? first : second);

            return (goal.X - 1) * size +
                          emptyNode.Y +
                          edgeNodes.Count + (emptyNode.X - edgeNodeWithSmallestXCoordinate.X) + 1;
        }

        private static IEnumerable<Tuple<T, T>> GetAllPermutations<T>(IEnumerable<T> list)
        {
            var combinations = from pair in list.Select((value, index) => new { value, index })
                               from second in list.Skip(pair.index + 1)
                               select Tuple.Create(pair.value, second);

            return combinations;
        }
    }
}
