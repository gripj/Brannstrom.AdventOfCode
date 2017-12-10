using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day10
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Should_Calculate_Hexadecimal_Dense_Hash_In_Example(string input, string expectedHash)
        {
            KnotHasher.HexadecimalDenseHash(input.ToASCIILengths(), 64).Should().Be(expectedHash);
        }

        [Test]
        public void Should_Calculate_Hexadecimal_Dense_Hash()
        {
            KnotHasher.HexadecimalDenseHash(File.ReadAllText("input.txt").ToASCIILengths(), 64)
                .Should()
                .Be("9d5f4561367d379cfbf04f8c471c0095");
        }
    }
}
