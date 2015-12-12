namespace Brannstrom.AdventOfCode.Day6
{
    public class House
    {
        public bool[,] Lights = new bool[1000,1000];

        public int NumberOfLightsOn()
        {
            var lights = 0;
            for (var x = 0; x < 1000; x++)
                for (var y = 0; y < 1000; y++)
                    if (Lights[x, y])
                        lights++;

            return lights;
        }
    }
}
