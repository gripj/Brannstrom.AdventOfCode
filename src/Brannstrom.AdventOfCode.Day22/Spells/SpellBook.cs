using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day22.Spells
{
    public class SpellBook
    {
        public IEnumerable<ISpell> Spells { get; }

        public SpellBook()
        {
            Spells = new List<ISpell>()
            {
                new Drain(),
                new MagicMissile(),
                new Poison(),
                new Recharge(),
                new Shield()
            };
        } 
    }
}
