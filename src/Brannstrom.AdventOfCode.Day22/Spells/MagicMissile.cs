namespace Brannstrom.AdventOfCode.Day22.Spells
{
    public class MagicMissile : ISpell
    {
        public void Cast(Character owner, Character target)
        {
            owner.Mana -= Cost;
            target.Hp -= 4;
        }

        public ISpell Copy()
        {
            return new MagicMissile();
        }

        public int Cost => 53;
    }
}
