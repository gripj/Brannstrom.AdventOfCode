using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Build_Strongest_Possible_Bridge_In_Example()
        {
            var components = new List<string>()
            {
                "0/2",
                "2/2",
                "2/3",
                "3/4",
                "3/5",
                "0/1",
                "10/1",
                "9/10"
            };

            new BridgeBuilder().GetStrengthOfStrongestBridge(components).Should().Be(31);
        }

        [Test]
        public void Should_Build_Strongest_Possible_Bridge()
        {
            new BridgeBuilder().GetStrengthOfStrongestBridge(File.ReadAllLines("input.txt")).Should().Be(1868);
        }
    }
}
