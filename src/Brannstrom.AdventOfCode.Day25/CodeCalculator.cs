namespace Brannstrom.AdventOfCode.Day25
{
    public class CodeCalculator
    {
        public long Calculate(int row, int column)
        {
            var code = 20151125L;
            var gridPosition = GetPositionInGrid(row, column);

            for (var i = 1; i < gridPosition; i++)
            {
                code *= 252533;
                code %= 33554393;
            }

            return code;
        }

        private static int GetPositionInGrid(int row, int column)
        {
            var position = row + column - 2;
            position = position * (position + 1) / 2 + column;
            return position;
        }
    }
}
