using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Make_Best_Possible_Cookie_With_500_Calories()
        {
            var baker = new Baker();

            foreach (var ingredient in new IngredientReader().ReadList())
                baker.AddIngredient(ingredient);

            baker.DetermineScoreForBestPossibleCalorieRestrictedCookie(500).Should().Be(1766400);
        }

        [Test]
        public void Should_Make_Best_Calorie_Restricted_Cookie_Based_On_Ingredients()
        {
            var baker = new Baker();
            baker.AddIngredient("Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8");
            baker.AddIngredient("Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3");
            baker.DetermineScoreForBestPossibleCalorieRestrictedCookie(500).Should().Be(57600000);
        }
    }
}
