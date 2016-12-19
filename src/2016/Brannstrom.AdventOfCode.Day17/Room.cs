namespace Brannstrom.AdventOfCode.Day17
{
    public class Room
    {
        public int X { get; }
        public int Y { get; }
        public string Path { get; }

        public Room(int x, int y, string path = "")
        {
            X = x;
            Y = y;
            Path = path;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Room;
            return other != null && Path == other.Path;
        }

        public override int GetHashCode() => Path.GetHashCode();
    }
}
