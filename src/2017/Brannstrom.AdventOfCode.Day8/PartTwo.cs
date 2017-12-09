using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Highest_Value_Held_During_Process_In_Example()
        {
            new Computer(new List<string>()
                {
                    "b inc 5 if a > 1",
                    "a inc 1 if b < 5",
                    "c dec -10 if a >= 1",
                    "c inc -20 if c == 10"
                })
                .HighestValue
                .Should()
                .Be(10);
        }

        [Test]
        public void Should_Find_Highest_Value_Held_During_Process()
        {
            new Computer(File.ReadAllLines("input.txt"))
                .HighestValue
                .Should()
                .Be(4829);
        }
    }
}
