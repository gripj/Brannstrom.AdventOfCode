namespace Brannstrom.AdventOfCode.Day13
{
    public class Packet
    {
        public int Position { get; private set; }
        public int Severity { get; private set; }

        public Packet()
        {
            Position = -1;
        }

        public void Move(Layer nextLayer)
        {
            if (nextLayer != null && nextLayer.IsSecure)
            {
                Severity = Severity + (nextLayer.Depth * nextLayer.Range);
            }

            Position++;
        }
    }
}
