using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day23
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Value_For_Register_B_When_Starting_Value_Is_1()
        {
            new Computer().CalculateRegistryValue(1).Should().Be(231);
        }
    }
}
