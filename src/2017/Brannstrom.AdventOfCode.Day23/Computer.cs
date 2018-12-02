using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day23
{
    public class Computer
    {
        private readonly Dictionary<string, long> _registers = new Dictionary<string, long>();

        protected long this[string register]
        {
            get
            {
                return long.TryParse(register, out var n) ? n
                    : _registers.ContainsKey(register) ? _registers[register]
                    : 0;
            }
            set
            {
                _registers[register] = value;
            }
        }

        public int CalculateTimesMulIsInvoked(IEnumerable<string> input)
        {
            long instructionPosition = 0;

            var instructions = input.ToArray();
            var mulCount = 0;

            while (instructionPosition >= 0 && instructionPosition < instructions.Length)
            {
                var instruction = instructions[instructionPosition];
                var parts = instruction.Split(' ');

                var instructionType = parts[0];
                var firstId = parts[1];
                var secondId = parts[2];

                switch (instructionType)
                {
                    case "set":
                        this[firstId] = this[secondId];
                        instructionPosition++;
                        break;
                    case "sub":
                        this[firstId] = this[firstId] - this[secondId]; 
                        instructionPosition++;
                        break;
                    case "mul":
                        mulCount++;
                        this[firstId] = this[firstId] * this[secondId];
                        instructionPosition++;
                        break;
                    case "jnz":
                        instructionPosition += this[firstId] != 0 ? this[secondId] : 1;
                        break;
                }
            }
            return mulCount;
        }

        public int CalculateValueLeftInRegisterH()
        {
            var c = 0;
            //This code comes from deconstructing the input instructions in input.txt. These instructions can be
            //simplified, which will in turn allow one to find an emergent pattern that can be translated into the
            //code below.
            for (var b = 109900; b <= 126900; b += 17)
                if (!IsPrime(b))
                    c++;

            return c;
        }

        private static bool IsPrime(int n)
        {
            for (var j = 2; j * j <= n; j++)
                if (n % j == 0) return false;

            return true;
        }
    }
}
