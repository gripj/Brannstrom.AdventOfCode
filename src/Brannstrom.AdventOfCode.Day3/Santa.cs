using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day3
{
    public class Santa
    {
        private int X { get; set; }
        private int Y { get; set; }
        public List<House> VisitedHouses { get; set; } 

        public Santa()
        {
            X = 0;
            Y = 0;
            VisitedHouses = new List<House>();
        }

        public void DeliverPresents(string directions)
        {
            VisitedHouses.Add(new House(X, Y));
            foreach (var direction in directions.ToCharArray())
            {
                GoToNextHouse(direction);
                var visitedHouse = new House(X, Y);
                if (!VisitedHouses.Contains(visitedHouse))
                    VisitedHouses.Add(new House(X, Y));
            }
        }

        private void GoToNextHouse(char direction)
        {
            switch (direction)
            {
                case ('>'):
                    X++;
                    break;
                case ('<'):
                    X--;
                    break;
                case ('^'):
                    Y++;
                    break;
                case ('v'):
                    Y--;
                    break;
            }
        }
    }
}
