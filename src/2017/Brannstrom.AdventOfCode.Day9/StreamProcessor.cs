using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day9
{
    public class StreamProcessor
    {
        private List<char> _stream;
        private readonly List<Action> _actions;

        private char _currentChar;
        private int _garbageScore;
        private int _groupScore;
        private int _totalScore;
        private int _position;
        private bool _isInGarbage;

        public StreamProcessor()
        {
            _actions = new List<Action>()
            {
                () => { if (_currentChar != '>' && _isInGarbage) _garbageScore++; },
                () => { if (_currentChar == '<' && !_isInGarbage) _isInGarbage = true; },
                () => { if (_currentChar == '>') _isInGarbage = false; },
                () => { if (_currentChar == '{' && !_isInGarbage) _groupScore++; },
                () => { if (_currentChar == '}' && !_isInGarbage) { _totalScore += _groupScore; _groupScore--; }}
            };
        }

        public (int TotalScore, int GarbageScore) Process(string inputStream)
        {
            Initialize(inputStream);

            while (IsInStream)
            {
                _currentChar = _stream[_position];

                if (ShouldIgnore)
                    _stream.RemoveAt(_position + 1);
                else
                    _actions.ForEach(a => a());

                _position++;
            }

            return (_totalScore, _garbageScore);
        }

        private void Initialize(string inputStream)
        {
            _stream = inputStream.ToList();
            _garbageScore = 0;
            _groupScore = 0;
            _totalScore = 0;
            _position = 0;
        }

        private bool IsInStream => _position < _stream.Count;
        private bool ShouldIgnore => _currentChar == '!' && _isInGarbage;
    }
}
