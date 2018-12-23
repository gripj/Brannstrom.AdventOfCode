using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Calculate_Outcome_For_Elves_With_Increasing_Attack_Power()
        {
            new GameEvaluator().CalculateOutcomeForElvesWithIncreasingPower(InputReader.Read()).Should().Be(53222);
        }
    }
}
