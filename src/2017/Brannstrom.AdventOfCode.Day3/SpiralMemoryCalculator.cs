using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day3
{
    public class SpiralMemoryCalculator
    {
        public int CalculateStepsToCarryDataToAccessPort(int squareNumber)
        {
            return GetSpiralCoordinates()
                    .ElementAt(squareNumber - 1)
                    .DistanceToOrigin();
        }

        public int CalculateFirstValueLargerThanNumber(int number) => GetSpiralSums().First(value => value > number);

        public IEnumerable<(int, int)> GetSpiralCoordinates()
        {
            var (x, y) = (0, 0);
            var (dx, dy) = (1, 0);

            for (var edgeLength = 1; ; edgeLength++)
                for (var run = 0; run < 2; run++)
                {
                    for (var step = 0; step < edgeLength; step++)
                    {
                        yield return (x, y);
                        (x, y) = (x + dx, y - dy);
                    }
                    (dx, dy) = (-dy, dx);
                }
        }

        public IEnumerable<int> GetSpiralSums()
        {
            var visitedLocations = new Dictionary<(int, int), int> { [(0, 0)] = 1 };

            foreach (var (x, y) in GetSpiralCoordinates())
            {
                var sumOfAdjacentSquares = (
                    from dx in new[] { -1, 0, 1 }
                    from dy in new[] { -1, 0, 1 }
                    let location = (x + dx, y + dy)
                    where visitedLocations.ContainsKey(location)
                    select visitedLocations[location]
                ).Sum();

                visitedLocations[(x, y)] = sumOfAdjacentSquares;
                yield return sumOfAdjacentSquares;
            }
        }
    }

    public static class MathExtensions
    {
        public static int DistanceToOrigin(this (int x, int y) coord) => Math.Abs(coord.x) + Math.Abs(coord.y);
    }
}
