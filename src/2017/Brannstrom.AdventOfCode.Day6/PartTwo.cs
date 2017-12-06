using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day6
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Reallocation_Loop_Size_In_Example()
        {
            new MemoryReallocator(
                    "0 2 7 0"
                        .Split(' ')
                        .Select(x => x.ToMemoryBankWithThisManyBlocks())
                        .ToArray()
                )
                .FindReallocationLoopSize()
                .Should()
                .Be(4);
        }

        [Test]
        public void Should_Find_Reallocation_Loop_Size()
        {
            new MemoryReallocator(
                    File.ReadAllText("input.txt")
                        .Split('\t')
                        .Select(x => x.ToMemoryBankWithThisManyBlocks())
                        .ToArray()
                )
                .FindReallocationLoopSize()
                .Should()
                .Be(1610);
        }
    }
}
