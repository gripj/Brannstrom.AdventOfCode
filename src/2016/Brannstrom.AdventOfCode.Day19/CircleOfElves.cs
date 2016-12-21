namespace Brannstrom.AdventOfCode.Day19
{
    public class CircleOfElves
    {
        private readonly Elf _firstElf;
        private Elf _elfAcross;
        private int _numberOfElves;

        public CircleOfElves(int numberOfElves)
        {
            _numberOfElves = numberOfElves;
            _firstElf = new Elf(1);
            var current = _firstElf;

            for (var n = 2; n <= numberOfElves; n++)
            {
                current = current.Left = new Elf(n) { Right = current };
                if (n == (numberOfElves / 2) + 1)
                    _elfAcross = current;
            }

            current.Left = _firstElf;
            _firstElf.Right = current;
        }

        public Elf GetWinnerWhenStealingLeft()
        {
            var current = _firstElf;

            while (current != current.Left)
            {
                current.Left = current.Left.Left;
                current = current.Left;
            }

            return current;
        }

        public Elf GetWinnerWhenStealingAcross()
        {
            var current = _firstElf;

            while (current != current.Left)
            {
                StealAcross();
                _numberOfElves--;
                current = current.Left;
            }

            return current;
        }

        private void StealAcross()
        {
            _elfAcross.Right.Left = _elfAcross.Left;
            _elfAcross.Left.Right = _elfAcross.Right;
            _elfAcross = _numberOfElves % 2 == 0 ? _elfAcross.Left : _elfAcross.Left.Left;
        }
    }
}
