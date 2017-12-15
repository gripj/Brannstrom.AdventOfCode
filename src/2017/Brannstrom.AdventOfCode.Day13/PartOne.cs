using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day13
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Create_FireWall_From_Description()
        {
            var firewall = new FireWall(new List<string>(){ "0: 3", "1: 2"});

            firewall.Layers[0].Depth.Should().Be(0);
            firewall.Layers[0].Range.Should().Be(3);
            firewall.Layers[1].Depth.Should().Be(1);
            firewall.Layers[1].Range.Should().Be(2);
        }

        [Test]
        public void SecurityScanner_Should_Start_At_Top_Of_Range()
        {
            new SecurityScanner(3).CurrentPosition.Should().Be(1);
        }

        [Test]
        public void SecurityScanner_Should_Move_Down_One_Position()
        {
            var scanner = new SecurityScanner(3);
            scanner.Move();
            scanner.CurrentPosition.Should().Be(2);
        }

        [Test]
        public void SecurityScanner_Should_Move_In_Other_Direction_When_At_Bottom()
        {
            var scanner = new SecurityScanner(3);
            scanner.Move();
            scanner.Move();
            scanner.Move();
            scanner.CurrentPosition.Should().Be(2);
        }

        [Test]
        public void SecurityScanner_Should_Move_In_Other_Direction_When_Reaching_Top()
        {
            var scanner = new SecurityScanner(3);
            scanner.Move();
            scanner.Move();
            scanner.Move();
            scanner.Move();
            scanner.Move();
            scanner.CurrentPosition.Should().Be(2);
        }

        [Test]
        public void Should_Calculate_Severity_Of_Moving_Packet_Through_Firewall_In_Example()
        {
            var fireWall = new FireWall(new List<string>()
            { "0: 3",
              "1: 2",
              "4: 4",
              "6: 4"
            });

            var packet = new Packet();

            fireWall.MovePacket(packet);

            packet.Severity.Should().Be(24);
        }

        [Test]
        public void Should_Calculate_Severity_Of_Moving_Packet_Through_Firewall()
        {
            var firewall = new FireWall(File.ReadAllLines("input.txt"));

            var packet = new Packet();

            firewall.MovePacket(packet);

            packet.Severity.Should().Be(1316);
        }
    }
}
