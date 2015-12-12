using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
            _stringAnalyzer = new StringAnalyzer();
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
    }
}
