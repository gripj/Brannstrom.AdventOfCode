using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartTwo
    {
        private DecompressorV2 _decompressor;

        [SetUp]
        public void SetUp()
        {
            _decompressor = new DecompressorV2();
        }

        [Test]
        [TestCase("(3x3)XYZ", "XYZXYZXYZ")]
        [TestCase("X(8x2)(3x3)ABCY", "XABCABCABCABCABCABCY")]
        public void Should_Decompress_Text_And_Markers(string input, string expected)
        {
            _decompressor.GetDecompressedLength(input).Should().Be((ulong)expected.Length);
        }

        [Test]
        [TestCase("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [TestCase("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        public void Should_Calculate_Decompressed_Result_Length_For_Advanced_Cases(string input, int expectedLength)
        {
            _decompressor.GetDecompressedLength(input).Should().Be((ulong)expectedLength);
        }

        [Test]
        public void Should_Calculate_Decompressed_Result_Length_For_Version_2()
        {
            var input = new InputReader().ReadFile().Aggregate((i, j) => i + j);

            _decompressor
                .GetDecompressedLength(input)
                .Should()
                .Be(11797310782);
        }
    }
}
