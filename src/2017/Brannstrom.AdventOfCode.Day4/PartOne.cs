using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartOne
    {
        private PassPhraseValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new PassPhraseValidator();
        }

        [Test]
        [TestCase("aa bb cc dd ee", true)]
        [TestCase("aa bb cc dd aa", false)]
        [TestCase("aa bb cc dd aaa", true)]
        public void Should_Validate_Example_Passphrases(string passphrase, bool isValid)
        {
            _validator
                .ValidateDistinct(passphrase)
                .Should()
                .Be(isValid);
        }

        [Test]
        public void Should_Count_Number_Of_Valid_Passphrases()
        {
            File.ReadAllLines("input.txt")
                .Select(_validator.ValidateDistinct)
                .Count(x => x == true)
                .Should()
                .Be(466);
        }
    }
}
