//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Brannstrom.AdventOfCode.Day11
//{
//    public class Elevator
//    {
//        private readonly List<Item> _items;
//        private readonly IEnumerable<Floor> _floors;

//        public List<Item> Items => _items;
//        public IEnumerable<Floor> Floors => _floors;

//        public Floor CurrentFloor { get; private set; }

//        public Elevator()
//        {
//            _items = new List<Item>();
//        }

//        public Elevator(IEnumerable<Floor> floors)
//        {
//            _items = new List<Item>();
//            _floors = floors;
//            CurrentFloor = floors.First();
            
//        }

//        public void AddItem(Item item)
//        {
//            _items.Add(item);
//        }

//        public bool IsFunctioning => _items.Count > 0;

//        public int Solve()
//        {
//            return 0;
//        }

//        private Floor NextFloor => Floors.First(x => x.Number == CurrentFloor.Number + 1);

//        public bool GoUp()
//        {
//            if (NextFloor.IsSafe(Items))
//            {
//                CurrentFloor = NextFloor;
//                return true;
//            }
//            return false;
//        }

//        public static Elevator Parse(IEnumerable<string> floorArrangements)
//        {
//            var floors = new List<Floor>();
//            foreach (var arrangement in floorArrangements)
//            {
//                var floorNumber = GetFloorNumber(arrangement);
//                var floor = new Floor(floorNumber);

//                var indexOfInterest = arrangement.IndexOf("contains") + 8;
//                var itemsInArrangement = arrangement.Substring(indexOfInterest);
//                var itemParts = itemsInArrangement.Replace("and a", ", and a").Replace(",,", ",").Split(',');

//                foreach (var part in itemParts)
//                {
//                    if (part.Contains("microchip"))
//                    {
//                        var type = part.Replace("a ", "").Replace("-compatible microchip", "").Replace("and", "").Replace(" ", "").Replace(".", "");
//                        var microchip = new Microchip(type);
//                        floor.AddItem(microchip);
//                    }
//                    else if (part.Contains("generator"))
//                    {
//                        var type = part.Replace("a ", "").Replace(" generator", "").Replace(" ", "").Replace(".", "");
//                        var generator = new Generator(type);
//                        floor.AddItem(generator);
//                    }
//                }

//                floors.Add(floor);
//            }

//            return new Elevator(floors);
//        }

//        private static int GetFloorNumber(string arrangement)
//        {
//            foreach (var id in _idLookup)
//                if (arrangement.Contains(id.Key))
//                    return id.Value;

//            throw new Exception("not found");
//        }

//        private static Dictionary<string, int> _idLookup => new Dictionary<string, int>()
//        {
//            { "first", 1 },
//            { "second", 2 },
//            { "third", 3 },
//            { "fourth", 4 }
//        };
//    }
//}
