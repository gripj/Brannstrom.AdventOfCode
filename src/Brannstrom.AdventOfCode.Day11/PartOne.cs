using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day11.PasswordRequirements;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartOne
    {
        private PasswordAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            var requirements = new List<IRequirement>()
            {
                new IncreasingStraightOfThreeLettersRequirement(),
                new DisallowedCharactersRequirement(),
                new DifferentNonOverlappingPairsRequirement()
            };
            _analyzer = new PasswordAnalyzer(requirements);
        }

        [Test]
        public void Should_Find_First_New_Valid_Password()
        {
            _analyzer.FindNextValidPassword("vzbxkghb").Should().Be("vzbxxyzz");
        }

        [Test]
        public void Should_Validate_Password()
        {
            _analyzer.PasswordIsValid("abcdffaa").Should().BeTrue();
        }

        [Test]
        [TestCase("abc", true)]
        [TestCase("cba", false)]
        [TestCase("asudhflabd", false)]
        [TestCase("hijklmmn", true)]
        public void Should_Verify_Increasing_Straight(string input, bool expectedResult)
        {
            new IncreasingStraightOfThreeLettersRequirement().IsValid(input).Should().Be(expectedResult);
        }

        [Test]
        [TestCase("hijklmmn", false)]
        [TestCase("asudhfabd", true)]
        [TestCase("oasdhuysdf", false)]
        [TestCase("iasdgsdgsd", false)]
        [TestCase("sdfghlqwef", false)]
        public void Should_Verify_Disallowed_Characters(string input, bool expectedResult)
        {
            new DisallowedCharactersRequirement().IsValid(input).Should().Be(expectedResult);
        }

        [Test]
        [TestCase("abbceffg", true)]
        [TestCase("abbcegjk", false)]
        [TestCase("aaabb", true)]
        public void Should_Verify_Non_Overlapping_Pairs(string input, bool expectedResult)
        {
            new DifferentNonOverlappingPairsRequirement().IsValid(input).Should().Be(expectedResult);
        }
    }
}
