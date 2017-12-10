using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day10
{
    public static class KnotHasher
    {
        public static int[] SparseHash(IEnumerable<int> lengths, int rounds, int listSize = 256)
        {
            var output = Enumerable.Range(0, listSize).ToArray();

            var position = 0;
            var skipSize = 0;
            for (var round = 0; round < rounds; round++)
            {
                foreach (var length in lengths)
                {
                    for (var i = 0; i < length / 2; i++)
                    {
                        var from = (position + i) % output.Length;
                        var to = (position + length - 1 - i) % output.Length;
                        (output[from], output[to]) = (output[to], output[from]);
                    }
                    position += length + skipSize;
                    skipSize++;
                }
            }

            return output;
        }

        public static string HexadecimalDenseHash(IEnumerable<int> input, int rounds, int listSize = 256)
        {
            return SparseHash(input, 64).ToDense().Select(ToHexadecimal).Join();
        }

        public static IEnumerable<int> ToLengths(this string lengths)
        {
            return lengths.Replace(" ", "").Split(',').Select(int.Parse);
        }

        public static IEnumerable<int> ToASCIILengths(this string lengths)
        {
            var suffixLengths = new[] { 17, 31, 73, 47, 23 };
            return lengths.ToCharArray().Select(b => (int)b).Concat(suffixLengths);
        }

        private static IEnumerable<int> ToDense(this IEnumerable<int> sparseHash)
        {
            return (from block in Enumerable.Range(0, 16)
                    let elements = sparseHash.Skip(16 * block).Take(16)
                    select elements.Aggregate(0, (a, b) => a ^ b));
        }

        private static string ToHexadecimal(this int n) => n.ToString("x2");

        private static string Join(this IEnumerable<string> list) => string.Join("", list);
    }
}
