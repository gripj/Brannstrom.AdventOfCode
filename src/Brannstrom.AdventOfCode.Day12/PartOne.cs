using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day12
{
    [TestFixture]
    public class PartOne
    {
        private JsonAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            _analyzer = new JsonAnalyzer();
        }

        [Test]
        public void Should_Count_Numbers_In_Provided_Input()
        {
            _analyzer.GetSumOfAllNumbers(File.ReadAllText("..\\..\\Input.json")).Should().Be(191164);
        }

        [Test]
        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"a\":2, \"b\":4}", 6)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [TestCase("{\"a\":[-1,1]}", 0)]
        [TestCase("[-1,{\"a\":1}]", 0)]
        [TestCase("[]", 0)]
        [TestCase("{}", 0)]
        public void Should_Sum_Numbers_In_Json(string input, int expectedSum)
        {
            _analyzer.GetSumOfAllNumbers(input).Should().Be(expectedSum);
        }
    }
}
