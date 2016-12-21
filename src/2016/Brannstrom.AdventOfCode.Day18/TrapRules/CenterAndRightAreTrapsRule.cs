using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day18.TrapRules
{
    public class CenterAndRightAreTrapsRule : ITrapRule
    {
        public bool IsTrap(List<Tile> tiles)
        {
            return tiles[0].IsSafe && tiles[1].IsTrap && tiles[2].IsTrap;
        }
    }
}
