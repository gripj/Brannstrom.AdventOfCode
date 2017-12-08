using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Program_Should_Calculate_Weight_Of_Self_And_SubPrograms()
        {
            const string yelledInformation = "pbga (66)\n" +
                                             "xhth (57)\n" +
                                             "ebii (61)\n" +
                                             "havc (66)\n" +
                                             "ktlj (57)\n" +
                                             "fwft (72) -> ktlj, cntj, xhth\n" +
                                             "qoyq (66)\n" +
                                             "padx (45) -> pbga, havc, qoyq\n" +
                                             "tknk (41) -> ugml, padx, fwft\n" +
                                             "jptl (61)\n" +
                                             "ugml (68) -> gyxo, ebii, jptl\n" +
                                             "gyxo (61)\n" +
                                             "cntj (57)";

            new Tower(yelledInformation.Split(new[] { "\n" }, StringSplitOptions.None))
                .GetProgram("ugml")
                .GetTotalWeight()
                .Should()
                .Be(251);
        }

        [Test]
        public void Should_Find_Weight_Required_To_Balance_Tower_In_Example()
        {
            const string yelledInformation = "pbga (66)\n" +
                                             "xhth (57)\n" +
                                             "ebii (61)\n" +
                                             "havc (66)\n" +
                                             "ktlj (57)\n" +
                                             "fwft (72) -> ktlj, cntj, xhth\n" +
                                             "qoyq (66)\n" +
                                             "padx (45) -> pbga, havc, qoyq\n" +
                                             "tknk (41) -> ugml, padx, fwft\n" +
                                             "jptl (61)\n" +
                                             "ugml (68) -> gyxo, ebii, jptl\n" +
                                             "gyxo (61)\n" +
                                             "cntj (57)";

            new Tower(yelledInformation.Split(new[] {"\n"}, StringSplitOptions.None))
                .FindProgramWeightNeededForBalance()
                .RequiredWeight
                .Should()
                .Be(60);
        }

        [Test]
        public void Should_Find_Weight_Required_To_Balance_Tower()
        {
            new Tower(File.ReadAllLines("input.txt"))
                .FindProgramWeightNeededForBalance()
                .RequiredWeight
                .Should()
                .Be(193);
        }
    }
}
