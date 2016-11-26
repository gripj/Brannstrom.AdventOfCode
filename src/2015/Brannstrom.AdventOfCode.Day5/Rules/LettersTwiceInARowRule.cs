namespace Brannstrom.AdventOfCode.Day5.Rules
{
    public class LettersAtLeastTwiceInARowRule : IRule
    {
        public bool IsNice(string input)
        {
            char lastCharacter = '\0';
            foreach (var ch in input.ToCharArray())
            {
                if (ch.Equals(lastCharacter))
                    return true;
                lastCharacter = ch;
            }
            return false;
        }
    }
}
