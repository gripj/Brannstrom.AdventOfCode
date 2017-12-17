using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day17
{
    public class BufferCalculator
    {
        public int CalculateValueAfter2017(int steps)
        {
            var buffer = new List<int>() { 0 };
            var position = 0;
            for (var i = 1; i < 2018; i++)
            {
                position = (position + steps) % buffer.Count + 1;
                buffer.Insert(position, i);
            }
            return buffer[(position + 1) % buffer.Count];
        }

        public int CalculateValueAfter0WhenFiftyMillionIsInserted(int steps)
        {
            var position = 0;
            var buffer = 1;
            var value = 0;
            for (var i = 1; i < 50000001; i++)
            {
                position = (position + steps) % buffer + 1;

                if (position == 1)
                    value = i;

                buffer++;
            }
            return value;
        }
    }
}
