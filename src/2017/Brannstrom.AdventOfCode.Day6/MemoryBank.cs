using System.Linq;

namespace Brannstrom.AdventOfCode.Day6
{
    public class MemoryBank
    {
        public int MemoryBlocks { get; private set; }

        public MemoryBank(int memoryBlocks)
        {
            MemoryBlocks = memoryBlocks;
        }

        public int RemoveBlocks()
        {
            var blocks = MemoryBlocks;
            MemoryBlocks = 0;
            return blocks;
        }

        public void AddBlock()
        {
            MemoryBlocks++;
        }
    }

    public static class MemoryBankExtensions
    {
        public static MemoryBank ToMemoryBankWithThisManyBlocks(this string number)
        {
            return new MemoryBank(int.Parse(number));
        }

        public static string ToConfiguration(this MemoryBank[] banks)
        {
            return string.Join(" ", banks.Select(x => x.MemoryBlocks));
        }
    }
}
