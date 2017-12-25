using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day21
{
    public class FractalArtGenerator
    {
        private readonly Rules _rules;

        public FractalArtGenerator(IEnumerable<string> input)
        {
            _rules = new Rules(input);
        }

        public int CalculateOnPixelsAfterIterations(int iterations)
        {
            var matrix = Matrix.FromString(".#./..#/###");

            for (var i = 0; i < iterations; i++)
                matrix = _rules.Apply(matrix);

            return matrix.Count();
        }
    }
}
