using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day20
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_First_Houses_To_Receive_Indicated_Amount_Of_Presents_When_Elves_Are_Tired()
        {
            var neverendingStreet = new NeverendingStreet();

            neverendingStreet.TireElvesOut();
            neverendingStreet.DeliverPresents();

            neverendingStreet.GetFirstHouseToReceiveAmountOfPresents(34000000).Should().Be(831600);
        }

        [Test]
        public void Amount_Of_Presents_Delivered_When_Tired_Should_Be_Eleven_Times_Number()
        {
            var house = new House(2);
            var elf = new Elf(2);
            elf.Tire();
            elf.DeliverPresents(house);
            house.Presents.Should().Be(22);
        }

        [Test]
        public void Tired_Elves_Should_Stop_Delivering_Presents_After_50_Houses_Have_Been_Visited()
        {
            var houses = new List<House>();
            for (var i = 1; i <= 100; i++)
                houses.Add(new House(i));

            var elf = new Elf(1);
            elf.Tire();

            for (var i = 0; i < 100; i++)
                elf.DeliverPresents(houses[i]);

            houses.Where(x => x.Presents > 0).ToList().Count.Should().Be(50);
        }
    }
}
