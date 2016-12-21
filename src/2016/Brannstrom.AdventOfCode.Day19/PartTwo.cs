using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_Winner_In_Example_When_Stealing_Across()
        {
            new CircleOfElves(5)
                .GetWinnerWhenStealingAcross()
                .Id
                .Should()
                .Be(2);
        }

        [Test]
        public void Should_Get_Winner_When_Stealing_Across()
        {
            new CircleOfElves(3005290)
                .GetWinnerWhenStealingAcross()
                .Id
                .Should()
                .Be(1410967);
        }
    }
}
