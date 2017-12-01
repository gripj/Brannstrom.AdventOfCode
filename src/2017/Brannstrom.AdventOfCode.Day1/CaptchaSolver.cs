using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day1
{
    public class CaptchaSolver
    {
        public int CalculateSumOfConcurrentDigits(List<int> digits)
        {
            return CalculateSumOfMatchingDigits(digits, 1);
        }

        public int CalculateSumOfDigitsMatchingHalfwayAround(List<int> digits)
        {
            return CalculateSumOfMatchingDigits(digits, digits.Count / 2);
        }

        private static int CalculateSumOfMatchingDigits(IReadOnlyList<int> digits, int stepSize)
        {
            return digits
                    .Select((d, i) =>
                    {
                        return i + stepSize <= digits.Count - 1 ?
                            digits[i] == digits[i + stepSize] ? d : 0
                            : digits[i] == digits[i + stepSize - digits.Count] ? d : 0;
                    })
                    .Sum();
        }
    }
}
