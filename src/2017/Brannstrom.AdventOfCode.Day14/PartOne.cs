using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Number_Of_Used_Squares_In_Example()
        {
            new DiskDefragmenter("flqrgnkx")
                .CalculateAmountOfUsedSquares()
                .Should()
                .Be(8108);
        }

        [Test]
        public void Should_Calculate_Number_Of_Used_Squares()
        {
            new DiskDefragmenter("xlqgujun")
                .CalculateAmountOfUsedSquares()
                .Should()
                .Be(8204);
        }
    }
}
