using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day17
{
    public class ContainerAnalyzer
    {
        public int GetNumberOfCombinationsContainersCanBeFilled(IEnumerable<string> containerSizes, int litersToFill)
        {
            return GetCombinationsThatFillVolume(containerSizes, litersToFill).Count();
        }

        public int GetNumberOfCombinationsForMinimumAmountOfContainers(IEnumerable<string> containerSizes, int litersToFill)
        {
            var possibleCombinations = GetCombinationsThatFillVolume(containerSizes, litersToFill);
            var smallestNumberOfCombinations = possibleCombinations.Min(x => x.Count);

            return possibleCombinations.Count(x => x.Count == smallestNumberOfCombinations);
        }

        private static List<List<int>> GetCombinationsThatFillVolume(IEnumerable<string> containerSizes, int litersToFill)
        {
            var availableVolumes = containerSizes.Select(int.Parse).ToList();

            var numberOfCombinations = 1 << availableVolumes.Count;
            var combinations = Enumerable.Range(0, numberOfCombinations).Select(i => GetCombination(availableVolumes, i));

            return combinations.Where(c => c.Sum() == litersToFill).ToList();
        }

        private static List<int> GetCombination(IEnumerable<int> availableVolumes, int number)
        {
            var bits = new BitArray(new [] { number });
            return availableVolumes.Where((x, y) => bits[y]).ToList();
        }
    }
}
