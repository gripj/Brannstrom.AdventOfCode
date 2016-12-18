using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase(0, 0, true)]
        [TestCase(1, 0, false)]
        [TestCase(2, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(1, 1, true)]
        [TestCase(-1, -1, false)]
        public void Should_Determine_Open_Space(int x, int y, bool isOpenSpace)
        {
            const int favoriteNumber = 10;
            new Cubicle(x, y, favoriteNumber).IsOpenSpace().Should().Be(isOpenSpace);
        }

        [Test]
        public void Should_Find_Fewest_Number_Of_Steps_To_Reach_Destination()
        {
            const int favoriteNumber = 1364;
            var start = new Cubicle(1, 1, favoriteNumber);
            var end = new Cubicle(31, 39, favoriteNumber);

            new CubicleNavigator()
                            .FindShortestPathToCubicle(start, end)
                            .Should()
                            .Be(86);
        }
    }
}
