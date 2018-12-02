using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brannstrom.AdventOfCode.Day18.Computer;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Number_Of_Times_Computer1_Sent_Values_In_Example()
        {
            var queue0 = new Queue<long>();
            var queue1 = new Queue<long>();

            var input = new List<string>()
                        {
                            "snd 1",
                            "snd 2",
                            "snd p",
                            "rcv a",
                            "rcv b",
                            "rcv c",
                            "rcv d"
                        };

            Enumerable
                .Zip(
                    new ComputerV2(0, queue0, queue1).Execute(input),
                    new ComputerV2(1, queue1, queue0).Execute(input),
                    (computer0, computer1) => (Computer0: computer0, Computer1: computer1))
                .First(x => !x.Computer0.IsActive && !x.Computer1.IsActive)
                .Computer1
                .TimesSent
                .Should()
                .Be(3);
        }

        [Test]
        public void Should_Find_Number_Of_Times_Computer1_Sent_Values()
        {
            var queue0 = new Queue<long>();
            var queue1 = new Queue<long>();

            var input = File.ReadAllLines("input.txt");

            Enumerable
                .Zip(
                    new ComputerV2(0, queue0, queue1).Execute(input),
                    new ComputerV2(1, queue1, queue0).Execute(input),
                    (computer0, computer1) => (Computer0: computer0, Computer1: computer1))
                .First(x => !x.Computer0.IsActive && !x.Computer1.IsActive)
                .Computer1
                .TimesSent
                .Should()
                .Be(5969);
        }
    }
}
