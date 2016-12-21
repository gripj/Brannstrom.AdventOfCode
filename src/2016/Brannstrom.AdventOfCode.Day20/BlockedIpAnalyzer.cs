using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day20
{
    public class BlockedIpAnalyzer
    {
        private readonly IEnumerable<BlockedIp> _blockedIps;
        private long? _lowestAllowedIp;
        private long _numberOfAllowedIps;

        public BlockedIpAnalyzer(IEnumerable<BlockedIp> blockedIps)
        {
            _blockedIps = blockedIps;
            Analyze();
        }

        private void Analyze()
        {
            var current = (long)0;

            foreach (var ip in _blockedIps)
            {
                if (current < ip.From)
                {
                    _lowestAllowedIp = _lowestAllowedIp ?? current;
                    _numberOfAllowedIps += ip.From - current;
                }

                if (current < ip.To)
                    current = ip.To + 1;
            }
        }

        public long GetLowestAllowedIp() => (long)_lowestAllowedIp;
        public long GetNumberOfAllowedIps() => _numberOfAllowedIps;
    }
}
