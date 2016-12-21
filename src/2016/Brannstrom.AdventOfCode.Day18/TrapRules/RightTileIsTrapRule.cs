using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day18.TrapRules
{
    public class RightTileIsTrapRule : ITrapRule
    {
        public bool IsTrap(List<Tile> tiles)
        {
            return tiles[0].IsSafe && tiles[1].IsSafe && tiles[2].IsTrap;
        }
    }
}
