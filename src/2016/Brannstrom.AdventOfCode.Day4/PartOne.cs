using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day4
{
    [TestFixture]
    public class PartOne
    {
        private RoomDecrypter _roomDecrypter;

        [SetUp]
        public void SetUp()
        {
            _roomDecrypter = new RoomDecrypter();
        }

        [Test]
        public void Should_Parse_Encrypted_Room()
        {
            var result = EncryptedRoom.Parse("aaaaa-bbb-z-y-x-123[abxyz]");

            result.Checksum.Should().Be("abxyz");
            result.SectorId.Should().Be(123);
            result.EncryptedName.Should().Be("aaaaa-bbb-z-y-x");
        }

        [Test]
        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", true)]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", true)]
        [TestCase("not-a-real-room-404[oarel]", true)]
        [TestCase("totally-real-room-200[decoy]", false)]
        public void Should_Validate_Rooms(string encryptedRoom, bool expectedResult)
        {
            _roomDecrypter
                .ValidateEncryptedRoom(EncryptedRoom.Parse(encryptedRoom))
                .Should()
                .Be(expectedResult);
        }

        [Test]
        public void Should_Calculate_Sum_Of_Real_Room_Sector_Ids()
        {
            new InputReader()
                .ReadFile()
                .Select(EncryptedRoom.Parse)
                .Where(_roomDecrypter.ValidateEncryptedRoom)
                .Sum(x => x.SectorId)
                .Should()
                .Be(361724);
        }
    }
}
