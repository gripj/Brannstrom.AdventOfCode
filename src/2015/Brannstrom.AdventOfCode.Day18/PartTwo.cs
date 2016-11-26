using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartTwo
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
            _grid.LockLights(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 5),
                new Tuple<int, int>(5, 0),
                new Tuple<int, int>(5, 5)
            });
        }

        [Test]
        public void Should_Count_Number_Of_Lights_Turned_On_After_100_Animations_With_Stuck_Lights()
        {
            var input = new EmailFromSanta().Read();
            var lightGrid = new LightGrid(100);
            lightGrid.Initialize(input);
            lightGrid.LockLights(new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 99),
                new Tuple<int, int>(99, 0),
                new Tuple<int, int>(99, 99)
            });

            var game = new GameOfLight(lightGrid);
            var finishedPart1Board = game.AnimateLights(100);

            game.GetNumberOfLitLights(finishedPart1Board).Should().Be(1006);
        }

        [Test]
        public void Should_Animate_With_Locked_Lights()
        {
            var game = new GameOfLight(_grid);
            var lightsAfterAnimation = game.AnimateLights(5);

            game.GetNumberOfLitLights(lightsAfterAnimation).Should().Be(17);
        }

        [Test]
        public void LightGrid_Should_Be_Set_Up_According_To_Instructions_With_Locked_Lights()
        {
            var lights = _grid.Lights.Cast<Light>().ToList();
            lights.Count().Should().Be(36);
            lights.Count(light => light.IsOn).Should().Be(17);
        }
    }
}
