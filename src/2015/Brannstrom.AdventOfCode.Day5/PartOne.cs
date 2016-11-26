using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day5.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartOne
    {
        private StringAnalyzer _stringAnalyzer;

        [SetUp]
        public void SetUp()
        {
            var rules = new List<IRule>() { new VowelsRule(), new LettersAtLeastTwiceInARowRule(), new DisallowedLettersRule()};
            _stringAnalyzer = new StringAnalyzer(rules);
        }

        [Test]
        public void Find_Number_Of_Nice_Strings()
        {
            _stringAnalyzer.GetNumberOfNiceStringsFromSantasList().Should().Be(238);
        }

        [Test]
        [TestCase("ugknbfddgicrmopn")]
        [TestCase("aaa")]
        public void Should_Determine_Nice_Strings(string input)
        {
            _stringAnalyzer.StringIsNice(input).Should().BeTrue();
        }

        [Test]
        [TestCase("jchzalrnumimnmhp")]
        [TestCase("haegwjzuvuyypxyu")]
        [TestCase("dvszwmarrgswjxmb")]
        public void Should_Determine_Naughty_Strings(string input)
        {
            _stringAnalyzer.StringIsNice(input).Should().BeFalse();
        }

        [Test]
        public void Should_Determine_Amount_Of_Nice_Strings_In_List()
        {
            var list = new List<string>() { "ugknbfddgicrmopn", "aaa", "jchzalrnumimnmhp", "haegwjzuvuyypxyu", "dvszwmarrgswjxmb" };
            _stringAnalyzer.GetNumberOfNiceStringsFromList(list).Should().Be(2);
        }

        [Test]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("aa", false)]
        [TestCase("uasd", false)]
        public void VowelsRule_Should_Verify_Minimum_Number_Of_Vowels(string input, bool expectedResult)
        {
            new VowelsRule().IsNice(input).Should().Be(expectedResult);
        }

        [Test]
        [TestCase("aaa", true)]
        [TestCase("aa", true)]
        [TestCase("abcd", false)]
        [TestCase("aba", false)]
        public void LettersTwiceInARowRule_Should_Verify_Letters_Twice_In_A_Row(string input, bool expectedResult)
        {
            new LettersAtLeastTwiceInARowRule().IsNice(input).Should().Be(expectedResult);
        }

        [Test]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("uydafcd", false)]
        [TestCase("aiusdpqasd", false)]
        public void DisallowedLettersRule_Should_Verify_Disallowed_Letters(string input, bool expectedResult)
        {
            new DisallowedLettersRule().IsNice(input).Should().Be(expectedResult);
        }
    }
}
