using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartTwo
    {
        private LookAndSay _lookAndSay;

        [SetUp]
        public void SetUp()
        {
            _lookAndSay = new LookAndSay();
        }

        [Test]
        public void Should_Look_And_Say_Fifty_Times()
        {
            const string input = @"3113322113";

            _lookAndSay.GetLengthOfIterationResult(input, 50).Should().Be(4666278);
        }
    }
}
