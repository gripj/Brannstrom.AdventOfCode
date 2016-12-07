using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase("abba[mnop]qrst", 2, 1)]
        [TestCase("abba[mnop]qrst[asdgdfs]fgdfghggf[sdfghdsfgh]", 3, 3)]
        public void Should_Parse_IPAddress(
            string input, 
            int expectedAmountOfSequences, 
            int expectedAmountOfHyperlinkSequences)
        {
            IPAddress
                .Parse(input)
                .HypernetSequences
                .Count()
                .Should()
                .Be(expectedAmountOfHyperlinkSequences);
        }

        [Test]
        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        public void Should_Determine_Whether_Address_Supports_TLS(string input, bool supportsTls)
        {
            IPAddress
                .Parse(input)
                .SupportsTLS
                .Should()
                .Be(supportsTls);
        }

        [Test]
        public void Should_Read_Input_File()
        {
            new InputReader()
                .ReadFile()
                .Count()
                .Should()
                .BeGreaterThan(0);
        }

        [Test]
        public void Should_Count_Number_Of_IpAddresses_Supporting_TLS()
        {
            new InputReader()
                .ReadFile()
                .Select(IPAddress.Parse)
                .Count(x => x.SupportsTLS)
                .Should()
                .Be(110);
        }
    }
}
