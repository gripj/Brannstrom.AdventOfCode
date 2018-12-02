using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day2.Rules;

namespace Brannstrom.AdventOfCode.Day2
{
  public class ChecksumCalculator
  {
    private readonly IEnumerable<IRule> _rules;

    public ChecksumCalculator(IEnumerable<IRule> rules)
    {
      _rules = rules;
    }

    public int CalculateChecksum(IEnumerable<string> boxIds)
    {
      return _rules.Select(rule => boxIds.Count(rule.IsValid)).Aggregate(1, (x, y) => x * y);
    }
  }
}
