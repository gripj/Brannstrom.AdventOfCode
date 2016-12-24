using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_Fewest_Number_Of_Steps_Needed_For_Simple_Case_Roundtrip()
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
                .GetShortestRoundtripDistance()
                .Should()
                .Be(20);
        }

        [Test]
        public void Should_Get_Fewest_Number_Of_Steps_Needed_For_Roundtrip()
        {
            var mapRows = new InputReader().ReadFile();

            new MazeNavigator(mapRows)
                .GetShortestRoundtripDistance()
                .Should()
                .Be(720);
        }
    }
}
