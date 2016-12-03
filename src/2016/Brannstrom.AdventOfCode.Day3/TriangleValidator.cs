namespace Brannstrom.AdventOfCode.Day3
{
    public class TriangleValidator
    {
        public bool Validate(int a, int b, int c)
        {
            return (a + b) > c && (a + c) > b && (b + c) > a;
        }
    }
}
