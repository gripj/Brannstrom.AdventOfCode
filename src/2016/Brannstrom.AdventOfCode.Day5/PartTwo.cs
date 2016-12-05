using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day5
{
    [TestFixture]
    public class PartTwo
    {
        private PasswordSolver _passworldSolver;

        [SetUp]
        public void SetUp()
        {
            _passworldSolver = new PasswordSolver();
        }

        [Test]
        public void Should_Find_Example_Password()
        {
            _passworldSolver.FindAdvancedPassword("abc").Should().Be("05ace8e3");
        }

        [Test]
        public void Should_Find_Password()
        {
            _passworldSolver.FindAdvancedPassword("wtnhxymk").Should().Be("437e60fc");
        }
    }
}
