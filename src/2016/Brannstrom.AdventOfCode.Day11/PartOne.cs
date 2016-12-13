using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Minimum_Number_Of_Steps_To_Bring_All_Items_To_Top_Floor()
        {
            new SolutionSolver()
                .Solve(new InputReader().ReadFile())
                .Should()
                .Be(47);
        }

        [Test]
        public void Should_Consider_Floor_With_No_Generators_As_Safe()
        {
            var items = new List<Item>()
            {
                new Microchip("A"),
                new Microchip("B"),
            };

            new Solution().FloorIsSafe(items).Should().BeTrue();
        }

        [Test]
        public void Should_Consider_Floor_Safe_If_Microchip_Has_Corresponding_Generator()
        {
            var items = new List<Item>()
            {
                new Microchip("A"),
                new Generator("A")
            };

            new Solution().FloorIsSafe(items).Should().BeTrue();
        }

        [Test]
        public void Should_Not_Consider_Floor_Safe_If_Microchip_Is_Not_Grouped_With_Corresponding_Generator()
        {
            var items = new List<Item>()
            {
                new Microchip("2346567"),             
                new Generator("Asdfg")
            };

            new Solution().FloorIsSafe(items).Should().BeTrue();
        }

        [Test]
        public void GetValidElevatorCombinations_Test1()
        {
            var items = new List<Item>()
            {
                new Microchip("Hydrogen"),
                new Generator("Hydrogen"),
                new Microchip("Lithium"),
                new Generator("Lithium")
            };

            new Solution().GetPossibleElevatorCombinations(items).Count.Should().Be(9); 
        }

        [Test]
        public void Should_Create_Floors_From_Arrangement()
        {
            var arrangement = new List<string>()
            {
                "The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.",
                "The second floor contains a hydrogen generator.",
                "The third floor contains a lithium generator.",
                "The fourth floor contains nothing relevant."
            };

            var solution = SolutionSolver.Parse(arrangement);

            var firstFloor = solution.Floors[1];
            firstFloor.Single(x => x is Microchip && x.Element == "hydrogen").Should().NotBeNull();
            firstFloor.Single(x => x is Microchip && x.Element == "lithium").Should().NotBeNull();

            var secondFloorItem = solution.Floors[2].First();
            secondFloorItem.GetType().Should().Be(typeof(Generator));
            secondFloorItem.Element.Should().Be("hydrogen");

            var thirdFloorItem = solution.Floors[3].First();
            thirdFloorItem.GetType().Should().Be(typeof(Generator));
            thirdFloorItem.Element.Should().Be("lithium");

            solution.Floors[4].Should().BeEmpty();
        }
    }
}
