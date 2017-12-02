using System;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day2
{
    public class ChecksumCalculator
    {
        public int CalculateForDifference(int[][] spreadsheet)
        {
            return spreadsheet.Select(x => x.Max() - x.Min()).Sum();
        }

        public int CalculateForEvenlyDivisible(int[][] spreadsheet)
        {
            return spreadsheet.Sum(row =>
                (from a in row
                 from b in row
                 let max = Math.Max(a, b)
                 let min = Math.Min(a, b)
                 where a % b == 0 && max / min != 1
                 select max / min)
                .Single()); ;
        }
    }
}
