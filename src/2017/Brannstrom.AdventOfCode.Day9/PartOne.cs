using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartOne
    {
        private StreamProcessor _processor;

        [SetUp]
        public void SetUp()
        {
            _processor = new StreamProcessor();    
        }

        [Test]
        [TestCase("{}", 1)]
        [TestCase("{{{}}}", 6)]
        [TestCase("{{},{}}", 5)]
        [TestCase("{{{},{},{{}}}}", 16)]
        [TestCase("{<a>,<a>,<a>,<a>}", 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Should_Calculate_Example_Scores(string stream, int expectedScore)
        {
            _processor.Process(stream).TotalScore.Should().Be(expectedScore);
        }

        [Test]
        public void Should_Calculate_Total_Score()
        {
            _processor.Process(File.ReadAllText("input.txt")).TotalScore.Should().Be(13154);
        }
    }
}
