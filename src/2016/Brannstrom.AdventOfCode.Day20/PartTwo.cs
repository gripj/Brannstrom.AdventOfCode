using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day20
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Amount_Of_Allowed_IPs()
        {
            var blockedIps = new InputReader()
                                .ReadFile()
                                .Select(BlockedIp.Parse)
                                .OrderBy(x => x.From)
                                .ToList();

            new BlockedIpAnalyzer(blockedIps)
                .GetNumberOfAllowedIps()
                .Should()
                .Be(113);
        }
    }
}
