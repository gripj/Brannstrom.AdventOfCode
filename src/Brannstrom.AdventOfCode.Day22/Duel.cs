using Brannstrom.AdventOfCode.Day22.Spells;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Duel
    {
        private bool _hardDifficultyEnabled;
        private Turn _turn;
        private Character _player;
        private Character _boss;
        private ISpell _spell;

        public TurnResult Fight(Turn turn)
        {
            StartWhereLastTurnEnded(turn);
            ApplyDifficulty();

            for (var t = 0; t < 2; t++)
            {
                if (SomeoneDied) return GetWinner();
                ApplySpellEffects();
                if (SomeoneDied) return GetWinner();

                if (t == 0)
                {
                    if (SpellIsIllegal()) return TurnResult.Illegal;
                    _spell.Cast(_player, _boss);
                } 
                else _boss.Attack(_player);
            }

            return GetEndOfTurnResult();
        }

        private void StartWhereLastTurnEnded(Turn turn)
        {
            _turn = turn;
            _player = _turn.Player;
            _boss = _turn.Boss;
            _spell = _turn.Spell;
            CopyValuesFromLastTurn();
        }

        private void ApplyDifficulty()
        {
            if (_hardDifficultyEnabled)
                _player.Hp--;
        }

        private void ApplySpellEffects()
        {
            _boss.ApplyEffects();
            _player.ApplyEffects();
        }

        private bool SomeoneDied => !_player.IsAlive || !_boss.IsAlive;

        private TurnResult GetWinner()
        {
            return !_player.IsAlive ? 
                TurnResult.PlayerLost : 
                TurnResult.PlayerWon;
        }

        private void CopyValuesFromLastTurn()
        {
            var previousTurn = _turn.PreviousTurn;
            if (previousTurn == null) return;

            _boss.Copy(previousTurn.Boss);
            _player.Copy(previousTurn.Player);
        }

        private bool SpellIsIllegal()
        {
            var spellIsTooExpensive = _player.Mana < _spell.Cost; ;
            var isActivePoison = _spell is Poison && _boss.PoisonTurns > 0;
            var isActiveRecharge = _spell is Recharge && _player.RechargeTurns > 0;
            var isActiveShield = _spell is Shield && _player.ShieldTurns > 0;

            return (spellIsTooExpensive || isActivePoison || isActiveRecharge || isActiveShield);
        }

        private TurnResult GetEndOfTurnResult()
        {
            return !_player.IsAlive ?
                TurnResult.PlayerLost : TurnResult.ContinueFight;
        }

        public void EnableHardDifficulty()
        {
            _hardDifficultyEnabled = true;
        }
    }
}
