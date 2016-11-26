using System;
using System.Text.RegularExpressions;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Ingredient
    {
        private static string IngredientPattern
            => @"(\w+): \w+ ([-\d]+), \w+ ([-\d]+), \w+ ([-\d]+), \w+ ([-\d]+), \w+ ([-\d]+)";

        public string Name { get; set; }

        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavor { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }

        public Ingredient(string rawIngredientListing)
        {
            var match = Regex.Match(rawIngredientListing, IngredientPattern);

            Name = match.Groups[1].Value;
            Capacity = Convert.ToInt32(match.Groups[2].Value);
            Durability = Convert.ToInt32(match.Groups[3].Value);
            Flavor = Convert.ToInt32(match.Groups[4].Value);
            Texture = Convert.ToInt32(match.Groups[5].Value);
            Calories = Convert.ToInt32(match.Groups[6].Value);
        }
    }
}