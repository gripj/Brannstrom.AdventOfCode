using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day16
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Dance_Should_Produce_Correct_Order_Of_Programs_After_One_Billion_Repititions()
        {
            new Dance("abcdefghijklmnop", File.ReadAllText("input.txt").Split(','), 1000000000)
                .Programs
                .Should()
                .Be("ahgpjdkcbfmneloi");
        }
    }
}
