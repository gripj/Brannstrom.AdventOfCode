using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartOne
    {
        private HashAnalyzer _hashAnalyzer;

        [SetUp]
        public void SetUp()
        {
            _hashAnalyzer = new HashAnalyzer();
        }

        [Test]
        public void Find_Lowest_Number()
        {
            _hashAnalyzer.FindLowestNumberForSecretKey("bgvyzdsv", 5).Should().Be(254575);
        }

        [Test]
        [TestCase("abcdef", 609043)]
        [TestCase("pqrstuv", 1048970)]
        public void Should_Find_Lowest_Number_To_Produce_Hash_With_Leading_Zeros(string secretKey, int expectedLowestNumber)
        {
            _hashAnalyzer.FindLowestNumberForSecretKey(secretKey, 5).Should().Be(expectedLowestNumber);
        }

        [Test]
        public void Should_Create_Md5()
        {
            _hashAnalyzer.GetMD5Hash("abcdef609043").Should().Be("000001dbbfa3a5c83a2d506429c7b00e");
        }
    }
}
