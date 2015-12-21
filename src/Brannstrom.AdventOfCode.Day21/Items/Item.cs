namespace Brannstrom.AdventOfCode.Day21.Items
{
    public class Item
    {
        public Item(string name, int cost, int damage, int armor)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Armor = armor;
        }

        public string Name { get; }
        public int Cost { get; }
        public int Damage { get; }
        public int Armor { get; }
    }
}
