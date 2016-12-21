namespace Brannstrom.AdventOfCode.Day19
{
    public class Elf
    {
        public int Id { get; }
        public Elf Left { get; set; }
        public Elf Right { get; set; }

        public Elf(int id)
        {
            Id = id;
        }
    }
}
