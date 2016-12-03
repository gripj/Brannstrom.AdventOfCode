using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day1.PathCalculators;

namespace Brannstrom.AdventOfCode.Day1
{
    public class MapSolver
    {
        private CardinalDirections _currentFacingDirection;
        private readonly List<Point> _locationsVisited;
        private readonly List<ICalculatePath> _pathCalculators; 
         
        public MapSolver(CardinalDirections startingDirection = CardinalDirections.North)
        {
            _pathCalculators = new List<ICalculatePath>()
            {
                new CalculatePositionWhenGoingEast(),
                new CalculatePositionWhenGoingNorth(),
                new CalculatePositionWhenGoingSouth(),
                new CalculatePositionWhenGoingWest()
            };

            _currentFacingDirection = startingDirection;
            _locationsVisited = new List<Point>() { new Point(0, 0) };
        }

        public void WalkDistance(WalkDirections walkDirection, int distance)
        {
            var newDirection = GetCardinalDirectionBasedOnRotation((int)_currentFacingDirection + (int)walkDirection);

            var nextLocations =
                _pathCalculators
                    .First(x => x.CanCalculate(newDirection))
                    .CalculateNextPositions(_locationsVisited.Last(), distance);

            _locationsVisited.AddRange(nextLocations);

            _currentFacingDirection = newDirection;
        }

        private static CardinalDirections GetCardinalDirectionBasedOnRotation(int rotation)
        {
            var translateDegreesLookup = new Dictionary<int, int>() { { -90, 270 }, { 360, 0 } };
            var newRotation = translateDegreesLookup.ContainsKey(rotation) ? translateDegreesLookup[rotation] : rotation;

            return (CardinalDirections)newRotation;
        }

        public int GetDistanceToTarget() => _locationsVisited.Last().GetDistanceToOrigin();

        public int GetDistanceToFirstLocationVisitedTwice()
        {
            return _locationsVisited
                        .GroupBy(c => c)
                        .SelectMany(group => group.Skip(1))
                        .First()
                        .GetDistanceToOrigin();
        }
    }
}
