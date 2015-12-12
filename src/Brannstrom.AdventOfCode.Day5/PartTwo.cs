using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day5.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartTwo
    {
        private StringAnalyzer _stringAnalyzer;

        [SetUp]
        public void SetUp()
        {
            var rules = new List<IRule>() { new PairOfLettersAppearingAtLeastTwiceWithoutOverlappingRule(), new ContainsOneRepeatingLetterWithOneBetweenThemRule()};
            _stringAnalyzer = new StringAnalyzer(rules);
        }

        [Test]
        public void Find_Number_Of_Nice_Strings()
        {
            _stringAnalyzer.GetNumberOfNiceStringsFromSantasList().Should().Be(69);
        }

        [Test]
        [TestCase("qjhvhtzxzqqjkmpb")]
        [TestCase("xxyxx")]
        public void Should_Determine_Nice_Strings(string input)
        {
            _stringAnalyzer.StringIsNice(input).Should().BeTrue(); 
        }

        [Test]
        [TestCase("uurcxstgmygtbstg")]
        [TestCase("ieodomkazucvgmuy")]
        public void Should_Determine_Naughty_Strings(string input)
        {
            _stringAnalyzer.StringIsNice(input).Should().BeFalse();
        }

        [Test]
        public void Should_Determine_Amount_Of_Nice_Strings_In_List()
        {
            var list = new List<string>() { "qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy" };
            _stringAnalyzer.GetNumberOfNiceStringsFromList(list).Should().Be(2);
        }

        [Test]
        [TestCase("xyxy", true)]
        [TestCase("aabcdefgaa", true)]
        [TestCase("aaa", false)]
        public void Should_Verify_Pair_Of_Letters_Rule(string input, bool expectedResult)
        {
            new PairOfLettersAppearingAtLeastTwiceWithoutOverlappingRule().IsNice(input).Should().Be(expectedResult); 
        }

        [Test]
        [TestCase("xyx", true)]
        [TestCase("abcdefeghi", true)]
        [TestCase("aaa", true)]
        [TestCase("abc", false)]
        [TestCase("abca", false)]
        public void Should_Verify_Repeating_Letter_With_One_Between_Rule(string input, bool expectedResult)
        {
            new ContainsOneRepeatingLetterWithOneBetweenThemRule().IsNice(input).Should().Be(expectedResult);
        }
    }
}
