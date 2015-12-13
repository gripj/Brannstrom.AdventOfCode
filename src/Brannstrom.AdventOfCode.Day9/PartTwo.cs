using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Longest_Distance()
        {
            new RouteCalculator().CalculateLongestRouteInSantasList().Should().Be(736);
        }
    }
}
