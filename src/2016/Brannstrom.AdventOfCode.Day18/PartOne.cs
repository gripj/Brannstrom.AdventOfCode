using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day18.TrapRules;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartOne
    {
        private const bool IsSafe = true;

        [Test]
        public void Left_And_Center_Trap_Tiles_Should_Generate_Trap()
        {
            var tiles = new List<Tile>()
            {
                new Tile(!IsSafe),
                new Tile(!IsSafe),
                new Tile(IsSafe)
            };

            new LeftAndCenterAreTrapsRule().IsTrap(tiles).Should().BeTrue();
        }

        [Test]
        public void Center_And_Right_Trap_Tiles_Should_Generate_Trap()
        {
            var tiles = new List<Tile>()
            {
                new Tile(IsSafe),
                new Tile(!IsSafe),
                new Tile(!IsSafe)
            };

            new CenterAndRightAreTrapsRule().IsTrap(tiles).Should().BeTrue();
        }

        [Test]
        public void Left_Trap_Tile_Should_Generate_Trap()
        {
            var tiles = new List<Tile>()
            {
                new Tile(!IsSafe),
                new Tile(IsSafe),
                new Tile(IsSafe)
            };

            new LeftTileIsTrapRule().IsTrap(tiles).Should().BeTrue();
        }

        [Test]
        public void Right_Trap_Tile_Should_Generate_Trap()
        {
            var tiles = new List<Tile>()
            {
                new Tile(IsSafe),
                new Tile(IsSafe),
                new Tile(!IsSafe)
            };

            new RightTileIsTrapRule().IsTrap(tiles).Should().BeTrue();
        }

        [Test]
        [TestCase('.', true)]
        [TestCase('^', false)]
        public void Should_Parse_Tile(char input, bool isSafe)
        {
            Tile.Parse(input).IsSafe.Should().Be(isSafe);
        }

        [Test]
        public void Should_Generate_Tile_Layout_In_Small_Example()
        {
            var trapRules = new List<ITrapRule>()
            {
                new CenterAndRightAreTrapsRule(),
                new LeftAndCenterAreTrapsRule(),
                new LeftTileIsTrapRule(),
                new RightTileIsTrapRule()
            };

            var firstRowOfTiles = "..^^.".ToCharArray().Select(Tile.Parse).ToList();

            new TrapTileAnalyzer(trapRules)
                .GenerateTileLayout(firstRowOfTiles, 3)
                .SelectMany(x => x)
                .Count(x => x.IsSafe)
                .Should()
                .Be(6);
        }

        [Test]
        public void Should_Generate_Tile_Layout_In_Large_Example()
        {
            var trapRules = new List<ITrapRule>()
            {
                new CenterAndRightAreTrapsRule(),
                new LeftAndCenterAreTrapsRule(),
                new LeftTileIsTrapRule(),
                new RightTileIsTrapRule()
            };

            var firstRowOfTiles = ".^^.^.^^^^".ToCharArray().Select(Tile.Parse).ToList();

            new TrapTileAnalyzer(trapRules)
                .GenerateTileLayout(firstRowOfTiles, 10)
                .SelectMany(x => x)
                .Count(x => x.IsSafe)
                .Should()
                .Be(38);
        }

        [Test]
        public void Should_Count_Number_Of_Safe_Tiles_In_Generated_Tile_Layout()
        {
            var trapRules = new List<ITrapRule>()
            {
                new CenterAndRightAreTrapsRule(),
                new LeftAndCenterAreTrapsRule(),
                new LeftTileIsTrapRule(),
                new RightTileIsTrapRule()
            };

            const string input =
                "......^.^^.....^^^^^^^^^...^.^..^^.^^^..^.^..^.^^^.^^^^..^^.^.^.....^^^^^..^..^^^..^^.^.^..^^..^^^..";
            var firstRowOfTiles = input.ToCharArray().Select(Tile.Parse).ToList();

            new TrapTileAnalyzer(trapRules)
                .GenerateTileLayout(firstRowOfTiles, 40)
                .SelectMany(x => x)
                .Count(x => x.IsSafe)
                .Should()
                .Be(1963);
        }
    }
}
