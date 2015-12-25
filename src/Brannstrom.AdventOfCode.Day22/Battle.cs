using Brannstrom.AdventOfCode.Day22.Characters;
using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Battle
    {
        private bool _hardDifficultyEnabled;
        private PriorityQueue<Turn> _turns;
        private Turn _previousTurn;
        private readonly Wizard _player;
        private readonly Character _boss;

        public Battle(Wizard player, Character boss)
        {
            _player = player;
            _boss = boss;
        }

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
            foreach (var spell in _player.SpellBook.Spells)
                Fight(spell, manaSpent + spell.Cost);
        }

        private void Fight(ISpell spell, int manaSpent)
        {
            var turn = new Turn(_player, _boss, spell, manaSpent, _previousTurn);
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
