using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Follow_Path_In_Example()
        {
            new PathSolver()
                .FollowPath(File.ReadAllLines("exampleInput.txt"))
                .Letters
                .Should()
                .Be("ABCDEF");
        }

        [Test]
        public void Should_Follow_Path()
        {
            new PathSolver()
                .FollowPath(File.ReadAllLines("input.txt"))
                .Letters
                .Should()
                .Be("VTWBPYAQFU");
        }
    }
}
