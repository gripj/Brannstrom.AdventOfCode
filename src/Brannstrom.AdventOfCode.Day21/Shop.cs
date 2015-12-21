using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day21.Items;

namespace Brannstrom.AdventOfCode.Day21
{
    public class Shop
    {
        public List<Item> Items { get; private set; }

        public Shop()
        {
            WithItems();
        }

        private void WithItems()
        {
            Items = new List<Item>();
            AddWeapons();
            AddArmor();
            AddRings();
        }

        private void AddWeapons()
        {
            Items.AddRange(new List<Weapon>()
            {
                new Weapon("Dagger", 8, 4),
                new Weapon("Shortsword", 10, 5),
                new Weapon("Warhammer", 25, 6),
                new Weapon("Longsword", 40, 7),
                new Weapon("Greataxe", 74, 8)
            });
        }

        private void AddArmor()
        {
            Items.AddRange(new List<Armor>()
            {
                new Armor("Leather", 13, 1),
                new Armor("Chainmail", 31, 2),
                new Armor("Splintmail", 53, 3),
                new Armor("Bandedmail", 75, 4),
                new Armor("Platemail", 102, 5)
            });
        }

        private void AddRings()
        {
            Items.AddRange(new List<Ring>()
            {
                new Ring("Damage +1", 25, 1, 0),
                new Ring("Damage +2", 50, 2, 0),
                new Ring("Damage +3", 100, 3, 0),
                new Ring("Defense +1", 20, 0, 1),
                new Ring("Defense +2", 40, 0, 2),
                new Ring("Defense +3", 80, 0, 3)
            });
        }

        public IEnumerable<IEnumerable<Item>> GetValidItemSets()
        {
            var allItemCombinations = GetPowerSet<Item>(Items);

            return allItemCombinations
                .Where(IsValidCollection)
                .ToList();
        }

        private IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }

        private bool IsValidCollection(IEnumerable<Item> items)
        {
            return items.Count(x => x is Weapon) == 1 &&
                   items.Count(x => x is Armor) <= 1 &&
                   items.Count(x => x is Ring) <= 2;
        }
    }
}
