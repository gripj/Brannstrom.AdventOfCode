using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Get_Number_Of_Redistribution_Cycles_Before_Configuration_Repeats_In_Example()
        {
            new MemoryReallocator(
                    "0 2 7 0"
                        .Split(' ')
                        .Select(x => x.ToMemoryBankWithThisManyBlocks())
                        .ToArray()
                )
                .FindRedistributionsUntilConfigurationRepeats()
                .Should()
                .Be(5);
        }

        [Test]
        public void Should_Get_Number_Of_Redistribution_Cycles_Before_Configuration_Repeats()
        {
            new MemoryReallocator(
                    File.ReadAllText("input.txt")
                        .Split('\t')
                        .Select(x => x.ToMemoryBankWithThisManyBlocks())
                        .ToArray()
                )
                .FindRedistributionsUntilConfigurationRepeats()
                .Should()
                .Be(3156);
        }
    }
}
