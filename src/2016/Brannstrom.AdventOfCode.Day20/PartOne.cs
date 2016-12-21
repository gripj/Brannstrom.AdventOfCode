using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day20
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Parse_Blocked_Ip()
        {
            var blockedIp = BlockedIp.Parse("5-9");
            blockedIp.From.Should().Be(5);
            blockedIp.To.Should().Be(9);
        }

        [Test]
        public void Should_Find_Lowest_Valid_Ip_In_Example()
        {
            var blockedIpDescriptions = new List<string>()
            {
                "5-8",
                "0-2",
                "4-7"
            };

            var blockedIps = blockedIpDescriptions
                .Select(BlockedIp.Parse)
                .OrderBy(x => x.From)
                .ToList();

            new BlockedIpAnalyzer(blockedIps)
                .GetLowestAllowedIp()
                .Should()
                .Be(3);
        }

        [Test]
        public void Should_Find_Lowest_Valid_Ip()
        {
            var blockedIps = new InputReader()
                                .ReadFile()
                                .Select(BlockedIp.Parse)
                                .OrderBy(x => x.From)
                                .ToList();

            new BlockedIpAnalyzer(blockedIps)
                .GetLowestAllowedIp()
                .Should()
                .Be(32259706);
        }
    }
}
