using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day17
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Value_After_0_When_Fifty_Million_Is_Inserted_Into_Spinlock()
        {
            new BufferCalculator().CalculateValueAfter0WhenFiftyMillionIsInserted(377).Should().Be(39051595);
        }
    }
}
