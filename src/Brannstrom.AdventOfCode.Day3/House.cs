namespace Brannstrom.AdventOfCode.Day3
{
    public class House
    {
        public int HorizontalPosition { get; }
        public int VerticalPosition { get; }

        public House(int x, int y)
        {
            HorizontalPosition = x;
            VerticalPosition = y;
        }

        public override bool Equals(object obj)
        {
            return (obj is House) && (HorizontalPosition == ((House) obj).HorizontalPosition &&
                                      VerticalPosition == ((House) obj).VerticalPosition);
        }
    }
}
