using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Value_After_2017_In_Example()
        {
            new BufferCalculator().CalculateValueAfter2017(3).Should().Be(638);
        }

        [Test]
        public void Should_Calculate_Value_After_2017()
        {
            new BufferCalculator().CalculateValueAfter2017(377).Should().Be(596);
        }
    }
}
