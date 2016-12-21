using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day18.TrapRules;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Count_Number_Of_Safe_Tiles_When_There_Are_400000_Rows()
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
                .GenerateTileLayout(firstRowOfTiles, 400000)
                .SelectMany(x => x)
                .Count(x => x.IsSafe)
                .Should()
                .Be(20009568);
        }
    }
}
