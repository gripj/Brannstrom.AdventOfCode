using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_How_Many_Pixels_Stay_On_After_18_Iterations()
        {
            new FractalArtGenerator(File.ReadAllLines("input.txt"))
                .CalculateOnPixelsAfterIterations(18)
                .Should()
                .Be(3342470);
        }
    }
}
