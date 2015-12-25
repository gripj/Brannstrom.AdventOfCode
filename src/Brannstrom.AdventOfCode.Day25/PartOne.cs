using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day25
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Code()
        {
            const int row = 2947;
            const int column = 3029;
            new CodeCalculator().Calculate(row, column).Should().Be(19980801);
        }

        [Test]
        [TestCase(2, 1, 31916031)]
        [TestCase(3, 4, 7981243)]
        [TestCase(6, 5, 1534922)]
        public void Should_Calculate_Codes_Correctly(int row, int column, int expectedValue)
        {
            new CodeCalculator().Calculate(row, column).Should().Be(expectedValue);
        }
    }
}
