using System.Linq;
using Brannstrom.AdventOfCode.Day1.PathCalculators;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartTwo
    {
        private MapSolver _mapSolver;
        private DirectionReader _reader;
        private readonly Point _origin = new Point(0, 0);

        [SetUp]
        public void SetUp()
        {
            _mapSolver = new MapSolver();
            _reader = new DirectionReader();
        }

        [Test]
        public void Should_Calculate_Positions_When_Going_East()
        {
            var nextPositions = new CalculatePositionWhenGoingEast().CalculateNextPositions(_origin, 2);
            nextPositions.First().X.Should().Be(1);
            nextPositions.First().Y.Should().Be(0);
            nextPositions.Last().X.Should().Be(2);
            nextPositions.Last().Y.Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Positions_When_Going_West()
        {
            var nextPositions = new CalculatePositionWhenGoingWest().CalculateNextPositions(_origin, 2);
            nextPositions.First().X.Should().Be(-1);
            nextPositions.First().Y.Should().Be(0);
            nextPositions.Last().X.Should().Be(-2);
            nextPositions.Last().Y.Should().Be(0);
        }

        [Test]
        public void Should_Calculate_Positions_When_Going_North()
        {
            var nextPositions = new CalculatePositionWhenGoingNorth().CalculateNextPositions(_origin, 2);
            nextPositions.First().X.Should().Be(0);
            nextPositions.First().Y.Should().Be(1);
            nextPositions.Last().X.Should().Be(0);
            nextPositions.Last().Y.Should().Be(2);
        }

        [Test]
        public void Should_Calculate_Positions_When_Going_South()
        {
            var nextPositions = new CalculatePositionWhenGoingSouth().CalculateNextPositions(_origin, 2);
            nextPositions.First().X.Should().Be(0);
            nextPositions.First().Y.Should().Be(-1);
            nextPositions.Last().X.Should().Be(0);
            nextPositions.Last().Y.Should().Be(-2);
        }

        [Test]
        public void Should_Find_First_Location_Visited_Twice()
        {
            var directions =
                "R8, R4, R4, R8"
                .Replace(" ", "")
                .Split(',')
                .Select(_reader.ConvertToWalkDirection)
                .ToList();

            foreach (var direction in directions)
                _mapSolver.WalkDistance(direction.Item1, direction.Item2);

            _mapSolver.GetDistanceToFirstLocationVisitedTwice().Should().Be(4);
        }

        [Test]
        public void Should_Calculate_Distance_To_First_Location_Visited_Twice()
        {
            var directionsReader = new DirectionReader();

            foreach (var instruction in directionsReader.ReadInstructions())
                _mapSolver.WalkDistance(instruction.Item1, instruction.Item2);

            _mapSolver.GetDistanceToFirstLocationVisitedTwice().Should().Be(115);
        }
    }
}
