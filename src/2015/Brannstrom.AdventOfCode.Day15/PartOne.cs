using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day15
{
    [TestFixture]
    public class PartOne
    {
        private Baker _baker;

        [SetUp]
        public void SetUp()
        {
            _baker = new Baker();
            foreach (var ingredient in new IngredientReader().ReadList())
                _baker.AddIngredient(ingredient);
        }

        [Test]
        public void Should_Make_Perfect_Cookie()
        {
            _baker.DetermineScoreForBestPossibleCookie().Should().Be(21367368); 
        }

        [Test]
        public void Should_Get_Possible_Ingredient_Combinations()
        {
            _baker.GetPossibleIngredientCombinations().Count().Should().Be(156849);
        }

        [Test]
        public void Should_Make_Best_Cookie_Based_On_Ingredients()
        {
            var baker = new Baker();
            baker.AddIngredient("Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8");
            baker.AddIngredient("Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3");
            baker.DetermineScoreForBestPossibleCookie().Should().Be(62842880);
        }
    }
}
