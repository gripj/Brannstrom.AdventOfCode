using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Least_Amount_Of_Mana_To_Win_Fight_When_Losing_Health_Each_Round()
        {
            var battle = new Battle();
            battle.EnableHardDifficulty();
            battle.FindLowestManaNeededToWinFight().Should().Be(1309);
        }
    }
}
