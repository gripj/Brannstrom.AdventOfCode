using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day9
{
    [TestFixture]
    public class PartTwo
    {
        private StreamProcessor _processor;

        [SetUp]
        public void SetUp()
        {
            _processor = new StreamProcessor();
        }

        [Test]
        [TestCase("<>", 0)]
        [TestCase("<random characters>", 17)]
        [TestCase("<<<<>", 3)]
        [TestCase("<{!>}>", 2)]
        [TestCase("<!!>", 0)]
        [TestCase("<!!!>>", 0)]
        [TestCase("<{o\"i!a,<{i<a>", 10)]
        public void Should_Calculate_Example_Garbage_Scores(string garbage, int expectedScore)
        {
            _processor.Process(garbage).GarbageScore.Should().Be(expectedScore);
        }

        [Test]
        public void Should_Calculate_Garbage_Score()
        {
            _processor.Process(File.ReadAllText("input.txt")).GarbageScore.Should().Be(6369);
        }
    }
}
