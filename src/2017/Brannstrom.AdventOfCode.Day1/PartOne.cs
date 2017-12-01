using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartOne
    {
        private CaptchaSolver _solver;

        [SetUp]
        public void SetUp()
        {
            _solver = new CaptchaSolver();
        }

        [Test]
        [TestCase("1122", 3)]
        [TestCase("1111", 4)]
        [TestCase("1234", 0)]
        [TestCase("91212129", 9)]
        public void Should_Calculate_Sum_Of_Concurrent_Digits(string input, int expectedSum)
        {
            _solver
                .CalculateSumOfConcurrentDigits(
                    input
                        .Select(x => (int)char.GetNumericValue(x))
                        .ToList()
                )
                .Should()
                .Be(expectedSum);
        }

        [Test]
        public void Should_Calculate_Sum_Of_Concurrent_Digits_In_Captcha()
        {
            _solver
                .CalculateSumOfConcurrentDigits(
                    File.ReadAllText("input.txt")
                        .Select(x => (int) char.GetNumericValue(x))
                        .ToList()
                )
                .Should()
                .Be(1158);
        }
    }
}
