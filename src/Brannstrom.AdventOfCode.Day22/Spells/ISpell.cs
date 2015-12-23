namespace Brannstrom.AdventOfCode.Day22.Spells
{
    public interface ISpell
    {
        int Cost { get; }
        void Cast(Character owner, Character target);
        ISpell Copy();
    }
}
