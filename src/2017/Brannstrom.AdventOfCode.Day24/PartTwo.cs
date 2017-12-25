using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day24
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_Strength_Of_Longest_Bridge_In_Example()
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

            new BridgeBuilder().GetStrengthOfLongestBridge(components).Should().Be(19);
        }

        [Test]
        public void Should_Get_Strength_Of_Longest_Bridge()
        {
            new BridgeBuilder().GetStrengthOfLongestBridge(File.ReadAllLines("input.txt")).Should().Be(1841);
        }
    }
}
