using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day8
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_Largest_Value_After_Executing_One_Instruction()
        {
            new Computer(new List<string>()
                {
                    "b inc 5 if a >= 0"
                })
                .Registers
                .Max(x => x.Value)
                .Should()
                .Be(5);
        }

        [Test]
        public void Should_Find_Largest_Register_Value_After_Executing_Instructions_In_Example()
        {
            new Computer(new List<string>()
                {
                    "b inc 5 if a > 1",
                    "a inc 1 if b < 5",
                    "c dec -10 if a >= 1",
                    "c inc -20 if c == 10"
                })
                .Registers
                .Max(x => x.Value)
                .Should()
                .Be(1);
        }

        [Test]
        public void Should_Find_Largest_Register_Value_After_Executing_Instructions()
        {
            new Computer(File.ReadAllLines("input.txt"))
                .Registers
                .Max(x => x.Value)
                .Should()
                .Be(4066);
        }
    }
}
