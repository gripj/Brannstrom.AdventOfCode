using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Time_Delay_Needed_For_Safe_Passage_In_Example()
        {
            new FireWall(new List<string>()
                {
                    "0: 3",
                    "1: 2",
                    "4: 4",
                    "6: 4"
                })
                .CalculateTimeDelayNeededForSafePassage()
                .Should()
                .Be(10);
        }

        [Test]
        public void Should_Find_Time_Delay_Needed_For_Safe_Passage()
        {
            new FireWall(File.ReadAllLines("input.txt"))
                .CalculateTimeDelayNeededForSafePassage()
                .Should()
                .Be(3840052);
        }
    }
}
