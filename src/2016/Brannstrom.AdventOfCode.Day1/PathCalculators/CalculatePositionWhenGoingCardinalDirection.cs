using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day1.PathCalculators
{
    public abstract class CalculatePositionWhenGoingCardinalDirection : ICalculatePath
    {
        protected CardinalDirections _direction;
        protected int _xDirection;
        protected int _yDirection;

        protected CalculatePositionWhenGoingCardinalDirection(CardinalDirections direction, int xDirection, int yDirection)
        {
            _direction = direction;
            _xDirection = xDirection;
            _yDirection = yDirection;
        }

        public bool CanCalculate(CardinalDirections direction) => direction == _direction;

        public List<Point> CalculateNextPositions(Point current, int distance)
        {
            return Enumerable.Range(1, distance)
                        .Select(c => new Point(current.X + c*_xDirection, current.Y + c*_yDirection))
                        .ToList();
        }
    }
}
