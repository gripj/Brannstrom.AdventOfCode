using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day19
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Count_Number_Of_Steps_In_Example()
        {
            new PathSolver()
                .FollowPath(File.ReadAllLines("exampleInput.txt"))
                .Steps
                .Should()
                .Be(38);
        }

        [Test]
        public void Should_Count_Number_Of_Steps()
        {
            new PathSolver()
                .FollowPath(File.ReadAllLines("input.txt"))
                .Steps
                .Should()
                .Be(17358);
        }
    }
}
