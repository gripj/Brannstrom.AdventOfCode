using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day22
{
    public class ClusterCleaner
    {
        private readonly IEnumerable<string> _clusterStatus;

        public ClusterCleaner(IEnumerable<string> clusterStatus)
        {
            _clusterStatus = clusterStatus;
        }

        public int CalculateBurstsUntilNodeBecomesAffected()
        {
            Func<NodeState, int, int, (NodeState State, int irow, int icol)> virusBurst =
                (state, drow, dcol) =>
                {
                    switch (state)
                    {
                        case NodeState.Clean:
                            return (NodeState.Infected, -dcol, drow);
                        case NodeState.Infected:
                            return (NodeState.Clean, dcol, -drow);
                        default:
                            throw new Exception();
                    }
                };

            return Iterate(virusBurst, 10000);
        }

        public int CalculateBurstsUntilNodeBecomesAffectedForEvolvedVirus()
        {
            Func<NodeState, int, int, (NodeState State, int irow, int icol)> virusBurst =
                (state, drow, dcol) =>
                {
                    switch (state)
                    {
                        case NodeState.Clean:
                            return (NodeState.Weakened, -dcol, drow);
                        case NodeState.Weakened:
                            return (NodeState.Infected, drow, dcol);
                        case NodeState.Infected:
                            return (NodeState.Flagged, dcol, -drow);
                        case NodeState.Flagged:
                            return (NodeState.Clean, -drow, -dcol);
                        default:
                            throw new Exception();
                    }
                };

            return Iterate(virusBurst, 10000000);
        }

        private int Iterate(Func<NodeState, int, int, (NodeState State, int irow, int icol)> virusBurst, int iterations)
        {
            var statusLines = _clusterStatus.ToList();
            var rowCount = statusLines.Count;
            var columnCount = statusLines[0].Length;

            var clusterMap = new Dictionary<(int row, int column), NodeState>();

            for (var irow = 0; irow < rowCount; irow++)
                for (var icol = 0; icol < columnCount; icol++)
                    if (statusLines[irow][icol] == '#')
                        clusterMap.Add((irow, icol), NodeState.Infected);

            var (row, column) = (rowCount / 2, columnCount / 2);
            var (deltaRow, deltaColumn) = (-1, 0);
            var infections = 0;

            for (var i = 0; i < iterations; i++)
            {
                var state = clusterMap.TryGetValue((row, column), out var s) ? s : NodeState.Clean;

                (state, deltaRow, deltaColumn) = virusBurst(state, deltaRow, deltaColumn);

                if (state == NodeState.Infected)
                    infections++;

                if (state == NodeState.Clean)
                    clusterMap.Remove((row, column));
                else
                    clusterMap[(row, column)] = state;

                (row, column) = (row + deltaRow, column + deltaColumn);
            }

            return infections;
        }

        private enum NodeState
        {
            Clean,
            Weakened,
            Infected,
            Flagged
        }
    }
}
