using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day2.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day2
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    [TestCase("abcdef", false)]
    [TestCase("bababc", true)]
    [TestCase("abbcde", true)]
    [TestCase("abcccd", false)]
    [TestCase("aabcdd", true)]
    [TestCase("abcdee", true)]
    [TestCase("ababab", false)]
    public void ContainsAmountOfLettersRule_Should_Correctly_Identify_Letters_Appearing_Two_Times(string boxId, bool hasLettersThatAppearTwoTimes)
    {
      new ContainsAmountOfLettersRule(2).IsValid(boxId).Should().Be(hasLettersThatAppearTwoTimes);
    }

    [Test]
    [TestCase("abcdef", false)]
    [TestCase("bababc", true)]
    [TestCase("abbcde", false)]
    [TestCase("abcccd", true)]
    [TestCase("aabcdd", false)]
    [TestCase("abcdee", false)]
    [TestCase("ababab", true)]
    public void ContainsAmountOfLettersRule_Should_Correctly_Identify_Three_Times(string boxId, bool hasLettersThatAppearTwoTimes)
    {
      new ContainsAmountOfLettersRule(3).IsValid(boxId).Should().Be(hasLettersThatAppearTwoTimes);
    }

    [Test]
    public void Should_Calculate_Checksum_In_Example()
    {
      var boxIds = new List<string>()
      {
        "abcdef",
        "bababc",
        "abbcde",
        "abcccd",
        "aabcdd",
        "abcdee",
        "ababab"
      };

      var rules = new List<IRule>() { new ContainsAmountOfLettersRule(2), new ContainsAmountOfLettersRule(3) };

      new ChecksumCalculator(rules).CalculateChecksum(boxIds).Should().Be(12);
    }

    [Test]
    public void Should_Calculate_Checksum()
    {
      var rules = new List<IRule>() { new ContainsAmountOfLettersRule(2), new ContainsAmountOfLettersRule(3) };

      new ChecksumCalculator(rules).CalculateChecksum(InputReader.Read()).Should().Be(4980);
    }
  }
}
