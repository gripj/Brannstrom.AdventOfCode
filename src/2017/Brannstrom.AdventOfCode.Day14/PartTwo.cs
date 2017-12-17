using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Number_Of_Regions_In_Example()
        {
            new DiskDefragmenter("flqrgnkx")
                .CalculateNumberOfRegions()
                .Should()
                .Be(1242);
        }

        [Test]
        public void Should_Calculate_Number_Of_Regions()
        {
            new DiskDefragmenter("xlqgujun")
                .CalculateNumberOfRegions()
                .Should()
                .Be(1089);
        }
    }
}
