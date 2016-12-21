using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day18.TrapRules;

namespace Brannstrom.AdventOfCode.Day18
{
    public class TrapTileAnalyzer
    {
        private readonly IEnumerable<ITrapRule> _trapRules;

        public TrapTileAnalyzer(IEnumerable<ITrapRule> trapRules)
        {
            _trapRules = trapRules;
        }

        public List<List<Tile>> GenerateTileLayout(List<Tile> firstRow, int rowsToGenerate)
        {
            var tileLayout = new List<List<Tile>>() { firstRow };

            while (tileLayout.Count < rowsToGenerate)
            {
                var newRow = new List<Tile>();

                for (var i = 0; i < firstRow.Count; i++)
                {
                    var firstTile = GetTileFromRow(tileLayout.Last(), i - 1);
                    var secondTile = GetTileFromRow(tileLayout.Last(), i);
                    var thirdTile = GetTileFromRow(tileLayout.Last(), i + 1);

                    var tiles = new List<Tile>() { firstTile, secondTile, thirdTile };

                    var newTileIsSafe = _trapRules.All(x => !x.IsTrap(tiles));
                    newRow.Add(new Tile(newTileIsSafe));
                }

                tileLayout.Add(newRow);
            }

            return tileLayout;
        }

        private static Tile GetTileFromRow(IReadOnlyList<Tile> row, int index)
        {
            var isImaginarySafeTile = index < 0 || index >= row.Count;
            return !isImaginarySafeTile ? row[index] : new Tile(true);
        } 
    }
}
