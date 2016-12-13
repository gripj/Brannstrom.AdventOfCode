//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;

//namespace Brannstrom.AdventOfCode.Day11
//{
//    public class Floor
//    {
//        private readonly List<Item> _items;

//        public int Number { get; }
//        public List<Item> Items => _items;

//        public Floor(int number)
//        {
//            Number = number;
//            _items = new List<Item>();
//        }

//        public Floor(int number, List<Item> items)
//        {
//            Number = number;
//            _items = items;
//        }

//        public void AddItem(Item item)
//        {
//            _items.Add(item);
//        }

//        public bool IsSafe(IEnumerable<Item> elevatorItems)
//        {
//            var allItems = _items.Concat(elevatorItems).ToList();

//            if (elevatorItems.Any(x => x is Microchip))
//            {
//                return elevatorItems
//                            .Where(x => x is Microchip)
//                            .All(x => allItems.Where(y => y.Type == x.Type && y is Generator).Count() > 0);
//                //return allItems.FirstOrDefault(x => x.Type == microchip.Type && x is Generator) != null ||
//                //       allItems.Count(x => x is Generator) == 0;
//            }
//            if (elevatorItems.Any(x => x is Generator))
//            {
//                return elevatorItems
//                            .Where(x => x is Generator)
//                            .All(x => allItems.Where(y => y.Type == x.Type && y is Microchip).Count() > 0);
//            }
//            return true;
//        }
//    }
//}
