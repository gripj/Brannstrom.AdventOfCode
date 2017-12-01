using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartTwo
    {
        private CaptchaSolver _solver;

        [SetUp]
        public void SetUp()
        {
            _solver = new CaptchaSolver();
        }

        [Test]
        [TestCase("1212", 6)]
        [TestCase("1221", 0)]
        [TestCase("123425", 4)]
        [TestCase("123123", 12)]
        [TestCase("12131415", 4)]
        public void Should_Calculate_Sum_Of_Digits_Matching_HalfwayAround(string input, int expectedSum)
        {
            _solver
                .CalculateSumOfDigitsMatchingHalfwayAround(
                    input
                        .Select(x => (int) char.GetNumericValue(x))
                        .ToList()
                )
                .Should()
                .Be(expectedSum);
        }

        [Test]
        public void Should_Calculate_Captcha_For_Digits_Matching_HalfwayAround()
        {
            _solver
                .CalculateSumOfDigitsMatchingHalfwayAround(
                    File.ReadAllText("input.txt")
                        .Select(x => (int)char.GetNumericValue(x))
                        .ToList()
                )
                .Should()
                .Be(1132);
        }
    }
}
