using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day7.Gate
{
    public class Or : Gate
    {
        public override ushort Value(Dictionary<string, ushort> signals)
        {
            var x = GetValue(signals, 0);
            var y = GetValue(signals, 1);
            return (ushort)(x | y);
        }
    }
}