using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day15.GameBlocks
{
    public class Player : Block
    {
        public (int x, int y) Pos { get; private set; }
        public bool IsElf { get; }
        public int Hp { get; private set; }
        private Game _game { get; }
        private int _ap { get; }

        public Player(bool isElf, (int x, int y) pos, Game game, int ap = 3)
        {
            IsElf = isElf;
            Pos = pos;
            _game = game;
            _ap = ap;
            Hp = 200;
        }

        public bool Step()
        {
            if (Hp <= 0)
            {
                return false;
            }
            else if (Attack())
            {
                return true;
            }
            else if (Move())
            {
                Attack();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Move()
        {
            var opponents = GetClosestOpponents();
            if (!opponents.Any())
                return false;

            var opponent = opponents.OrderBy(a => a.player.Pos).First();
            var nextPos = opponents.Where(a => a.player == opponent.player).Select(a => a.firstStep).OrderBy(_ => _).First();
            (_game.Map[nextPos.irow, nextPos.icol], _game.Map[Pos.x, Pos.y]) =
                (_game.Map[Pos.x, Pos.y], _game.Map[nextPos.irow, nextPos.icol]);
            Pos = nextPos;
            return true;
        }

        private IEnumerable<(Player player, (int irow, int icol) firstStep)> GetClosestOpponents()
        {
            var minDist = int.MaxValue;
            foreach (var (otherPlayer, firstStep, dist) in GetOpponentsByDistance())
            {
                if (dist > minDist)
                    break;

                minDist = dist;
                yield return (otherPlayer, firstStep);
            }
        }

        private IEnumerable<(Player player, (int irow, int icol) firstStep, int dist)> GetOpponentsByDistance()
        {
            var seen = new HashSet<(int x, int y)> { Pos };
            var q = new Queue<((int x, int y) pos, (int x, int y) origDir, int dist)>();

            foreach (var (x, y) in new[] { (-1, 0), (0, -1), (0, 1), (1, 0) })
            {
                var posT = (Pos.x + x, Pos.y + y);
                q.Enqueue((posT, posT, 1));
            }

            while (q.Any())
            {
                var (pos, firstStep, dist) = q.Dequeue();
                switch (_game.GetBlock(pos))
                {
                    case Player otherPlayer when this != otherPlayer && otherPlayer.IsElf != IsElf:
                        yield return (otherPlayer, firstStep, dist);
                        break;

                    case Wall _:
                        break;

                    case Empty _:
                        foreach (var (x, y) in new[] { (-1, 0), (0, -1), (0, 1), (1, 0) })
                        {
                            var posT = (pos.x + x, pos.y + y);
                            if (!seen.Contains(posT))
                            {
                                seen.Add(posT);
                                q.Enqueue((posT, firstStep, dist + 1));
                            }
                        }
                        break;
                }
            }
        }

        private bool Attack()
        {
            var opponents = new List<Player>();

            foreach (var (x, y) in new[] { (-1, 0), (0, -1), (0, 1), (1, 0) })
            {
                var posT = (Pos.x + x, Pos.y + y);
                var block = _game.GetBlock(posT);
                switch (block)
                {
                    case Player otherPlayer when otherPlayer.IsElf != IsElf:
                        opponents.Add(otherPlayer);
                        break;
                }
            }

            if (!opponents.Any())
                return false;

            var minHp = opponents.Select(a => a.Hp).Min();
            var opponent = opponents.First(a => a.Hp == minHp);
            opponent.Hp -= this._ap;
            if (opponent.Hp <= 0)
            {
                _game.Players.Remove(opponent);
                _game.Map[opponent.Pos.x, opponent.Pos.y] = Empty.Block;
            }
            return true;
        }

    }
}
