using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day18
{
    public class LightGrid
    {
        private readonly int _size;

        public LightGrid(int size)
        {
            Lights = new Light[size, size];
            _size = size;
        }

        public Light[,] Lights;

        public void Initialize(IEnumerable<string> instructions)
        {
            var rows = instructions.ToArray();

            for (var x = 0; x < _size; x++)
                for (var y = 0; y < _size; y++)
                {
                    Lights[x, y] = new Light();
                    if (rows[x][y] == '#')
                        Lights[x, y].TurnOn();
                }
                    
        }

        public void LockLights(List<Tuple<int, int>> lightPositions)
        {
            foreach (var position in lightPositions)
                Lights[position.Item1, position.Item2].Lock();
        }

        public LightGrid Animate()
        {
            var grid = new LightGrid(_size);
            Array.Copy(Lights, grid.Lights, _size);

            for (var x = 0; x < _size; x++)
                for (var y = 0; y < _size; y++)
                {
                    var amountOfLitNeighbors = GetAmountOfLitNeighbors(x, y);
                    grid.Lights[x, y] = Lights[x, y].Animate(amountOfLitNeighbors);
                }

            return grid;
        }

        public int GetAmountOfLitNeighbors(int xIndex, int yIndex)
        {
            var hasLeft = yIndex > 0;
            var hasRight = yIndex < _size - 1;
            var hasTop = xIndex > 0;
            var hasBottom = xIndex < _size - 1;

            var litCount = 0;

            if (hasTop && Lights[xIndex - 1, yIndex].IsOn) litCount++;
            if (hasBottom && Lights[xIndex + 1, yIndex].IsOn) litCount++;
            if (hasLeft && Lights[xIndex, yIndex - 1].IsOn) litCount++;
            if (hasRight && Lights[xIndex, yIndex + 1].IsOn) litCount++;

            if (hasTop && hasLeft && Lights[xIndex - 1, yIndex - 1].IsOn) litCount++;
            if (hasTop && hasRight && Lights[xIndex - 1, yIndex + 1].IsOn) litCount++;
            if (hasBottom && hasLeft && Lights[xIndex + 1, yIndex - 1].IsOn) litCount++;
            if (hasBottom && hasRight && Lights[xIndex + 1, yIndex + 1].IsOn) litCount++;

            return litCount;
        }
    }
}
