using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day7.Gate
{
    public class Not : Gate
    {
        public override ushort Value(Dictionary<string, ushort> signals)
        {
            var x = GetValue(signals, 0);
            return (ushort)~x;
        }
    }
}