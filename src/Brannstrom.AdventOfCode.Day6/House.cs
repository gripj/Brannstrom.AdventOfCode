namespace Brannstrom.AdventOfCode.Day6
{
    public class House
    {
        public int[,] Lights = new int[1000,1000];

        public int NumberOfLightsOn()
        {
            var lights = 0;
            for (var x = 0; x < 1000; x++)
                for (var y = 0; y < 1000; y++)
                    if (Lights[x, y] > 0)
                        lights++;

            return lights;
        }

        public int TotalBrighness()
        {
            var brightness = 0;
            for (var x = 0; x < 1000; x++)
                for (var y = 0; y < 1000; y++)
                    brightness += Lights[x,y];

            return brightness;
        }
    }
}
