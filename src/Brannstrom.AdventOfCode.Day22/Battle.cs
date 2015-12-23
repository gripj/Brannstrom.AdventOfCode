using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Battle
    {
        private bool _hardDifficultyEnabled;
        private readonly SpellBook _spellBook = new SpellBook();
        private PriorityQueue<Turn> _turns;
        private Turn _previousTurn;

        public void EnableHardDifficulty()
        {
            _hardDifficultyEnabled = true;
        }

        public int FindLowestManaNeededToWinFight()
        {
            FightFirstTurn();

            while (_turns.Count > 0)
            {
                var turn = _turns.ExtractMax();
                if (turn.PlayerWon)
                    return turn.TotalManaSpent;

                _previousTurn = turn;
                FightPossibleTurns();
            }

            return -1;
        }

        private void FightFirstTurn()
        {
            _turns = new PriorityQueue<Turn>(comparer: Turn.ManaCostComparer);
            _previousTurn = null;
            FightPossibleTurns();
        }

        private void FightPossibleTurns()
        {
            var manaSpent = _previousTurn?.TotalManaSpent ?? 0;
            foreach (var spell in _spellBook.Spells)
            {
                var newSpell = spell.Copy();
                Fight(newSpell, manaSpent + newSpell.Cost);
            }
        }

        private void Fight(ISpell spell, int manaSpent)
        {
            var turn = new Turn(spell, manaSpent, _previousTurn);
            var duel = new Duel();
            ToggleDifficulty(duel);
            FightOneTurn(turn, duel);
        }

        private void ToggleDifficulty(Duel duel)
        {
            if (_hardDifficultyEnabled)
                duel.EnableHardDifficulty();
        }

        private void FightOneTurn(Turn turn, Duel duel)
        {
            var result = duel.Fight(turn);
            if (result == TurnResult.ContinueFight)
                _turns.Add(turn);

            if (result == TurnResult.PlayerWon)
            {
                turn.PlayerWon = true;
                _turns.Add(turn);
            }
        }
    }
}
