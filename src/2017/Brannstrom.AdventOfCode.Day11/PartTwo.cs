using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day11
{
    [TestFixture]
    public class PartTwo
    {
        private GridWalker _walker;

        [SetUp]
        public void SetUp()
        {
            _walker = new GridWalker();
        }

        [Test]
        [TestCase("ne,ne,ne", 3)]
        [TestCase("ne,ne,sw,sw", 2)]
        [TestCase("ne,ne,s,s", 2)]
        [TestCase("se,sw,se,sw,sw", 3)]
        public void Should_Find_Longest_Distance_From_Start_In_Examples(string path, int expectedLongestPath)
        {
            _walker.WalkedDistances(path).Max().Should().Be(expectedLongestPath);
        }

        [Test]
        public void Should_Find_Longest_Path()
        {
            _walker.WalkedDistances(File.ReadAllText("input.txt")).Max().Should().Be(1490);
        }
    }
}
