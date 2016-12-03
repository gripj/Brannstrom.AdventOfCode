using System;

namespace Brannstrom.AdventOfCode.Day2.InputCalculators
{
    public abstract class NextInputCalculator : ICalculateInput
    {
        protected char _input;
        protected int _xDirection;
        protected int _yDirection;

        protected NextInputCalculator(char input, int xDirection, int yDirection)
        {
            _input = input;
            _xDirection = xDirection;
            _yDirection = yDirection;
        }

        public bool CanHandle(char input) => _input == input;

        public string CalculateNextKey(string[,] keyPad, string currentKey)
        {
            var currentPosition = GetPositionOfCurrentKey(keyPad, currentKey);
            var xPosition = Math.Min(keyPad.GetLength(0) - 1, Math.Max(0, currentPosition.X + _xDirection));
            var yPosition = Math.Min(keyPad.GetLength(1) - 1, Math.Max(0, currentPosition.Y + _yDirection));
            var nextPosition = new Point(xPosition, yPosition);

            return keyPad[nextPosition.X, nextPosition.Y] != "" ?
                keyPad[nextPosition.X, nextPosition.Y] : 
                keyPad[currentPosition.X, currentPosition.Y];
        }

        private static Point GetPositionOfCurrentKey(string[,] keyPad, string currentKey)
        {
            for (var x = 0; x < keyPad.GetLength(0); x++)
                for (var y = 0; y < keyPad.GetLength(1); y++)
                    if (keyPad[x, y].Equals(currentKey))
                        return new Point(x, y);
            throw new Exception("Key not found");
        }
    }
}
