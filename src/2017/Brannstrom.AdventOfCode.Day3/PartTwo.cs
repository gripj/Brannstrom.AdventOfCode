using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartTwo
    {
        private SpiralMemoryCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SpiralMemoryCalculator();
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(4, 5)]
        public void Should_Find_First_Larger_Value_In_Examples(int squareNumber, int expectedValue)
        {
            _calculator
                .CalculateFirstValueLargerThanNumber(squareNumber)
                .Should()
                .Be(expectedValue);
        }

        [Test]
        public void Should_Find_First_Value_Larger_Than_Input()
        {
            _calculator
                .CalculateFirstValueLargerThanNumber(289326)
                .Should()
                .Be(295229);
        }
    }
}
