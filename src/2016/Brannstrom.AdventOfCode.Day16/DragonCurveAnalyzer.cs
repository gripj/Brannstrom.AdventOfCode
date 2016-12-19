using System;
using System.Linq;
using System.Text;

namespace Brannstrom.AdventOfCode.Day16
{
    public class DragonCurveAnalyzer
    {
        public string GetCheckSumForFilledDiskSpace(string input, int diskSpaceToFill)
        {
            var data = input;

            while (data.Length < diskSpaceToFill)
                data = CreateDragonCurve(data);

            data = Truncate(data, diskSpaceToFill);

            return CalculateChecksum(data);
        }

        public string CreateDragonCurve(string a)
        {
            var b = new string(a.Reverse().ToArray())
                        .Replace("0", "#")
                        .Replace("1", "0")
                        .Replace("#", "1");

            return string.Join("0", a, b);
        }

        public string CalculateChecksum(string data)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < data.Length; i += 2)
                sb.Append(data[i] == data[i + 1] ? "1" : "0");

            var checksum = sb.ToString();

            return checksum.Length % 2 == 0 ? CalculateChecksum(checksum) : checksum;
        }

        private static string Truncate(string input, int toLength)
        {
            return input.Substring(0, Math.Min(input.Length, toLength));
        }
    }
}
