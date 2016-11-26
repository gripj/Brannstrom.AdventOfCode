using System.Collections.Generic;
using Brannstrom.AdventOfCode.Day22.Characters;
using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Turn
    {
        public Turn(Character player, Character boss, ISpell spell, int totalManaSpent, Turn previousTurn)
        {
            Spell = spell;
            TotalManaSpent = totalManaSpent;
            PreviousTurn = previousTurn;
            Player = player.Clone();
            Boss = boss.Clone();
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
