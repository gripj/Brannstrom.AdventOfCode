using System.Text;

namespace Brannstrom.AdventOfCode.Day9
{
    public class Decompressor
    {
        public string Decompress(string input)
        {
            input = input.Replace(" ", "");

            var decompressedResult = new StringBuilder();

            var i = 0;

            while (i < input.Length)
            {
                if (input[i] == '(')
                {
                    var marker = Marker.Parse(input, i);

                    var startOfCompressedData = i + marker.Length + 2;
                    var compressedData = input.Substring(startOfCompressedData, marker.NumberOfCharacters);

                    decompressedResult.Append(marker.Decompress(compressedData));

                    i = startOfCompressedData + compressedData.Length;
                    continue;
                }

                decompressedResult.Append(input[i]);
                i++;
            }


            return decompressedResult.ToString();
        }
    }
}
