using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Village_Should_Contain_Programs_In_Information()
        {
            const string pipeInformation = "0 <-> 2" + "\n" +
                                           "1 <-> 1" + "\n" +
                                           "2 <-> 0, 3, 4" + "\n" +
                                           "3 <-> 2, 4" + "\n" +
                                           "4 <-> 2, 3, 6" + "\n" +
                                           "5 <-> 6" + "\n" +
                                           "6 <-> 4, 5";

            new Village(pipeInformation.Split(new[] {"\n"}, StringSplitOptions.None))
                .Programs
                .Count()
                .Should()
                .Be(7);
        }

        [Test]
        public void Should_Count_Program_Connections_In_Example()
        {
            const string pipeInformation = "0 <-> 2" + "\n" +
                                           "1 <-> 1" + "\n" +
                                           "2 <-> 0, 3, 4" + "\n" +
                                           "3 <-> 2, 4" + "\n" +
                                           "4 <-> 2, 3, 6" + "\n" +
                                           "5 <-> 6" + "\n" +
                                           "6 <-> 4, 5";

            new Village(pipeInformation.Split(new[] { "\n" }, StringSplitOptions.None))
                .GetConnectedPrograms()
                .Single(x => x.Contains("0"))
                .Count()
                .Should()
                .Be(6);
        }

        [Test]
        public void Should_Count_Connections_To_Program_0()
        {
            new Village(File.ReadAllLines("input.txt"))
                .GetConnectedPrograms()
                .Single(x => x.Contains("0"))
                .Count()
                .Should()
                .Be(288);
        }
    }
}
