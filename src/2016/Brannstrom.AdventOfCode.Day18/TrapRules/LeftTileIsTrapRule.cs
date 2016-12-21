using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day18.TrapRules
{
    public class LeftTileIsTrapRule : ITrapRule
    {
        public bool IsTrap(List<Tile> tiles)
        {
            return tiles[0].IsTrap && tiles[1].IsSafe && tiles[2].IsSafe;
        }
    }
}
