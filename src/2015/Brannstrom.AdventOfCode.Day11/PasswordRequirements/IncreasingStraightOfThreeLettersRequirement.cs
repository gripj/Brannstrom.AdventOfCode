namespace Brannstrom.AdventOfCode.Day11.PasswordRequirements
{
    public class IncreasingStraightOfThreeLettersRequirement : IRequirement
    {
        public bool IsValid(string password)
        {
            var charArray = password.ToCharArray();
            for (var i = 2; i < charArray.Length; i++)
            {
                var twoBack = GetPositionInAlphabet(charArray[i - 2]);
                var oneBack = GetPositionInAlphabet(charArray[i - 1]);
                var current = GetPositionInAlphabet(charArray[i]);

                if (twoBack + 1 == oneBack && oneBack + 1 == current)
                    return true;
            }
            return false;
        }

        private static int GetPositionInAlphabet(char ch) => (int)ch % 32;
    }
}
