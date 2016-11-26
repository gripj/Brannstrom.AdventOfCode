using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartOne
    {
        private LookAndSay _lookAndSay;

        [SetUp]
        public void SetUp()
        {
            _lookAndSay = new LookAndSay();
        }

        [Test]
        public void Should_Look_And_Say_Forty_Times()
        {
            const string input = @"3113322113";

            _lookAndSay.GetLengthOfIterationResult(input, 40).Should().Be(329356);
        }

        [Test]
        [TestCase("1", "11")]
        [TestCase("2", "12")]
        [TestCase("11", "21")]
        [TestCase("21", "1211")]
        [TestCase("1211", "111221")]
        [TestCase("111221", "312211")]
        public void Should_Perform_Look_And_Say(string input, string expectedResult)
        {
            _lookAndSay.Do(input).Should().Be(expectedResult);
        }
    }
}
