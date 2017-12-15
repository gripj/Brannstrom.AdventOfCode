using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day13
{
    public class FireWall
    {
        private FirewallLayers _layers { get; }

        public FireWall(IEnumerable<string> description)
        {
            _layers = new FirewallLayers(description.Select(ToLayer));
        }

        private static (int depth, int range) ToLayer(string layer)
        {
            var parts = layer.Replace(" ", "").Split(':').Select(int.Parse).ToList();
            return (parts[0], parts[1]);
        }

        public int CalculateTotalSeverityWhenMovingThrough() => CalculateSeverityWhenMovingThrough().Sum();

        public int CalculateTimeDelayNeededForSafePassage()
        {
            return Enumerable
                    .Range(0, int.MaxValue)
                    .First(n => !CalculateSeverityWhenMovingThrough(n).Any());
        }

        private IEnumerable<int> CalculateSeverityWhenMovingThrough(int delayTime = 0)
        {
            var packetPosition = 0;
            foreach (var layer in _layers)
            {
                delayTime += layer.Depth - packetPosition;
                packetPosition = layer.Depth;
                var scannerPosition = delayTime % (2 * layer.Range - 2);
                if (scannerPosition == 0)
                    yield return layer.Depth * layer.Range;
            }
        }

        private class FirewallLayers : List<(int Depth, int Range)>
        {
            public FirewallLayers(IEnumerable<(int depth, int range)> layers) : base(layers) {}
        }
    }
}

