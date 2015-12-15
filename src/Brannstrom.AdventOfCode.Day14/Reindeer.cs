namespace Brannstrom.AdventOfCode.Day14
{
    public class Reindeer
    {
        private int Speed { get; }
        private int TimeUntilRest { get;  }
        private int RestTime { get; }
        private int TimeElapsed { get; set; }
        private bool IsResting { get; set; }

        public Reindeer(string name, int speed, int timeUntilRest, int restTime)
        {
            Name = name;
            Speed = speed;
            TimeUntilRest = timeUntilRest;
            RestTime = restTime;
            DistanceTravelled = 0;
            Points = 0;
        }

        public string Name { get; }
        public int DistanceTravelled { get; private set; }
        public int Points { get; set; }

        public void Fly()
        {
            TimeElapsed++;

            if (!IsResting)
                DistanceTravelled += Speed;

            if (IsResting && TimeElapsed == RestTime)
            {
                IsResting = false;
                TimeElapsed = 0;
            }
            else if (!IsResting && TimeElapsed == TimeUntilRest)
            {
                IsResting = true;
                TimeElapsed = 0;
            } 
        }
    }
}
