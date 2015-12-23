using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Character
    {
        public int Hp { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public int Mana { get; set; }

        public Character(int hp, int damage, int armor, int mana)
        {
            Hp = hp;
            Armor = armor;
            Damage = damage;
            Mana = mana;
        }

        public bool IsAlive => Hp > 0;
        public List<Tuple<string, int>> ActiveEffects { get; set; } 

        public void ApplyEffects()
        {
            if (PoisonTurns > 0)
            {
                PoisonTurns--;
                Hp -= 3;
            }

            if (RechargeTurns > 0)
            {
                RechargeTurns--;
                Mana += 101;
            }

            if (ShieldTurns > 0)
            {
                ShieldTurns--;
                Armor = 7;
            }
            else
            {
                Armor = 0;
            }
        }

        public int RechargeTurns { get; set; }
        public int PoisonTurns { get; set; }
        public int ShieldTurns { get; set; }

        public void Attack(Character target)
        {
            target.Hp -= Math.Max(1, Damage - target.Armor);
        }
    }
}
