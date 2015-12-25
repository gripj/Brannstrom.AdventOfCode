using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22.Characters
{
    public class Wizard : Character
    {
        public SpellBook SpellBook { get; private set; }

        public Wizard(int hp, int damage, int armor, int mana) 
            : base(hp, damage, armor, mana)
        {
        }

        public void LearnSpells(IEnumerable<ISpell> spells)
        {
            SpellBook = new SpellBook(spells);
        }

        public void LearnAllSpells()
        {
            var allSpells = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(ISpell))
                                     && t.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(t) as ISpell;
            SpellBook = new SpellBook(allSpells);
        }


    }
}
