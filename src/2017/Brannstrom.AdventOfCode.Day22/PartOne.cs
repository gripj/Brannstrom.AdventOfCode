using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Bursts_Until_Node_Becomes_Affected_In_Example()
        {
            var input = new List<string>()
            {
                "..#",
                "#..",
                "..."
            };

            new ClusterCleaner(input)
                .CalculateBurstsUntilNodeBecomesAffected()
                .Should()
                .Be(5587);
        }

        [Test]
        public void Should_Calculate_Bursts_Until_Node_Becomes_Affected()
        {
            new ClusterCleaner(File.ReadAllLines("input.txt"))
                .CalculateBurstsUntilNodeBecomesAffected()
                .Should()
                .Be(5280);
        }
    }
}
