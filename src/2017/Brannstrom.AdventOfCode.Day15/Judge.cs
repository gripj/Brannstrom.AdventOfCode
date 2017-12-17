using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Judge
    {
        private readonly Generator _generatorA;
        private readonly Generator _generatorB;

        public Judge(Generator generatorA, Generator generatorB)
        {
            _generatorA = generatorA;
            _generatorB = generatorB;
        }

        public int CountMatchingPairs(int sequenceLength)
        {
            var sequenceA = _generatorA.GenerateSequence().Take(sequenceLength).Select(ToLowest16bits);
            var sequenceB = _generatorB.GenerateSequence().Take(sequenceLength).Select(ToLowest16bits);

            return CountMatches(sequenceA, sequenceB).Count(x => x);
        }

        public int CountMatchingPairsWithCritera(int sequenceLength)
        {
            var sequenceA = _generatorA.GenerateSequence().Where(x => x % 4 == 0).Take(sequenceLength).Select(ToLowest16bits);
            var sequenceB = _generatorB.GenerateSequence().Where(x => x % 8 == 0).Take(sequenceLength).Select(ToLowest16bits);

            return CountMatches(sequenceA, sequenceB).Count(x => x);
        }

        private static long ToLowest16bits(long value)
        {
            return (value & 0xffff);
        }

        private static IEnumerable<bool> CountMatches(IEnumerable<long> sequenceA, IEnumerable<long> sequenceB)
        {
            return sequenceA.Zip(sequenceB, (a, b) => a == b);
        }
    }
}
