using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Find_Index_In_Example()
        {
            const string salt = "abc";

            new OneTimePadGenerator(salt)
                .GetIndexForKey(64)
                .Should()
                .Be(22728);
        }

        [Test]
        public void Should_Find_Index_That_Produces_64th_Key()
        {
            const string salt = "ngcjuoqr";

            new OneTimePadGenerator(salt)
                .GetIndexForKey(64)
                .Should()
                .Be(18626);
        }
    }
}
