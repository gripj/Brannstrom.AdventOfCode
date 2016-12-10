using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartOne
    {
        private Decompressor _decompressor;

        [SetUp]
        public void SetUp()
        {
            _decompressor = new Decompressor();
        }

        [Test]
        public void Text_Without_Markers_Should_Decompress_To_Itself()
        {
            _decompressor.Decompress("ADVENT").Should().Be("ADVENT");
        }

        [Test]
        [TestCase("A(1x5)BC", "ABBBBBC")]
        [TestCase("(3x3)XYZ", "XYZXYZXYZ")]
        [TestCase("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
        [TestCase("(6x1)(1x3)A", "(1x3)A")]
        [TestCase("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY")]
        public void Should_Compress_According_To_Marker(string text, string expected)
        {
            _decompressor.Decompress(text).Should().Be(expected);
        }

        [Test]
        public void Should_Read_File()
        {
            new InputReader().ReadFile().Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Should_Calculate_Total_Decompressed_Length_Of_Input()
        {
            var input = new InputReader().ReadFile().Aggregate((i, j) => i + j);

            _decompressor
                .Decompress(input)
                .Length
                .Should()
                .Be(152851);
        }
    }
}
