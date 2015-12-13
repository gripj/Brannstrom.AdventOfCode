using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Count_Difference()
        {
            CountDifference().Should().Be(1350);
        }

        private int CountDifference()
        {
            var fileStrings = new Reader().ReadStringsFromFile();
            return fileStrings.Sum(c => c.Length - (Regex.Unescape(c).Length - 2));
        }
    }
}
