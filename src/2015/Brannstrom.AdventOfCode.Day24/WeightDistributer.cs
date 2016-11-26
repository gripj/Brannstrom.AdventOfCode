using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day24
{
    public class WeightDistributer
    {
        private int[] _packageWeights;
        private int _totalWeight;
        private int _numberOfWeights;
        private long _quantumEntanglement;
        private int _minimumGroupSize;

        public long FindQuantumEntanglement(int numberOfGroups)
        {
            Initialize();
            FindFirstGroupQE(new List<int>(), numberOfGroups);

            return _quantumEntanglement;
        }

        private void Initialize()
        {
            var packageList = new Reader().ReadPackageList();
            _packageWeights = packageList.Select(int.Parse).ToArray();
            _totalWeight = _packageWeights.Sum();
            _numberOfWeights = _packageWeights.Count();
            _quantumEntanglement = -1;
            _minimumGroupSize = -1;
        }

        private void FindFirstGroupQE(List<int> group, int numGroups, int n = 0)
        {
            var sum = group.Sum();
            var groupSize = group.Count();
            var qe = CalculateQE(group);

            if (HasFoundQE(sum, numGroups, groupSize, qe))
                return;

            if (IsEvenDistribution(sum, numGroups))
                RememberCandidate(groupSize, qe);

            ContinueSearching(group, n, numGroups);
        }

        private bool HasFoundQE(int sum, int numberOfGroups, int size, long qe)
        {
            return SizeIsLargerThanAvg(sum, numberOfGroups)
                   || GroupIsLargerThanMinimum(size)
                   || HasFoundSmallerQE(size, qe);
        }

        private bool SizeIsLargerThanAvg(int sum, int numGroups) => sum > _totalWeight/numGroups;

        private bool GroupIsLargerThanMinimum(int size) => _minimumGroupSize >= 0 && size > _minimumGroupSize;

        private bool HasFoundSmallerQE(int size, long qe)
        {
            return size == _minimumGroupSize && _quantumEntanglement >= 0 && qe > _quantumEntanglement;
        }

        private bool IsEvenDistribution(int sum, int numberOfGroups) => sum == _totalWeight/numberOfGroups;

        private void RememberCandidate(int size, long qe)
        {
            _minimumGroupSize = size;
            _quantumEntanglement = qe;
        }

        private void ContinueSearching(List<int> group, int n, int numberOfGroups)
        {
            if (!ShouldContinue(n)) return;
                var newGroup = new List<int>(group);
            newGroup.Add(_packageWeights[_numberOfWeights - n - 1]);
            FindFirstGroupQE(newGroup, numberOfGroups, n + 1);
            FindFirstGroupQE(group, numberOfGroups, n + 1);
        }

        private bool ShouldContinue(int n) => n < _packageWeights.Length;

        public long CalculateQE(List<int> group)
        {
            return group.Aggregate<int, long>(1, (current, x) => current*x);
        }
    }
}
