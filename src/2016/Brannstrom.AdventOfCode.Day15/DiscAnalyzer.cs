using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day15
{
    public class DiscAnalyzer
    {
        private readonly IEnumerable<Disc> _discs;

        public DiscAnalyzer(IEnumerable<Disc> discs)
        {
            _discs = discs;
        }

        public int CalculateTimeToPressButton()
        {
            return Enumerable
                    .Range(1, int.MaxValue)
                    .First(time => _discs.All(d => (d.StartPosition + time + d.Id) % d.NumberOfPositions == 0));
        }
    }
}
