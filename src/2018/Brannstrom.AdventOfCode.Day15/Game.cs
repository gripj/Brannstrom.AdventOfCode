using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day15.GameBlocks;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Game
    {
        public Block[,] Map;
        public List<Player> Players;

        public Game(Block[,] map, List<Player> players)
        {
            Map = map;
            Players = players;
        }

        private bool IsValidPosition((int x, int y) pos) =>
            pos.x >= 0 && pos.y < Map.GetLength(0) && pos.y >= 0 && pos.y < Map.GetLength(1);

        public Block GetBlock((int irow, int icol) pos) =>
            IsValidPosition(pos) ? Map[pos.irow, pos.icol] : Wall.Block;

        public bool Step() =>
            Players
                .OrderBy(a => a.Pos)
                .Aggregate(false, (res, player) => res | player.Step());

        public static Game Parse(IEnumerable<string> input, int goblinAp, int elfAp)
        {
            var players = new List<Player>();
            var lines = input.ToArray();
            var map = new Block[lines.Length, lines[0].Length];
            var game = new Game(map, players);

            for (var x = 0; x < lines.Length; x++)
                for (var y = 0; y < lines[0].Length; y++)
                    switch (lines[x][y])
                    {
                        case '#':
                            map[x, y] = Wall.Block;
                            break;
                        case '.':
                            map[x, y] = Empty.Block;
                            break;
                        case var ch when ch == 'G' || ch == 'E':
                            var player = new Player(ch == 'E', (x: x, y: y), game, ch == 'E' ? elfAp : goblinAp);

                            players.Add(player);
                            map[x, y] = player;
                            break;
                    }

            return game;
        }
    }
}
