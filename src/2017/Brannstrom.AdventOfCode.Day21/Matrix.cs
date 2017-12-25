using System;
using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day21
{
    public class Matrix
    {
        private readonly bool[] _flags;

        public int Size { get; }

        public int CodeNumber
        {
            get
            {
                var i = 0;

                for (var row = 0; row < Size; row++)
                    for (var col = 0; col < Size; col++)
                        if (this[row, col])
                            i |= (1 << (row * Size + col));

                return i;
            }
        }

        public Matrix(int size)
        {
            _flags = new bool[size * size];
            Size = size;
        }

        public static Matrix FromString(string @string)
        {
            @string = @string.Replace("/", "");
            var size = (int)Math.Sqrt(@string.Length);
            var matrix = new Matrix(size);

            for (var i = 0; i < @string.Length; i++)
                matrix[i / size, i % size] = @string[i] == '#';

            return matrix;
        }

        public static Matrix Join(Matrix[] matrices)
        {
            var matricesPerRow = (int)Math.Sqrt(matrices.Length);
            var result = new Matrix(matricesPerRow * matrices[0].Size);

            for (var i = 0; i < matrices.Length; i++)
            {
                var matrix = matrices[i];

                for (var row = 0; row < matrix.Size; row++)
                    for (var col = 0; col < matrix.Size; col++)
                    {
                        var rowResult = (i / matricesPerRow) * matrix.Size + row;
                        var colResult = (i % matricesPerRow) * matrix.Size + col;
                        result[rowResult, colResult] = matrix[row, col];
                    }
            }

            return result;
        }

        public IEnumerable<Matrix> Split()
        {
            var blockSize =
                Size % 2 == 0 ? 2 :
                Size % 3 == 0 ? 3 :
                throw new Exception();

            for (var irow = 0; irow < Size; irow += blockSize)
                for (var icol = 0; icol < Size; icol += blockSize)
                {
                    var matrix = new Matrix(blockSize);

                    for (var drow = 0; drow < blockSize; drow++)
                        for (var dcol = 0; dcol < blockSize; dcol++)
                            matrix[drow, dcol] = this[irow + drow, icol + dcol];

                    yield return matrix;
                }
        }

        public Matrix Flip()
        {
            var result = new Matrix(Size);

            for (var row = 0; row < Size; row++)
                for (var col = 0; col < Size; col++)
                    result[row, Size - col - 1] = this[row, col];

            return result;
        }

        public Matrix Rotate()
        {
            var result = new Matrix(Size);

            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++)
                    result[i, j] = this[j, Size - i - 1];

            return result;
        }

        public int Count()
        {
            var count = 0;

            for (var row = 0; row < Size; row++)
                for (var col = 0; col < Size; col++)
                    if (this[row, col])
                        count++;

            return count;
        }

        private bool this[int row, int col]
        {
            get => _flags[(Size * row) + col];
            set => _flags[(Size * row) + col] = value;
        }
    }
}
