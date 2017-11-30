using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void MazeGenerator_Should_Generate_Maze()
        {
            var mapRows = new List<string>()
            {
                "###########",
                "#0.1.....2#",
                "#.#######.#",
                "#4.......3#",
                "###########"
            };

            var mazeNavigator = new MazeNavigator(mapRows);

            mazeNavigator.Maze.GetLength(0).Should().Be(5);
            mazeNavigator.Maze.GetLength(1).Should().Be(11);
            mazeNavigator.Places.Count.Should().Be(5);
        }

        [Test]
        public void Location_Should_Get_Distance_To_Start()
        {
            var start = new Location(0, 0);
            var visitedFirst = new Location(1, 0, start);
            var visitedSecond = new Location(2, 0, visitedFirst);
            var visitedLast = new Location(2, 1, visitedSecond);

            visitedLast.GetDistanceToStart().Should().Be(3);
        }

        [Test]
        public void Should_Get_Fewest_Number_Of_Steps_To_Visit_All_Places_In_Example()
        {
            var mapRows = new List<string>()
            {
                "###########",
                "#0.1.....2#",
                "#.#######.#",
                "#4.......3#",
                "###########"
            };

            var mazeNavigator = new MazeNavigator(mapRows);

            mazeNavigator
                .GetFewestNumberOfStepsToVisitAllPlaces()
                .Should()
                .Be(14);
        }

        [Test]
        public void Should_Get_Fewest_Number_Of_Steps_To_Visit_All_Places()
        {
            var mapRows = new InputReader().ReadFile();

            new MazeNavigator(mapRows)
                .GetFewestNumberOfStepsToVisitAllPlaces()
                .Should()
                .Be(470);
        }
    }
}
