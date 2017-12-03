using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day3
{
    [TestFixture]
    public class PartOne
    {
        private SpiralMemoryCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SpiralMemoryCalculator();
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        public void Should_Calculate_Example_Steps(int location, int expectedSteps)
        {
            _calculator
                .CalculateStepsToCarryDataToAccessPort(location)
                .Should()
                .Be(expectedSteps); 
        }

        [Test]
        public void Should_Calculate_Number_Of_Steps_To_Carry_Data()
        {
            _calculator
                .CalculateStepsToCarryDataToAccessPort(289326)
                .Should()
                .Be(419);
        }
    }
}
