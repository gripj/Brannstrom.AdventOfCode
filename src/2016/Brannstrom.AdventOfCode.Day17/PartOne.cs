using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        [TestCase("ihgpwlah", "DDRRRD")]
        [TestCase("kglvqrro", "DDUDRLRRUDRD")]
        [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
        public void Should_Find_Shortest_Path(string passcode, string shortestPath)
        {
            new PathSolver()
                .FindShortestPath(passcode)
                .Should()
                .Be(shortestPath);
        }

        [Test]
        public void Should_Find_Shortest_Path_To_Reach_Vault()
        {
            const string passcode = "veumntbg";

            new PathSolver()
                .FindShortestPath(passcode)
                .Should()
                .Be("DDRRULRDRD");
        }
    }
}
