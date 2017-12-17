using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Generator
    {
        public string Id { get; }

        private readonly long _factor;
        private readonly long _divider;
        private long _previousValue { get; set; }

        public Generator(string id, long factor, long startingValue)
        {
            Id = id;
            _factor = factor;
            _divider = 2147483647;
            _previousValue = startingValue;
        }

        public long Generate()
        {
            _previousValue = (_previousValue * _factor) % _divider;
            return _previousValue;
        }

        public IEnumerable<long> GenerateSequence()
        {
            while(true)
                yield return Generate();
        }
    }
}
