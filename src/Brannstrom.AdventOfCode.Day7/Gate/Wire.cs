using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day7.Gate
{
    public class Wire : Gate
    {
        public override ushort Value(Dictionary<string, ushort> signals)
        {
            return GetValue(signals, 0);
        }
    }
}