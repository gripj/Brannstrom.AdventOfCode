using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartOne
    {
        private LightGrid _grid;

        [SetUp]
        public void SetUp()
        {
            var initialConditions = new List<string>()
            {
                ".#.#.#",
                "...##.",
                "#....#",
                "..#...",
                "#.#..#",
                "####.."
            };
            _grid = new LightGrid(6);
            _grid.Initialize(initialConditions);
        }

        [Test]
        public void Should_Count_Number_Of_Turned_On_Lights_After_100_Frames()
        {
            var input = new EmailFromSanta().Read();
            var lightGrid = new LightGrid(100);
            lightGrid.Initialize(input);

            var game = new GameOfLight(lightGrid);
            var gridAfterAnimation = game.AnimateLights(100);

            game.GetNumberOfLitLights(gridAfterAnimation).Should().Be(1061);
        }

        [Test]
        public void Should_Animate_Based_On_Initial_Conditions()
        {
            var game = new GameOfLight(_grid);
            var gridAfterAnimation = game.AnimateLights(4);

            game.GetNumberOfLitLights(gridAfterAnimation).Should().Be(4);
        }

        [Test]
        public void LightGrid_Should_Be_Set_Up_According_To_Instructions()
        {
            var lights = _grid.Lights.Cast<Light>().ToList();
            lights.Count().Should().Be(36);
            lights.Count(light => light.IsOn).Should().Be(15);
        }

        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(1, 3, 2)]
        [TestCase(5, 2, 3)]
        public void LightGrid_Should_Determine_Amount_Of_Lit_Neighboring_Lights(int x, int y, int expectedAmount)
        {
            _grid.GetAmountOfLitNeighbors(x, y).Should().Be(expectedAmount);
        }
    }
}
