using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartTwo
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
            _hashAnalyzer.FindLowestNumberForSecretKey("bgvyzdsv", 6).Should().Be(1038736);
        }
    }
}
