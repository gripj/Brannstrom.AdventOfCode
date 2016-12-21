using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day18.TrapRules
{
    public class LeftAndCenterAreTrapsRule : ITrapRule
    {
        public bool IsTrap(List<Tile> tiles)
        {
            return tiles[0].IsTrap && tiles[1].IsTrap && tiles[2].IsSafe;
        }
    }
}
