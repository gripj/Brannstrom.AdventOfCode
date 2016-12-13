using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day11
{
    public class SolutionSolver
    {
        public int Solve(IEnumerable<string> floorArrangements)
        {
            var solution = Parse(floorArrangements);
            return FindMinimumNumberOfStepsToTopFloor(solution);
        }

        private static int FindMinimumNumberOfStepsToTopFloor(Solution firstStep)
        {
            var currentQueue = new List<Solution> { firstStep };

            while (currentQueue.Count != 0)
            {
                var nextSolutions = new List<Solution>();
                foreach (var solution in currentQueue)
                {
                    if (solution.AllItemsAreOnTopFloor())
                        return solution.Steps;

                    var nextSteps = solution.RideInElevator();
                    nextSolutions.AddRange(nextSteps);
                }

                currentQueue = nextSolutions;
            }

            throw new Exception("Solution was not found.");
        }

        public static Solution Parse(IEnumerable<string> floorArrangements)
        {
            var solution = new Solution();

            foreach (var arrangement in floorArrangements)
            {
                var floorNumber = GetFloorNumber(arrangement);
                var startOfItemsIndex = arrangement.IndexOf("contains") + 8;
                var itemsInArrangement = arrangement.Substring(startOfItemsIndex);
                var itemParts = itemsInArrangement.Replace("and a", ", and a").Replace(",,", ",").Split(',');

                foreach (var part in itemParts)
                {
                    var phrasesToReplace = new List<string>() {"an ", "a ", "-compatible microchip", " generator", "and", " ", "."};

                    var element = phrasesToReplace.Aggregate(part, (i, j) => i.Replace(j, ""));

                    if (part.Contains("microchip"))
                        solution.Floors[floorNumber].Add(new Microchip(element));

                    else if (part.Contains("generator"))
                        solution.Floors[floorNumber].Add(new Generator(element));
                }
            }

            return solution;
        }

        private static int GetFloorNumber(string arrangement)
        {
            foreach (var n in _floorNumberLookup)
                if (arrangement.Contains(n.Key))
                    return n.Value;

            throw new Exception("Floor number was not found.");
        }

        private static Dictionary<string, int> _floorNumberLookup => new Dictionary<string, int>()
                {
                    { "first", 1 }, { "second", 2 }, { "third", 3 }, { "fourth", 4 }
                };
    }
}
