using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        [TestCase("ihgpwlah", 370)]
        [TestCase("kglvqrro", 492)]
        [TestCase("ulqzkmiv", 830)]
        public void Should_Find_Length_Of_Longest_Path(string passcode, int longestPathLength)
        {
            new PathSolver()
                .FindLongestPath(passcode)
                .Length
                .Should()
                .Be(longestPathLength);
        }

        [Test]
        public void Should_Find_Length_Of_Longest_Path_To_Vault()
        {
            const string passcode = "veumntbg";

            new PathSolver()
                .FindLongestPath(passcode)
                .Length
                .Should()
                .Be(536);
        }
    }
}
