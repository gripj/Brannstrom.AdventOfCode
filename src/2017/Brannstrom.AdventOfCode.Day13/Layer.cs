namespace Brannstrom.AdventOfCode.Day13
{
    public class Layer
    {
        public int Depth { get; }
        public int Range { get; }

        private readonly SecurityScanner _scanner;

        public Layer(int depth, int range)
        {
            Depth = depth;
            Range = range;
            _scanner = new SecurityScanner(range);
        }

        public bool IsSecure => _scanner.CurrentPosition == 1;
        public void PassTime() => _scanner.Move();
    }
}
