using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Number_Of_Valid_Triangles()
        {
            var triangleValidator = new TriangleValidator();

            var input = new InputReader()
                            .ReadFile()
                            .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray())
                            .ToList();

            var sideSpecifications = new List<List<int>>();

            for (var i = 0; i < input.Count(); i = i + 3)
                for (var j = 0; j < 3; j++)
                    sideSpecifications.Add(new List<int>() { input[i][j], input[i+1][j], input[i+2][j] });

            sideSpecifications
                .Select(x => triangleValidator.Validate(x[0], x[1], x[2]))
                .Count(x => x).Should().Be(1577);
        }
    }
}
