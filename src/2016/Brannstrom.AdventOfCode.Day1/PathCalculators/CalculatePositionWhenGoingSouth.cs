namespace Brannstrom.AdventOfCode.Day1.PathCalculators
{
    public class CalculatePositionWhenGoingSouth: CalculatePositionWhenGoingCardinalDirection
    {
        public CalculatePositionWhenGoingSouth() : base(CardinalDirections.South, 0, -1) { }
    }
}
