using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day7.Gate
{
    public class LShift : Gate
    {
        public ushort Amount;

        public override ushort Value(Dictionary<string, ushort> signals)
        {
            var x = GetValue(signals, 0);
            return (ushort)(x << Amount);
        }
    }
}