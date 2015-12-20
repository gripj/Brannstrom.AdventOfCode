namespace Brannstrom.AdventOfCode.Day20
{
    public class Elf
    {
        private bool IsTired { get; set; }
        private static int MaxHousesVisitedNumber => 50;

        public Elf(int number)
        {
            Number = number;
        }

        public int Number { get; }
        public int PresentsDelivered => 10*Number;
        public int PresentsDeliveredWhenTired => 11*Number;
        public int HousesVisited { get; private set; }

        public void DeliverPresents(House house)
        {
            if (!IsTired)
                house.Presents += PresentsDelivered;
            else if (IsTired && HousesVisited < MaxHousesVisitedNumber)
            {
                house.Presents += PresentsDeliveredWhenTired;
                HousesVisited++;
            }        
        }

        public void Tire()
        {
            IsTired = true;
        }
    }
}
