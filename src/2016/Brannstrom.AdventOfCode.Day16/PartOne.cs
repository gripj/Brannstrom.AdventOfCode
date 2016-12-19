using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartOne
    {
        private DragonCurveAnalyzer _dragonCurveAnalyzer;

        [SetUp]
        public void SetUp()
        {
            _dragonCurveAnalyzer = new DragonCurveAnalyzer();
        }

        [Test]
        [TestCase("1", "100")]
        [TestCase("0", "001")]
        [TestCase("11111", "11111000000")]
        [TestCase("111100001010", "1111000010100101011110000")]
        public void Should_Create_Dragon_Curve(string input, string expectedResult)
        {
            _dragonCurveAnalyzer.CreateDragonCurve(input).Should().Be(expectedResult);
        }

        [Test]
        public void Should_Calculate_Checksum()
        {
            _dragonCurveAnalyzer
                .CalculateChecksum("110010110100")
                .Should()
                .Be("100");
        }

        [Test]
        public void Should_Find_Checksum_To_Fill_DiskSpace_In_Example()
        {
            _dragonCurveAnalyzer
                .GetCheckSumForFilledDiskSpace("10000", 20)
                .Should()
                .Be("01100");
        }

        [Test]
        public void Should_Find_Checksum_Needed_To_Fill_Specified_Length()
        {
            const string input = "10011111011011001";

            _dragonCurveAnalyzer
                .GetCheckSumForFilledDiskSpace(input, 272)
                .Should()
                .Be("10111110010110110");
        }
    }
}
