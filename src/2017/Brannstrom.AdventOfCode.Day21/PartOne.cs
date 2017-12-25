using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_How_Many_Pixels_Stay_On_In_Example()
        {
            var input = new List<string>()
            {
                "../.# => ##./#../...",
                ".#./..#/### => #..#/..../..../#..#"
            };

            new FractalArtGenerator(input)
                .CalculateOnPixelsAfterIterations(2)
                .Should()
                .Be(12);
        }

        [Test]
        public void Should_Calculate_How_Many_Pixels_Stay_On_After_Five_Iterations()
        {
            new FractalArtGenerator(File.ReadAllLines("input.txt"))
                .CalculateOnPixelsAfterIterations(5)
                .Should()
                .Be(203);
        }
    }
}
