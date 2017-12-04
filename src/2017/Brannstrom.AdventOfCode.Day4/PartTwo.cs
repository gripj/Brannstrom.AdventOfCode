using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartTwo
    {
        private PassPhraseValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new PassPhraseValidator();
        }

        [Test]
        [TestCase("abcde fghij", true)]
        [TestCase("abcde xyz ecdab", false)]
        [TestCase("a ab abc abd abf abj", true)]
        [TestCase("iiii oiii ooii oooi oooo", true)]
        [TestCase("oiii ioii iioi iiio", false)]
        public void Should_Validate_Example_Passphrases(string passphrase, bool isValid)
        {
            _validator
                .Validate(passphrase)
                .Should()
                .Be(isValid);
        }

        [Test]
        public void Should_Count_Number_Of_Valid_Passphrases()
        {
            File.ReadAllLines("input.txt")
                .Select(_validator.Validate)
                .Count(x => x == true)
                .Should()
                .Be(251);
        }
    }
}
