using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day21
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Maximum_Value_Of_Items_Where_Player_Loses()
        {
            var shop = new Shop();
            var itemSetValues = new List<int>();
            foreach (var itemSet in shop.GetValidItemSets())
            {
                var player = new Character(100, 0, 0)
                {
                    Inventory = itemSet.ToList()
                };
                var boss = new Character(100, 8, 2);

                var duel = new Duel(player, boss);
                duel.Fight();

                if (!player.IsAlive)
                    itemSetValues.Add(player.GetItemsValue);
            }
            itemSetValues.Max().Should().Be(158);
        }
    }
}
