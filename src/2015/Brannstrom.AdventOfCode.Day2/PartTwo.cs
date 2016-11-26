using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
    [TestFixture]
    public class PartTwo
    {
        private PresentOrder _presentOrder;

        [SetUp]
        public void SetUp()
        {
            _presentOrder = new PresentOrder();
        }

        [Test]
        public void Calculate_Ribbon_Length()
        {
            _presentOrder.GetRibbonLengthForPresentsOrder().Should().Be(3842356);
        }

        [Test]
        public void Should_Calculate_Ribbon_Length_For_Presents_Order()
        {
            var presentsOrder = new List<string>() { "2x3x4", "1x1x10" };
            _presentOrder.GetTotalRibbonLength(presentsOrder).Should().Be(48);
        }

        [Test]
        [TestCase(2,3,4,34)]
        [TestCase(1,1,10,14)]
        public void Should_Calculate_Ribbon_Length(int l, int w, int h, int expectedLength)
        {
            new PresentBox(l, w, h).RibbonLength.Should().Be(expectedLength);
        }
    }
}
