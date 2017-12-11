using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartOne
    {
        private GridWalker _walker;

        [SetUp]
        public void SetUp()
        {
            _walker = new GridWalker();
        }

        [Test]
        [TestCase("ne,ne,ne", 3)]
        [TestCase("ne,ne,sw,sw", 0)]
        [TestCase("ne,ne,s,s", 2)]
        [TestCase("se,sw,se,sw,sw", 3)]
        public void Should_Find_Shortest_Path_In_Example(string path, int expectedDistance)
        {
            _walker.WalkedDistances(path).Last().Should().Be(expectedDistance);
        }

        [Test]
        public void Should_Find_Shortest_Path()
        {
            _walker.WalkedDistances(File.ReadAllText("input.txt")).Last().Should().Be(707);
        }
    }
}
