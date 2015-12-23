namespace Brannstrom.AdventOfCode.Day22.Spells
{
    public class Drain : ISpell
    {
        public void Cast(Character owner, Character target)
        {
            owner.Mana -= Cost;
            target.Hp -= 2;
            owner.Hp += 2;
        }

        public ISpell Copy()
        {
            return new Drain();
        }

        public int Cost => 73;
    }
}
