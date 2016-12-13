namespace Brannstrom.AdventOfCode.Day12
{
    public class Register
    {
        public string Id { get; }
        public int Value { get; private set; }

        public Register(string id)
        {
            Id = id;
        }

        public Register(string id, int value)
        {
            Id = id;
            Value = value;
        }

        public void SetValue(int value)
        {
            Value = value;
        }
    }
}
