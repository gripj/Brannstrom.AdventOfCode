using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day21.Items;

namespace Brannstrom.AdventOfCode.Day21
{
    public class Character
    {
        private int BaseDamage { get; }
        private int BaseArmor { get; }

        public Character(int hp, int baseDamage, int baseArmor)
        {
            Hp = hp;
            BaseDamage = baseDamage;
            BaseArmor = baseArmor;
            Inventory = new List<Item>();
        }

        public int Hp { get; set; }
        public bool IsAlive => Hp > 0;

        public List<Item> Inventory { get; set; }

        public int Damage =>
            BaseDamage + Inventory.Where(item => item is Weapon || item is Ring).Sum(item => item.Damage);

        public int Armor => 
            BaseArmor + Inventory.Where(x => x is Armor || x is Ring).Sum(item => item.Armor);

        public int GetItemsValue => Inventory.Sum(x => x.Cost);

        public void Attack(Character character)
        {
            var damage = Damage - character.Armor > 1 ? Damage - character.Armor : 1;
            character.Hp -= damage;
        }
    }
}
