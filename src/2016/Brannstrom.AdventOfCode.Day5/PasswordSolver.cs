using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Brannstrom.AdventOfCode.Day5
{
    public class PasswordSolver
    {
        private readonly MD5 _md5;
        private const string FiveZeroes = "00000";

        public PasswordSolver()
        {
            _md5 = MD5.Create();
        }

        public string FindPassword(string doorId)
        {
            var password = new List<char>();
            var currentIndex = 0;
            while (password.Count < 8)
            {
                var hash = GetMd5Hash(doorId + currentIndex);
                if (hash.StartsWith(FiveZeroes))
                    password.Add(hash[5]);

                currentIndex++;
            }

            return new string(password.ToArray());
        }

        public string FindAdvancedPassword(string doorId)
        {
            var password = new char[8];
            var currentIndex = 0;
            var charsFound = 0;

            while (charsFound < 8)
            {
                var currentPassword = GetMd5Hash(doorId + currentIndex);
                if (currentPassword.StartsWith(FiveZeroes))
                {
                    var position = currentPassword[5];
                    if (position >= '0' && position <= '7' && password[(position - '0')] == '\0')
                    {
                        password[(position - '0')] = currentPassword[6];
                        charsFound++;
                    }
                }
                currentIndex++;
            }
            return new string(password.ToArray());
        }

        private string GetMd5Hash(string input)
        {
            var data = _md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
                sBuilder.Append(i.ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
