using System;

namespace Brannstrom.AdventOfCode.Day20
{
    public class BlockedIp
    {
        public long From { get; }
        public long To { get; }

        public BlockedIp(long from, long to)
        {
            From = from;
            To = to;
        }

        public static BlockedIp Parse(string input)
        {
            var parts = input.Split('-');

            return new BlockedIp(Convert.ToInt64(parts[0]), Convert.ToInt64(parts[1]));
        }
    }
}
