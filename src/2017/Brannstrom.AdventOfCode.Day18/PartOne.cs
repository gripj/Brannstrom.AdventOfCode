using System.Collections.Generic;
using System.IO;
using System.Linq;
using Brannstrom.AdventOfCode.Day18.Computer;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day18
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Recover_Last_Frequency_In_Example()
        {
            new ComputerV1()
                .Execute(new List<string>()
                {
                    "set a 1",
                    "add a 2",
                    "mul a a",
                    "mod a 5",
                    "snd a",
                    "set a 0",
                    "rcv a",
                    "jgz a -1",
                    "set a 1",
                    "jgz a -2"
                })
                .First(received => received != null)
                .Value
                .Should()
                .Be(4);
        }

        [Test]
        public void Should_Recover_Last_Frequency()
        {
            new ComputerV1()
                .Execute(File.ReadAllLines("input.txt"))
                .First(received => received != null)
                .Value
                .Should()
                .Be(1187);
        }
    }
}
