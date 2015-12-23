using Brannstrom.AdventOfCode.Day22.Spells;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartOne
    {
        private Character _player;
        private Character _boss;

        [SetUp]
        public void SetUp()
        {
            _player = new Character(50, 0, 0, 500);
            _boss = new Character(58, 9, 0, 0);
        }

        [Test]
        public void Should_Find_Least_Amount_Of_Mana_Needed_To_Win_Fight()
        {
            new Battle().FindLowestManaNeededToWinFight().Should().Be(1269);
        }

        [Test]
        public void Magic_Missile_Should_Deal_Four_Damage()
        {
            new MagicMissile().Cast(_player, _boss);
            _boss.Hp.Should().Be(54);
        }

        [Test]
        public void Magic_Missile_Should_Cost_53_Mana()
        {
            new MagicMissile().Cost.Should().Be(53);
        }

        [Test]
        public void Drain_Should_Deal_Two_Damage_And_Heal_For_Two()
        {
            new Drain().Cast(_player, _boss);
            _player.Hp.Should().Be(52);
            _boss.Hp.Should().Be(56);
        }

        [Test]
        public void Drain_Should_Cost_73_Mana()
        {
            new Drain().Cost.Should().Be(73);
        }

        [Test]
        public void Poison_Should_Cost_173_Mana()
        {
            new Poison().Cost.Should().Be(173);
        }

        [Test]
        public void Recharge_Should_Cost_229()
        {
            new Recharge().Cost.Should().Be(229);
        }

        [Test]
        public void Shield_Should_Cost_113_Mana()
        {
            new Shield().Cost.Should().Be(113);
        }
    }
}
