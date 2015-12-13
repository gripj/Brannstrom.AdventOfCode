using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day11.PasswordRequirements
{
    public class DifferentNonOverlappingPairsRequirement : IRequirement
    {
        private const string NonOverlappingPairPattern = "(.)\\1";

        public bool IsValid(string password)
        {
            var regex = new Regex(NonOverlappingPairPattern);
            return regex.Matches(password).Count >= 2;
        }
    }
}
