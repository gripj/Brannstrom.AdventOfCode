using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day15
{
    public class Baker
    {
        private readonly List<Ingredient> _ingredients = new List<Ingredient>();

        public void AddIngredient(string ingredientInformation)
        {
            _ingredients.Add(new Ingredient(ingredientInformation));
        }

        public int DetermineScoreForBestPossibleCookie()
        {
            var score = GetPossibleIngredientCombinations()
                .Select(MakeCookieFromIngredients)
                .Select(x => x.Score)
                .Max();

            return score;
        }

        public int DetermineScoreForBestPossibleCalorieRestrictedCookie(int calories)
        {
            var score = GetPossibleIngredientCombinations()
                .Select(MakeCookieFromIngredients)
                .Where(x => x.Calories == calories)
                .Select(x => x.Score)
                .Max();

            return score;
        }

        public IEnumerable<Dictionary<string, int>> GetPossibleIngredientCombinations()
        {
            var ingredientNames = _ingredients.Select(x => x.Name).ToList();
            var range = Enumerable.Range(1, 100);

            var teaspoonAmountCombinations =
                GetPermutations(range, _ingredients.Count)
                    .Where(x => x.Sum() == 100);

            foreach (var amountCombination in teaspoonAmountCombinations)
            {
                var ingrediensCombination = amountCombination
                    .Zip(ingredientNames, (x, y) => new { Name = y, Amount = x })
                    .ToDictionary(x => x.Name, x => x.Amount);

                yield return ingrediensCombination;
            }
        }

        private Cookie MakeCookieFromIngredients(Dictionary<string, int> ingredientsCombination)
        {
            var cookie = new Cookie();

            var ingredientScores = GetIngredientScores(ingredientsCombination);
            cookie.Score = CalculateCookieScore(ingredientScores);
            cookie.Calories = ingredientScores.Calories;

            return cookie;
        }

        private dynamic GetIngredientScores(Dictionary<string, int> ingredientsCombination)
        {
            var scores = ingredientsCombination
                .Join(_ingredients,
                    (x) => x.Key,
                    (y) => y.Name,
                    (x, y) => new { Ingredient = y, Amount = x.Value })
                .Select(x => new
                {
                    Capacity = x.Ingredient.Capacity * x.Amount,
                    Durability = x.Ingredient.Durability * x.Amount,
                    Flavor = x.Ingredient.Flavor * x.Amount,
                    Texture = x.Ingredient.Texture * x.Amount,
                    Calories = x.Ingredient.Calories * x.Amount
                })
                .Aggregate((x, y) => new
                {
                    Capacity = x.Capacity + y.Capacity,
                    Durability = x.Durability + y.Durability,
                    Flavor = x.Flavor + y.Flavor,
                    Texture = x.Texture + y.Texture,
                    Calories = x.Calories + y.Calories
                });

            return scores;
        }

        private static int CalculateCookieScore(dynamic ingredientScores)
        {
            return CookieHasBadProperty(ingredientScores) ? 
                0 : 
                ingredientScores.Capacity * ingredientScores.Durability * ingredientScores.Flavor * ingredientScores.Texture;
        }

        private static bool CookieHasBadProperty(dynamic scores)
        {
            return scores.Capacity <= 0 || scores.Durability <= 0 || scores.Flavor <= 0 || scores.Texture <= 0;
        }

        private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}