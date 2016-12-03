using System;
using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day1
{
    public interface ICalculatePath
    {
        bool CanCalculate(CardinalDirections direction);
        List<Point> CalculateNextPositions(Point current, int distance);
    }
}
