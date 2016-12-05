using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartOne
    {
        private PasswordSolver _passwordSolver;

        [SetUp]
        public void SetUp()
        {
            _passwordSolver = new PasswordSolver();   
        }

        [Test]
        public void Should_Find_Example_Password()
        {
            _passwordSolver.FindPassword("abc").Should().Be("18f47a30"); 
        }

        [Test]
        public void Should_Find_Password()
        {
            _passwordSolver.FindPassword("wtnhxymk").Should().Be("2414bc77");
        }
    }
}
