using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    public class PartTwo
    {
        [Test]
        [TestCase("aba[bab]xyz", true)]
        [TestCase("xyx[xyx]xyx", false)]
        [TestCase("aaa[kek]eke", true)]
        [TestCase("zazbz[bzb]cdb", true)]
        public void Should_Determine_Whether_Address_Supports_SSL(string input, bool supportsSsl)
        {
            IPAddress
                .Parse(input)
                .SupportsSSL
                .Should()
                .Be(supportsSsl);
        }

        [Test]
        public void Should_Count_Number_Of_IpAddresses_Supporting_SSL()
        {
            new InputReader()
                .ReadFile()
                .Select(IPAddress.Parse)
                .Count(x => x.SupportsSSL)
                .Should()
                .Be(242);
        }
    }
}
