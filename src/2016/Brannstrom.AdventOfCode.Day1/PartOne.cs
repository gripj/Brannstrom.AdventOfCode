using System;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartOne
    {
        private MapSolver _mapSolver;

        [SetUp]
        public void SetUp()
        {
            _mapSolver = new MapSolver();
        }

        [Test]
        public void Should_Be_Able_To_Walk_Right()
        {
            _mapSolver.WalkDistance(WalkDirections.Right, 2);
            _mapSolver.GetDistanceToTarget().Should().Be(2);
        }

        [Test]
        public void Should_Be_Able_To_Walk_Left()
        {
            _mapSolver.WalkDistance(WalkDirections.Left, 1);
            _mapSolver.GetDistanceToTarget().Should().Be(1);
        }

        [Test]
        public void Should_Be_Able_To_Walk_MultipleTimes()
        {
            _mapSolver.WalkDistance(WalkDirections.Right, 2);
            _mapSolver.WalkDistance(WalkDirections.Left, 3);
            _mapSolver.GetDistanceToTarget().Should().Be(5);
        }

        [Test]
        [TestCase("R3", WalkDirections.Right, 3)]
        [TestCase("L12", WalkDirections.Left, 12)]
        public void DirectionReader_Should_Read_Single_Instruction(string input, WalkDirections expectedDirection, int expectedDistance)
        {
            var directionsReader = new DirectionReader();

            directionsReader
                .ConvertToWalkDirection(input)
                .Should()
                .Be(new Tuple<WalkDirections, int>(expectedDirection, expectedDistance));
        }

        [Test]
        public void DirectionsReader_Should_Read_Instructions()
        {
            var directionsReader = new DirectionReader();

            directionsReader
                .ReadInstructions()
                .Count
                .Should()
                .BeGreaterThan(0);
        }

        [Test]
        public void Should_Calculate_Distance_Correctly_When_Turning_Around()
        {
            _mapSolver.WalkDistance(WalkDirections.Right, 2);
            _mapSolver.WalkDistance(WalkDirections.Right, 2);
            _mapSolver.WalkDistance(WalkDirections.Right, 2);
            _mapSolver.GetDistanceToTarget().Should().Be(2);
        }

        [Test]
        public void Should_Calculate_Last_Example()
        {
            _mapSolver.WalkDistance(WalkDirections.Right, 5);
            _mapSolver.WalkDistance(WalkDirections.Left, 5);
            _mapSolver.WalkDistance(WalkDirections.Right, 5);
            _mapSolver.WalkDistance(WalkDirections.Right, 3);
            _mapSolver.GetDistanceToTarget().Should().Be(12);
        }

        [Test]
        public void Should_Calculate_Total_Distance()
        {
            var directionsReader = new DirectionReader();

            foreach (var instruction in directionsReader.ReadInstructions())
                _mapSolver.WalkDistance(instruction.Item1, instruction.Item2);

            _mapSolver.GetDistanceToTarget().Should().Be(273);
        }
    }
}
