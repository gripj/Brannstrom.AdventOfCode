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
            return GetTotalWrappingPaperArea(GetListOfPresentDimensions());
        }

        public int GetTotalWrappingPaperArea(IEnumerable<string> listOfBoxDimensions)
        {
            return listOfBoxDimensions.Sum(presentDimensions => GetAreaForBoxDimensions(presentDimensions));
        }

        private int GetAreaForBoxDimensions(string presentOrderDimensions)
        {
            var sides = presentOrderDimensions.Split('x');
            return new PresentBox(Convert.ToInt32(sides[0]), Convert.ToInt32(sides[1]), Convert.ToInt32(sides[2])).WrappingPaperSize;
        }

        public int GetRibbonLengthForPresentsOrder()
        {
            return GetTotalRibbonLength(GetListOfPresentDimensions());
        }

        public int GetTotalRibbonLength(IEnumerable<string> listOfBoxDimensions)
        {
            return listOfBoxDimensions.Sum(presentDimensions => GetRibbonLengthForBoxDimensions(presentDimensions));
        }

        private int GetRibbonLengthForBoxDimensions(string presentOrderDimensions)
        {
            var sides = presentOrderDimensions.Split('x');
            return new PresentBox(Convert.ToInt32(sides[0]), Convert.ToInt32(sides[1]), Convert.ToInt32(sides[2])).RibbonLength;
        }
    }
}
