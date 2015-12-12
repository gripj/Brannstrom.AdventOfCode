using System;
using System.Security.Cryptography;
using System.Text;

namespace Brannstrom.AdventOfCode.Day4
{
    public class HashAnalyzer
    {
        public int FindLowestNumberForSecretKey(string secretKey, int numberOfLeadingZeros)
        {
            var foundHash = false;
            var number = 0;
            var numberOfLeadingZerosString = GetNumberOfLeadingZerosString(numberOfLeadingZeros);
            while (!foundHash)
            {
                var md5 = GetMD5Hash(secretKey + number);
                foundHash = md5.Substring(0, numberOfLeadingZeros).Equals(numberOfLeadingZerosString);
                if (!foundHash)
                    number++;
            }
            return number;
        }

        private string GetNumberOfLeadingZerosString(int numberOfLeadingZeros)
        {
            var leadingZeroes = "";
            for (var i = 1; i <= numberOfLeadingZeros; i++)
                leadingZeroes += "0";

            return leadingZeroes;
        }

        public string GetMD5Hash(string TextToHash)
        {
            var textToHash = Encoding.Default.GetBytes(TextToHash);
            var result = new MD5CryptoServiceProvider().ComputeHash(textToHash);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
