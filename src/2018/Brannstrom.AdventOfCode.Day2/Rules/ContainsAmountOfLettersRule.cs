using System.Linq;

namespace Brannstrom.AdventOfCode.Day2.Rules
{
  public class ContainsAmountOfLettersRule : IRule
  {
    private readonly int _amount;

    public ContainsAmountOfLettersRule(int amount)
    {
      _amount = amount;
    }

    public bool IsValid(string boxId)
    {
      return boxId.ToCharArray().GroupBy(x => x).Count(x => x.ToList().Count == _amount) > 0;
    }
  }
}
