using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Parse_Program()
        {
            var program = new Program("lhrml (164) -> ecblhee, sdjshz");
            program.Name.Should().Be("lhrml");
            program.Weight.Should().Be(164);
            program.SubProgramNames[0].Should().Be("ecblhee");
            program.SubProgramNames[1].Should().Be("sdjshz");
        }

        [Test]
        public void Should_Find_Name_Of_Bottom_Tower_In_Example()
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
                .GetBottomProgram()
                .Name
                .Should()
                .Be("tknk");
        }

        [Test]
        public void Should_Find_Name_Of_Bottom_Tower()
        {
            new Tower(File.ReadAllLines("input.txt"))
                .GetBottomProgram()
                .Name
                .Should()
                .Be("cyrupz");
        }
    }
}
