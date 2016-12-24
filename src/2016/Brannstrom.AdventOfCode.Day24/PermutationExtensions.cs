using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day24
{
    public static class PermutationExtensions
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            var list = sequence.ToList();

            if (!list.Any())
                yield return Enumerable.Empty<T>();
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var remainingItems = list.AllExcept(startingElementIndex);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                        yield return startingElement.Concat(permutationOfRemainder);

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;

            foreach (var item in secondSequence)
                yield return item;
        }

        private static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
        {
            var index = 0;

            return sequence.Where(item => index++ != indexToSkip);
        }
    }
}
