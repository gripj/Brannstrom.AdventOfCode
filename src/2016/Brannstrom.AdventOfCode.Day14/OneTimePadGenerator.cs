using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day14
{
    public class OneTimePadGenerator
    {
        private readonly string _salt;
        private readonly MD5 _md5;
        private readonly Queue<string> _hashes;
        private readonly List<string> _keys;
        private int _index;
        private readonly int _numberOfIterations;

        public OneTimePadGenerator(string salt, int numberOfIterations = 1)
        {
            _salt = salt;
            _numberOfIterations = numberOfIterations;
            _md5 = MD5.Create();
            _keys = new List<string>();
            _hashes = new Queue<string>(1000);
            _index = 0;
        }

        public int GetIndexForKey(int key)
        {
            const int queueSize = 1001;

            for (var x = 1; x < queueSize; ++x)
                _hashes.Enqueue(GetNextHash());

            var multipleCharactersMatcher = new Regex(@"([a-z\d])\1\1");
            while (_keys.Count < key)
            {
                _hashes.Enqueue(GetNextHash());
                var hash = _hashes.Dequeue();

                var m = multipleCharactersMatcher.Match(hash);
                if (m.Success)
                {
                    var fiveCharactersInSequence = new string(m.Value[0], 5);
                    if (_hashes.Any(x => x.Contains(fiveCharactersInSequence)))
                        _keys.Add(hash);
                }
            }

            return _index - queueSize;
        }

        private string GetNextHash()
        {
            var hash = _salt + _index++;

            for (var x = 0; x < _numberOfIterations; x++)
                hash = ApplyMd5(hash);

            return hash;
        }

        private string ApplyMd5(string input)
        {
            var sb = new StringBuilder();

            var hash = _md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            foreach (var o in hash)
                sb.Append(o.ToString("X2"));

            return sb.ToString().ToLower();
        }
    }
}
