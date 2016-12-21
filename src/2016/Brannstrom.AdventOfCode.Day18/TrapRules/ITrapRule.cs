using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day18.TrapRules
{
    public interface ITrapRule
    {
        bool IsTrap(List<Tile> tiles);
    }
}
