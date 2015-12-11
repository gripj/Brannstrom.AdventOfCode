namespace Brannstrom.AdventOfCode.Day3
{
    public class House
    {
        public int X { get; }
        public int Y { get; }

        public House(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return (obj is House) && (X == ((House) obj).X &&
                                      Y == ((House) obj).Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
}