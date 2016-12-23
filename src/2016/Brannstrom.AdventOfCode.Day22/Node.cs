using System;

namespace Brannstrom.AdventOfCode.Day22
{
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        public int Size { get; }
        public int Used { get; }
        public int Avail { get; }
        public int UsePercent { get; }

        public Node(
            int x,
            int y,
            int size,
            int used,
            int avail,
            int usePercent)
        {
            X = x;
            Y = y;
            Size = size;
            Used = used;
            Avail = avail;
            UsePercent = usePercent;
        }

        public static Node Parse(string input)
        {
            var parts = input.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var x = int.Parse(parts[0].Split('x')[1].Split('-')[0]);
            var y = int.Parse(parts[0].Split('y')[1]);
            var size = int.Parse(parts[1].Substring(0, parts[1].Length - 1));
            var used = int.Parse(parts[2].Substring(0, parts[2].Length - 1));
            var avail = int.Parse(parts[3].Substring(0, parts[3].Length - 1));
            var usePercent = int.Parse(parts[4].Substring(0, parts[4].Length - 1));

            return new Node(x, y, size, used, avail, usePercent);
        }
    }
}
