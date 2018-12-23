using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Calculate_Outcome()
        {
            new GameEvaluator().CalculateOutcome(InputReader.Read()).Should().Be(214731);
        }
    }
}
