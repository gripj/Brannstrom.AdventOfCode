using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Turn
    {
        public Turn(ISpell spell, int totalManaSpent, Turn previousTurn)
        {
            Spell = spell;
            TotalManaSpent = totalManaSpent;
            PreviousTurn = previousTurn;
            Player = new Character(50, 0, 0, 500);
            Boss = new Character(58, 9, 0, 0);
        }

        public Turn PreviousTurn { get; }
        public Character Player { get; }
        public Character Boss { get; }
        public ISpell Spell { get; }
        public int TotalManaSpent { get; }

        public bool PlayerWon { get; set; }

        private sealed class CostComparer : IComparer<Turn>
        {
            public int Compare(Turn x, Turn y)
            {
                return y.TotalManaSpent.CompareTo(x.TotalManaSpent);
            }
        }

        public static IComparer<Turn> ManaCostComparer { get; } = new CostComparer();
    }
}
