using System.Collections.Generic;
using System.Linq;
using Brannstrom.AdventOfCode.Day11.PasswordRequirements;

namespace Brannstrom.AdventOfCode.Day11
{
    public class PasswordAnalyzer
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly IEnumerable<IRequirement> _passwordRequirements;

        public PasswordAnalyzer(IEnumerable<IRequirement> passwordRequirements)
        {
            _passwordRequirements = passwordRequirements;
        }

        public bool PasswordIsValid(string password) => _passwordRequirements.All(x => x.IsValid(password));

        public string FindNextValidPassword(string currentPassword)
        {
            var pw = currentPassword;
            do
            {
                pw = Increment(pw);
            } while (!PasswordIsValid(pw));

            return pw;
        }

        private static string Increment(string input)
        {
            var result = input.Substring(0, input.Length - 1);
            var lastLetter = Alphabet.IndexOf(input[input.Length - 1]);
            lastLetter++;

            if (ShouldWrapAround(lastLetter))
            {
                lastLetter = 0;
                result = Increment(result);
            }

            result += Alphabet[lastLetter];
            return result;
        }

        private static bool ShouldWrapAround(int positionInAlphabet) => positionInAlphabet >= Alphabet.Length;
    }
}
