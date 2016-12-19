using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Checksum_Needed_To_Fill_Specified_Length()
        {
            var dragonCurveAnalyzer = new DragonCurveAnalyzer();

            const string input = "10011111011011001";

            dragonCurveAnalyzer
                .GetCheckSumForFilledDiskSpace(input, 35651584)
                .Should()
                .Be("01101100001100100");
        }
    }
}
