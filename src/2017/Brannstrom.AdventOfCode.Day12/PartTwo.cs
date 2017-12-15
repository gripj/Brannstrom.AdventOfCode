using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Count_Number_Of_Connected_Groups_In_Example()
        {
            const string pipeInformation = "0 <-> 2" + "\n" +
                                           "1 <-> 1" + "\n" +
                                           "2 <-> 0, 3, 4" + "\n" +
                                           "3 <-> 2, 4" + "\n" +
                                           "4 <-> 2, 3, 6" + "\n" +
                                           "5 <-> 6" + "\n" +
                                           "6 <-> 4, 5";

            new Village(pipeInformation.Split(new[] {"\n"}, StringSplitOptions.None))
                .GetConnectedPrograms()
                .Count()
                .Should()
                .Be(2);
        }

        [Test]
        public void Should_Count_Number_Of_Connected_Groups()
        {
            new Village(File.ReadAllLines("input.txt"))
                .GetConnectedPrograms()
                .Count()
                .Should()
                .Be(211);
        }
    }
}
