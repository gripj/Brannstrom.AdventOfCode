using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Biggest_Number_Of_Reachable_Destinations()
        {
            const int steps = 50;

            const int favoriteNumber = 1364;
            var start = new Cubicle(1, 1, favoriteNumber);

            new CubicleNavigator()
                .FindReachable(start, steps)
                .Count
                .Should()
                .Be(127);
        }
    }
}
