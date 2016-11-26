using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day1
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_End_Floor()
        {
            var instructions = File.ReadAllText("input.txt");
            FindFloor(instructions).Should().Be(280);
        }

        [Test]
        [TestCase("(())", 0)]
        [TestCase("()()", 0)]
        [TestCase("(((", 3)]
        [TestCase("(()(()(", 3)]
        [TestCase("))(((((", 3)]
        [TestCase("())", -1)]
        [TestCase("))(", -1)]
        [TestCase(")))", -3)]
        [TestCase(")())())", -3)]
        public void Should_Find_Correct_Floor(string instructions, int expectedFloor)
        {
            FindFloor(instructions).Should().Be(expectedFloor);
        }

        private static int FindFloor(string instructions)
        {
            var amountOfFloorsToAscend = instructions.ToCharArray().Where(x => x.Equals('(')).Count();
            var amountOfFloorsToDescend = instructions.ToCharArray().Where(x => x.Equals(')')).Count();
            return amountOfFloorsToAscend - amountOfFloorsToDescend;
        }
    }
}