using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase(2,3,4,58)]
        [TestCase(1,1,10,43)]
        public void Should_Calculate_Wrapping_Paper_Area(int l, int w, int h, int expectedWrappingPaperArea)
        {
            new PresentBox(l, w, h).WrappingPaperSize.Should().Be(expectedWrappingPaperArea);
        }
    }
}
