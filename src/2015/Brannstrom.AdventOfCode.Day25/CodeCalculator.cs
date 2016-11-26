namespace Brannstrom.AdventOfCode.Day25
{
    public class CodeCalculator
    {
        private const long FirstCode = 20151125L;
        public readonly int Multiplier = 252533;
        public readonly int Divider = 33554393;

        public long Calculate(int row, int column)
        {
            var code = FirstCode;
            var codeNumber = GetCodeNumber(row, column);

            for (var i = 1; i < codeNumber; i++)
                code = CalculateNextCode(code);

            return code;
        }

        private static int GetCodeNumber(int row, int column)
        {
            var position = row + column - 2;
            position = position * (position + 1) / 2 + column;
            return position;
        }

        private long CalculateNextCode(long code)
        {
            code *= Multiplier;
            code %= Divider;
            return code;
        }
    }
}
