using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day6
{
    public class MemoryReallocator
    {
        private readonly MemoryBank[] _memoryBanks;
        private List<string> _configurations;

        public MemoryReallocator(MemoryBank[] memoryBanks)
        {
            _memoryBanks = memoryBanks;
        }

        public int FindRedistributionsUntilConfigurationRepeats()
        {
            Func<bool> whileConfigurationsAreUnique = () => _configurations.Count == _configurations.Distinct().Count();

            DistributeBlocks(whileConfigurationsAreUnique);

            return _configurations.Count - 1;
        }

        public int FindReallocationLoopSize()
        {
            Func<bool> whileCycleHasNotRepeated = () => _configurations.GroupBy(x => x).All(group => group.Count() != 2);

            DistributeBlocks(whileCycleHasNotRepeated);

            return _configurations.Count - _configurations.IndexOf(_configurations.Last(), 1) - 1;
        }

        private void DistributeBlocks(Func<bool> shouldWork)
        {
            _configurations = new List<string>() { _memoryBanks.ToConfiguration() };

            while (shouldWork())
            {
                var bankWithMostBlocks = _memoryBanks.OrderByDescending(x => x.MemoryBlocks).First();
                var blocksToDistribute = bankWithMostBlocks.RemoveBlocks();

                for (var i = GetNextPosition(Array.IndexOf(_memoryBanks, bankWithMostBlocks));
                    blocksToDistribute > 0;
                    i = GetNextPosition(i))
                {
                    _memoryBanks[i].AddBlock();
                    blocksToDistribute--;
                }

                _configurations.Add(_memoryBanks.ToConfiguration());
            }
        }

        private int GetNextPosition(int currentIndex)
        {
            return currentIndex != _memoryBanks.Length - 1 ? currentIndex + 1 : 0;
        }
    }
}
