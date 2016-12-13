using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brannstrom.AdventOfCode.Day11
{
    public class Solution : ICloneable
    {
        private List<Solution> _solutions;

        public static HashSet<Solution> CompletedSolutions = new HashSet<Solution>();

        public int Steps { get; private set; }
        public int ElevatorPosition { get; private set; }
        public Dictionary<int, List<Item>> Floors { get; }

        public Solution()
        {
            Steps = 0;
            ElevatorPosition = 1;
            Floors = new Dictionary<int, List<Item>>();

            for (var i = 1; i <= 4; i++)
                Floors.Add(i, new List<Item>());
        }

        public List<Solution> RideInElevator()
        {
            _solutions = new List<Solution>();

            if (!IsOnFinalFloor)
                GoUp();

            if (!IsOnFirstFloor)
                GoDown();

            return _solutions;
        }

        private bool IsOnFirstFloor => ElevatorPosition == 1;
        private bool IsOnFinalFloor => ElevatorPosition == 4;

        private void GoUp() => GoToFloor(1);
        private void GoDown() => GoToFloor(-1);

        public void GoToFloor(int direction)
        {
            var safeCombinations =
                GetSafeElevatorOptions(Floors[ElevatorPosition], Floors[ElevatorPosition + direction]).ToList();

            foreach (var safeCombination in safeCombinations)
            {
                var newSolution = (Solution)Clone();

                foreach (var item in safeCombination)
                    newSolution.Floors[ElevatorPosition].Remove(item);

                newSolution.Floors[ElevatorPosition + direction].AddRange(safeCombination);
                newSolution.ElevatorPosition = newSolution.ElevatorPosition + direction;
                newSolution.Steps++;

                if (!CompletedSolutions.Contains(newSolution))
                {
                    _solutions.Add(newSolution);
                    CompletedSolutions.Add(newSolution);
                }
            }
        }

        private IEnumerable<List<Item>> GetSafeElevatorOptions(List<Item> currentFloor, List<Item> upperFloor)
        {
            var safeCombinations = new List<List<Item>>();
            var possibleCombinations = GetPossibleElevatorCombinations(currentFloor);

            foreach (var possibleCombination in possibleCombinations)
            {
                var newFloor = new List<Item>();
                newFloor.AddRange(upperFloor);
                newFloor.AddRange(possibleCombination);

                var oldFloor = new List<Item>();
                oldFloor.AddRange(currentFloor);
                foreach (var item in possibleCombination)
                    oldFloor.Remove(item);

                if (FloorIsSafe(newFloor) && FloorIsSafe(oldFloor))
                    safeCombinations.Add(possibleCombination);
            }

            return safeCombinations;
        }

        public bool FloorIsSafe(List<Item> items)
        {
            var hasNoGenerators = !items.Any(w => w is Generator);
            if (hasNoGenerators)
                return true;

            return items
                .Where(i => i is Microchip)
                .Select(chip => items.Where(g => g.Element == chip.Element && g is Generator))
                .Any();
        }

        public List<List<Item>> GetPossibleElevatorCombinations(List<Item> items)
        {
            var result = new List<List<Item>>();
            for (var i = 0; i < items.Count; i++)
            {
                var currentItem = items[i];
                result.Add(new List<Item>() { currentItem });
                for (var j = i + 1; j < items.Count; j++)
                {
                    var otherItem = items[j];

                    var combination = new List<Item>() { currentItem, otherItem };
                    if (FloorIsSafe(combination))
                        result.Add(combination);
                }
            }
            return result;
        }

        public bool AllItemsAreOnTopFloor()
        {
            for (var i = 1; i <= 3; i++)
                if (Floors[i].Count != 0)
                    return false;

            return true;
        }

        public object Clone()
        {
            var newSolution = new Solution
            {
                Steps = Steps,
                ElevatorPosition = ElevatorPosition
            };

            foreach (var floor in Floors)
                foreach (var item in floor.Value)
                    newSolution.Floors[floor.Key].Add(item);

            return newSolution;
        }

        public override string ToString()
        {
            var result = "";
            foreach (var floor in Floors.Reverse())
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("F" + floor.Key);
                stringBuilder.Append(ElevatorPosition == floor.Key ? "E" : "");

                foreach (var item in floor.Value.Select(w => w.ToString()).OrderBy(w => w))
                    stringBuilder.Append(item);

                result += stringBuilder;
            }

            return result;
        }

        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => ToString() == ((Solution)obj).ToString();
    }
}
