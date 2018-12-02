using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day20
{
    [TestFixture]
    public class PartTwo
    {
        [Test]
        public void Should_Get_Particle_Count_After_Collisions_In_Example()
        {
            var input = new List<string>()
            {
                "p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>",
                "p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>",
                "p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>",
                "p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>"
            };

            new ParticleSwarm(input)
                .GetParticleCountAfterCollisions()
                .Should()
                .Be(1);
        }

        [Test]
        public void Should_Get_Particle_Count_After_Collisions()
        {
            new ParticleSwarm(File.ReadAllLines("input.txt"))
                .GetParticleCountAfterCollisions()
                .Should()
                .Be(571);
        }
    }
}
