using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartTwo
    {
        private RoomDecrypter _roomDecrypter;

        [SetUp]
        public void SetUp()
        {
            _roomDecrypter = new RoomDecrypter();
        }

        [Test]
        public void Should_Decrypt_RoomName()
        {
            _roomDecrypter
                .DecryptName(EncryptedRoom.Parse("qzmt-zixmtkozy-ivhz-343[123]"))
                .Should()
                .Be("very encrypted name");
        }

        [Test]
        public void Should_Find_Room_Storing_NorthPole_Objects()
        {
            new InputReader()
                .ReadFile()
                .Select(EncryptedRoom.Parse)
                .First(x => _roomDecrypter.DecryptName(x).Contains("pole"))
                .SectorId
                .Should().Be(482);
        }
    }
}
