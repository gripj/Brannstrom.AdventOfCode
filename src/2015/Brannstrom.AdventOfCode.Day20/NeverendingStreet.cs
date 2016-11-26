using System;
using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day20
{
    public class NeverendingStreet
    {
        public NeverendingStreet()
        {
            Populate(1000000, 1000000);
        }

        private void Populate(int numberOfHouses, int numberOfElves)
        {
            Houses = new List<House>();
            for (var i = 1; i <= numberOfHouses; i++)
                Houses.Add(new House(i));

            Elves = new List<Elf>();
            for (var j = 1; j <= numberOfElves; j++)
                Elves.Add(new Elf(j));
        }

        public List<House> Houses { get; private set; }
        public List<Elf> Elves { get; private set; }

        public void DeliverPresents()
        {
            foreach (var elf in Elves)
                for (var k = elf.Number; k <= Houses.Count; k = k + elf.Number)
                    elf.DeliverPresents(Houses[k-1]);
        }

        public void TireElvesOut()
        {
            foreach (var elf in Elves)
                elf.Tire();
        }

        public int GetFirstHouseToReceiveAmountOfPresents(int amountOfPresents)
        {
            foreach (var house in Houses)
                if (house.Presents >= amountOfPresents)
                    return house.Number;

            throw new Exception("House not found");
        }
    }
}
