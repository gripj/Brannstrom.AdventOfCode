using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day21.Items;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartOne
    {
        private Character _player;
        private Character _boss;

        [SetUp]
        public void SetUp()
        {
            _player = new Character(100, 0, 0);
            _boss = new Character(100, 8, 2);
        }

        [Test]
        public void Should_Get_Cost_Of_Cheapest_Item_Set_Where_Player_Wins()
        {
            var shop = new Shop();
            var itemSetValues = new List<int>();
            foreach (var itemSet in shop.GetValidItemSets())
            {
                PrepareForDuel(itemSet);
                Duel();
                if (_player.IsAlive)
                    itemSetValues.Add(_player.GetItemsValue);
            }
            itemSetValues.Min().Should().Be(91);
        }

        [Test]
        public void Attack_Should_Always_Deal_At_Least_One_Damage()
        {
            _player.Attack(_boss);
            _boss.Hp.Should().Be(99);
        }

        [Test]
        public void Attack_Should_Be_Able_To_Deal_More_Than_One_Damage()
        {
            _player.Inventory.Add(new Weapon("Excalibur", 10000, 100));
            _player.Attack(_boss);
            _boss.Hp.Should().Be(2);
        }

        [Test]
        public void Player_With_No_Items_Should_Lose_To_Boss()
        {
            Duel();
            _player.IsAlive.Should().BeFalse();
            _boss.IsAlive.Should().BeTrue();
        }

        [Test]
        public void Player_With_Good_Items_Should_Win_Over_Boss()
        {
            _player.Inventory.Add(new Weapon("Excalibur", 10000, 100));
            Duel();
            _player.IsAlive.Should().BeTrue();
            _boss.IsAlive.Should().BeFalse();
        }

        [Test]
        public void Total_Damage_Dealt_Should_Be_Sum_Of_All_Item_Damage_Stats()
        {
            _player.Inventory.Add(new Weapon("Shortsword", 10, 5));
            _player.Inventory.Add(new Ring("Damage +2", 50, 2, 0));
            _player.Damage.Should().Be(7);
        }

        [Test]
        public void Total_Damage_Dealt_Should_Be_Sum_Of_All_Item_Armor_Stats()
        {
            _player.Inventory.Add(new Armor("Chainmail", 31, 2));
            _player.Inventory.Add(new Ring("Defense +3", 80, 0, 3));
            _player.Armor.Should().Be(5);
        }

        [Test]
        public void Shop_Should_Provide_Possible_Item_Configurations_For_Player()
        {
            var shop = new Shop();
            shop.GetValidItemSets().Count().Should().Be(660);
        }

        [Test]
        public void Player_Should_Provide_Total_Value_Of_Items()
        {
            _player.Inventory.Add(new Weapon("Excalibur", 10000, 100));
            _player.Inventory.Add(new Armor("Leather", 20, 4));
            _player.GetItemsValue.Should().Be(10020);
        }

        private void Duel()
        {
            var duel = new Duel(_player, _boss);
            duel.Fight();
        }

        private void PrepareForDuel(IEnumerable<Item> items)
        {
            ReviveCombatants();
            _player.Inventory = items.ToList();
        }

        private void ReviveCombatants()
        {
            _player.Hp = 100;
            _boss.Hp = 100;
        }
    }
}
