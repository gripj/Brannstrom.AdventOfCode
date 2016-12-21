namespace Brannstrom.AdventOfCode.Day18
{
    public class Tile
    {
        public bool IsSafe { get; }
        public bool IsTrap => !IsSafe;

        public Tile(bool isSafe)
        {
            IsSafe = isSafe;
        }

        public static Tile Parse(char input)
        {
            var isSafe = input == '.';
            return new Tile(isSafe);
        }
    }
}
