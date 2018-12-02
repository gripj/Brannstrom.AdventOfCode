using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Bursts_Until_Node_Becomes_Affected_For_Evolved_Virus_In_Example()
        {
            var input = new List<string>()
            {
                "..#",
                "#..",
                "..."
            };

            new ClusterCleaner(input)
                .CalculateBurstsUntilNodeBecomesAffectedForEvolvedVirus()
                .Should()
                .Be(2511944);
        }

        [Test]
        public void Should_Calculate_Bursts_Until_Node_Becomes_Affected_For_Evolved_Virus()
        {
            new ClusterCleaner(File.ReadAllLines("input.txt"))
                .CalculateBurstsUntilNodeBecomesAffectedForEvolvedVirus()
                .Should()
                .Be(2512261);
        }
    }
}
