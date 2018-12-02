using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day21
{
    public class Rules
    {
        private readonly Dictionary<int, Matrix> _rules2;
        private readonly Dictionary<int, Matrix> _rules3;

        public Rules(IEnumerable<string> input)
        {
            _rules2 = new Dictionary<int, Matrix>();
            _rules3 = new Dictionary<int, Matrix>();

            foreach (var line in input)
            {
                var parts = Regex.Split(line, " => ");
                var left = parts[0];
                var right = parts[1];
                var rules =
                    left.Length == 5 ? _rules2 :
                    left.Length == 11 ? _rules3 :
                    throw new Exception();

                foreach (var matrix in Variations(Matrix.FromString(left)))
                    rules[matrix.CodeNumber] = Matrix.FromString(right);
            }
        }

        public Matrix Apply(Matrix matrix)
        {
            return Matrix.Join((
                from child in matrix.Split()
                select
                    child.Size == 2 ? _rules2[child.CodeNumber] :
                    child.Size == 3 ? _rules3[child.CodeNumber] :
                    null
            ).ToArray());
        }

        private static IEnumerable<Matrix> Variations(Matrix matrix)
        {
            for (var j = 0; j < 2; j++)
            {
                for (var i = 0; i < 4; i++)
                {
                    yield return matrix;
                    matrix = matrix.Rotate();
                }
                matrix = matrix.Flip();
            }
        }
    }
}
