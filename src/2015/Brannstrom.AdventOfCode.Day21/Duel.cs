namespace Brannstrom.AdventOfCode.Day21
{
    public class Duel
    {
        private Character CharacterOne { get; }
        private Character CharacterTwo { get; }

        public Duel(Character one, Character two)
        {
            CharacterOne = one;
            CharacterTwo = two;
        }

        public void Fight()
        {
            var turns = 0;
            while (CharacterOne.IsAlive && CharacterTwo.IsAlive)
            {
                if (turns % 2 == 0)
                    CharacterOne.Attack(CharacterTwo);
                else
                    CharacterTwo.Attack(CharacterOne);

                turns++;
            }
        }
    }
}
