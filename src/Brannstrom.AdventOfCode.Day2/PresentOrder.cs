using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Brannstrom.AdventOfCode.Day2
{
    public class PresentOrder
    {
        private IEnumerable<string> GetListOfPresentDimensions()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Brannstrom.AdventOfCode.Day2.input.txt"))
            using (var reader = new StreamReader(stream))
                while (reader.Peek() >= 0)
                    yield return reader.ReadLine(); 
        }

        public int GetWrappingPaperAreaForPresentsOrder()
        {
            return GetWrappingPaperArea(GetListOfPresentDimensions());
        }

        public int GetWrappingPaperArea(IEnumerable<string> listOfBoxDimensions)
        {
            return listOfBoxDimensions.Sum(presentDimensions => GetWrappingPaperArea(presentDimensions));
        }

        private int GetWrappingPaperArea(string presentOrderDimensions)
        {
            var sides = presentOrderDimensions.Split('x');
            return new PresentBox(Convert.ToInt32(sides[0]), Convert.ToInt32(sides[1]), Convert.ToInt32(sides[2])).WrappingPaperSize;
        }
    }
}
