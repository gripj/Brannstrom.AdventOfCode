using System;

namespace Brannstrom.AdventOfCode.Day22.Characters
{
    public class Character
    {
        public int Hp { get; set; }
        public int Armor { get; private set; }
        public int Damage { get; set; }
        public int Mana { get; set; }

        private int StartingHp { get; }
        private int StartingArmor { get; }
        private int StartingMana { get; }

        public Character(int hp, int damage, int armor, int mana)
        {
            Hp = hp;
            Armor = armor;
            Damage = damage;
            Mana = mana;

            StartingHp = hp;
            StartingArmor = armor;
            StartingMana = mana;
        }

        public bool IsAlive => Hp > 0;

        public void ApplyEffects()
        {
            HandlePoison();
            HandleRecharge();
            HandleShield();
        }

        private void HandlePoison()
        {
            if (PoisonTurns <= 0) return;
            PoisonTurns--;
            Hp -= 3;
        }

        private void HandleRecharge()
        {
            if (RechargeTurns <= 0) return;
            RechargeTurns--;
            Mana += 101;
        }

        private void HandleShield()
        {
            if (ShieldTurns > 0)
            {
                ShieldTurns--;
                Armor = 7;
            }
            else
                Armor = 0;
        }

        public int RechargeTurns { get; set; }
        public int PoisonTurns { get; set; }
        public int ShieldTurns { get; set; }

        public void Attack(Character target)
        {
            target.Hp -= Math.Max(1, Damage - target.Armor);
        }

        public Character Clone()
        {
            return new Character(StartingHp, Damage, StartingArmor, StartingMana);
        }

        public void Copy(Character character)
        {
            Hp = character.Hp;
            Mana = character.Mana;
            ShieldTurns = character.ShieldTurns;
            RechargeTurns = character.RechargeTurns;
            PoisonTurns = character.PoisonTurns;
        }
    }
}
