using System;
using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day10;

namespace Brannstrom.AdventOfCode.Day14
{
    public class DiskDefragmenter
    {
        private readonly string _key;

        public DiskDefragmenter(string key)
        {
            _key = key;
        }

        public int CalculateAmountOfUsedSquares()
        {
            return CreateGrid().Select(row => row.Count(c => c == '#')).Sum();
        }

        public int CalculateNumberOfRegions()
        {
            var grid = CreateGrid().Select(row => row.ToCharArray()).ToArray();
            var regions = 0;

            for (var row = 0; row < grid.Count(); row++)
                for (var column = 0; column < grid[0].Count(); column++)
                    if (grid[row][column] == '#')
                    {
                        regions++;
                        FillGrid(grid, (row, column));
                    }

            return regions;
        }

        private IEnumerable<string> CreateGrid()
        {
            for (var rowNumber = 0; rowNumber < 128; rowNumber++)
            {
                var row = "";
                var denseHash = KnotHasher.DenseHash((_key + "-" + rowNumber));

                foreach (var digit in denseHash)
                    for (var bit = 0; bit < 8; bit++)
                    {
                        var squareIsUsed = (digit & (1 << (7 - bit))) != 0;
                        if (squareIsUsed)
                            row += "#";
                        else
                            row += ".";
                    }

                yield return row;
            }
        }

        private static void FillGrid(IReadOnlyList<char[]> grid, (int, int) firstCell)
        {
            var q = new Queue<(int row, int column)>();
            q.Enqueue(firstCell);

            while (q.Any())
            {
                var (row, column) = q.Dequeue();
                grid[row][column] = ' ';

                var neighbourCells =
                    from deltaRow in new[] { -1, 0, 1 }
                    from deltaColumn in new[] { -1, 0, 1 }
                    where Math.Abs(deltaRow) + Math.Abs(deltaColumn) == 1

                    let neighborColumn = column + deltaColumn
                    let neighborRow = row + deltaRow

                    where neighborColumn >= 0 &&
                          neighborColumn < grid.Columns() &&
                          neighborRow >= 0 &&
                          neighborRow < grid.Rows() &&
                          grid[neighborRow][neighborColumn] == '#'

                    select (neighborRow, neighborColumn);

                foreach (var neighbourCell in neighbourCells)
                    q.Enqueue(neighbourCell);
            }
        }
    }

    public static class GridExtensions
    {
        public static int Columns(this IReadOnlyList<char[]> grid) => grid[0].Count();
        public static int Rows(this IReadOnlyList<char[]> grid) => grid.Count();
    }
}
