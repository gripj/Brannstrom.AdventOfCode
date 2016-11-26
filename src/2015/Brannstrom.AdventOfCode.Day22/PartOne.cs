using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day22.Characters;
using Brannstrom.AdventOfCode.Day22.Spells;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day22
{
    [TestFixture]
    public class PartOne
    {
        private Wizard _player;
        private Character _boss;

        [SetUp]
        public void SetUp()
        {
            _player = new Wizard(50, 0, 0, 500);
            _player.LearnAllSpells();
            _boss = new Character(58, 9, 0, 0);
        }

        [Test]
        public void Should_Find_Least_Amount_Of_Mana_Needed_To_Win_Fight()
        {
            new Battle(_player, _boss).FindLowestManaNeededToWinFight().Should().Be(1269);
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
        public void Poison_Should_Deal_3_Damage_For_6_Turns()
        {
            var startingHp = _boss.Hp;
            new Poison().Cast(_player, _boss);
            ApplySpellEffects(_boss);
            _boss.Hp.Should().Be(startingHp - 18);
        }

        [Test]
        public void Poison_Should_Cost_173_Mana()
        {
            new Poison().Cost.Should().Be(173);
        }

        [Test]
        public void Recharge_Should_Add_101_Mana_For_5_Turns()
        {
            var startingMana = _player.Mana;
            var recharge = new Recharge();
            recharge.Cast(_player, _player);
            ApplySpellEffects(_player);
            _player.Mana.Should().Be(startingMana - recharge.Cost + 505);
        }

        [Test]
        public void Recharge_Should_Cost_229()
        {
            new Recharge().Cost.Should().Be(229);
        }

        [Test]
        public void Shield_Should_Set_Armor_To_7_for_6_Turns()
        {
            _player.Armor.Should().Be(0);
            new Shield().Cast(_player, _player);
            for (var i = 0; i < 5; i++)
            {
                _player.ApplyEffects();
                _player.Armor.Should().Be(7);
            }
            _player.ApplyEffects();
            _player.Armor.Should().Be(0);
        }

        [Test]
        public void Shield_Should_Cost_113_Mana()
        {
            new Shield().Cost.Should().Be(113);
        }

        [Test]
        public void Player_Should_Be_Able_To_Learn_All_Spells()
        {
            var player = new Wizard(50, 0, 0, 500);
            player.SpellBook.Should().BeNull();
            player.LearnAllSpells();
            player.SpellBook.Spells.Distinct().Count().Should().Be(5);
        }

        [Test]
        public void Player_Should_Win_Example_Battle_One()
        {
            var player = new Wizard(10, 0, 0, 250);
            var boss = new Character(13, 8, 0, 0);
            player.LearnSpells(new List<ISpell>()
            {
                new Poison(),
                new MagicMissile()
            });
            new Battle(player, boss).FindLowestManaNeededToWinFight().Should().Be(226);
        }

        [Test]
        public void Player_Should_Win_Example_Battle_Two()
        {
            var player = new Wizard(10, 0, 0, 250);
            var boss = new Character(14, 8, 0, 0);
            player.LearnAllSpells();
            new Battle(player, boss).FindLowestManaNeededToWinFight().Should().Be(641);
        }

        private static void ApplySpellEffects(Character character)
        {
            for (var i = 0; i < 10; i++)
                character.ApplyEffects();
        }
    }
}
