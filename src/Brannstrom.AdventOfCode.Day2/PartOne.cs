using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartOne
    {
        private PresentOrder _presentOrder;

        [SetUp]
        public void SetUp()
        {
            _presentOrder = new PresentOrder();
        }

        [Test]
        public void Calculate_Wrapping_Paper_Area()
        {
            _presentOrder.GetWrappingPaperAreaForPresentsOrder().Should().Be(1606483);
        }

        [Test]
        public void Should_Calculate_Wrapping_Paper_Area_For_Presents_Order()
        {
            var presentsOrder = new List<string>() {"2x3x4", "1x1x10"};
            _presentOrder.GetTotalWrappingPaperArea(presentsOrder).Should().Be(101);
        }

        [Test]
        [TestCase(2,3,4,58)]
        [TestCase(1,1,10,43)]
        public void Should_Calculate_Wrapping_Paper_Area(int l, int w, int h, int expectedWrappingPaperArea)
        {
            new PresentBox(l, w, h).WrappingPaperSize.Should().Be(expectedWrappingPaperArea);
        }
    }
}
