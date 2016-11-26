namespace Brannstrom.AdventOfCode.Day5.Rules
{
    public class ContainsOneRepeatingLetterWithOneBetweenThemRule : IRule
    {
        public bool IsNice(string word)
        {
            var charArray = word.ToCharArray();
            for (var i = 0; i < charArray.Length - 2; i++)
                if (charArray[i] == charArray[i + 2])
                    return true;

            return false;
        }
    }
}
