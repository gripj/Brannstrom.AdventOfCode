using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Multiply_First_And_Second_Elements_In_List_After_Hash_In_Example()
        {
            KnotHasher.SparseHash("3, 4, 1, 5", 1, 5)
                .Take(2)
                .Aggregate((a, b) => a * b)
                .Should()
                .Be(12);
        }

        [Test]
        public void Should_Multiply_First_And_Second_Elements_In_List_After_Hash()
        {
            KnotHasher.SparseHash(File.ReadAllText("input.txt"), 1)
                .Take(2)
                .Aggregate((a, b) => a * b)
                .Should()
                .Be(6909);
        }
    }
}
