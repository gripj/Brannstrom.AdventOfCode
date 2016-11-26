using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_Shortest_Distance()
        {
            new RouteCalculator().CalculateShortestRouteInSantasList().Should().Be(141);
        }
    }
}
