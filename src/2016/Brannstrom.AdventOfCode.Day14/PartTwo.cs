using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day14
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Find_Index_In_Example()
        {
            const string salt = "abc";

            new OneTimePadGenerator(salt, 2017)
                .GetIndexForKey(64)
                .Should()
                .Be(22551);           
        }

        [Test]
        public void Should_Find_Index_That_Produces_64th_Key_After_2017_Hashes()
        {
            const string salt = "ngcjuoqr";

            new OneTimePadGenerator(salt, 2017)
                .GetIndexForKey(64)
                .Should()
                .Be(20092);
        }
    }
}
