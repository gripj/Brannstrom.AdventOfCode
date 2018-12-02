using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Value_Left_In_Register_H()
        {
            new Computer().CalculateValueLeftInRegisterH().Should().Be(913);
        }
    }
}
