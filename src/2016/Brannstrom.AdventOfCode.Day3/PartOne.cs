using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartOne
    {
        private TriangleValidator _triangleValidator;

        [SetUp]
        public void SetUp()
        {
            _triangleValidator = new TriangleValidator();
        }

        [Test]
        public void Should_Validate_Valid_Triangle()
        {
            _triangleValidator.Validate(2, 3, 4).Should().BeTrue();
        }

        [Test]
        public void Should_Validate_Invalid_Triangle()
        {
            _triangleValidator.Validate(5, 10, 25).Should().BeFalse();
        }

        [Test]
        public void Should_Calculate_Number_Of_Valid_Triangles()
        {
            new InputReader()
                .ReadFile()
                .Select(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
                .ToList()
                .Select(x => _triangleValidator.Validate(x[0], x[1], x[2]))
                .Count(x => x)
                .Should().Be(862);
        }
    }
}
