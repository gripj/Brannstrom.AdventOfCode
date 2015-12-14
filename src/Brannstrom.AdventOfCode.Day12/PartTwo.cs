using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartTwo
    {
        private JsonAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            _analyzer = new JsonAnalyzer();
        }

        [Test]
        public void Should_Count_Non_Red_Numbers_In_Provided_Input()
        {
            _analyzer.GetSumOfAllNonRedNumbers(File.ReadAllText("..\\..\\Input.json")).Should().Be(87842);
        }

        [Test]
        [TestCase("[1,2,3]", 6)]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        [TestCase("{\"d\":\"red\", \"e\":[1,2,3,4],\"f\":5}", 0)]
        [TestCase("[1,\"red\", 5]", 6)]
        public void Should_Get_Sum_Of_Non_Red_Numbers(string input, int expectedSum)
        {
            _analyzer.GetSumOfAllNonRedNumbers(input).Should().Be(expectedSum);
        }
    }
}
