using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day14
{
    public class Race
    {
        private IEnumerable<Reindeer> Reindeer { get; } 

        public Race(IEnumerable<Reindeer> reindeer)
        {
            Reindeer = reindeer;
        }

        public void Go(int timeUntilStop)
        {
            for (var i = 0; i < timeUntilStop; i++)
            {
                foreach (var r in Reindeer)
                    r.Fly();

                DistanceLeader.Points++;
            }
        }

        public Reindeer DistanceLeader => Reindeer.OrderByDescending(x => x.DistanceTravelled).First();
        public Reindeer PointsLeader => Reindeer.OrderByDescending(x => x.Points).First();
    }
}
