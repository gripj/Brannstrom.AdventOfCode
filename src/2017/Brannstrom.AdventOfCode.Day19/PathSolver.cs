using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day19
{
    public class PathSolver
    {
        public (string Letters, int Steps) FollowPath(IEnumerable<string> input)
        {
            var map = input.ToList();
            var (columnSize, rowSize) = (map[0].Length, map.Count);
            var (column, row) = (map[0].IndexOf('|'), 0);
            var (deltaColumn, deltaRow) = (0, 1);

            var letters = "";
            var steps = 0;

            while (true)
            {
                row += deltaRow;
                column += deltaColumn;
                steps++;

                var hasReachedEnd = column < 0 || column >= columnSize || row < 0 || row >= rowSize || map[row][column] == ' ';
                if (hasReachedEnd)
                    break;

                switch (map[row][column])
                {
                    case '+':
                        (deltaColumn, deltaRow) = (
                            from q in new[] { (deltaRow: deltaColumn, deltaColumn: -deltaRow), (deltaRow: -deltaColumn, deltaColumn: deltaRow) }
                            let colT = column + q.deltaColumn
                            let rowT = row + q.deltaRow
                            where colT >= 0 && colT < columnSize && rowT >= 0 && rowT < rowSize && map[rowT][colT] != ' '
                            select (q.deltaColumn, q.deltaRow)
                        ).Single();
                        break;
                    case char @char when (@char >= 'A' && @char <= 'Z'):
                        letters += @char;
                        break;
                }
            }

            return (letters, steps);
        }
    }
}
