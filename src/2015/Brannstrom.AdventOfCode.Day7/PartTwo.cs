using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day7
{
    [TestFixture]
    public class PartTwo
    {
        private Circuit _circuit;

        [SetUp]
        public void SetUp()
        {
            _circuit = new Circuit();
        }

        [Test]
        public void Should_Override_With_B_And_Get_New_Value_For_A()
        {
            _circuit.OverrideAndGetNewValueForWireA().Should().Be(14134);
        }
    }
}
