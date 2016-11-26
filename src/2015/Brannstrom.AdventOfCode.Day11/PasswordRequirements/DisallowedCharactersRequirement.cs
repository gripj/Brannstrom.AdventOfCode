using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day11.PasswordRequirements
{
    public class DisallowedCharactersRequirement : IRequirement
    {
        private readonly List<string> _disallowedCharacters = new List<string>() { "i", "o", "l"}; 

        public bool IsValid(string password)
        {
            return !_disallowedCharacters.Any(password.Contains);
        }
    }
}
