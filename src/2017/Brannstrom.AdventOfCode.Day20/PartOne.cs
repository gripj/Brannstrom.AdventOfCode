using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Brannstrom.AdventOfCode.Day20
{
    [TestFixture]
    public class PartOne
    {
        [Test]
        public void Should_Parse_Particles()
        {
            var input = new List<string>()
            {
                "p=<2366,784,-597>, v=<-12,-41,50>, a=<-5,1,-2>",
                "p=<-2926,-3402,-2809>, v=<-55,65,-16>, a=<11,4,8>"
            };

            var particles = new ParticleSwarm(input).Particles;

            var firstParticle = particles.First();

            firstParticle.Position.X.Should().Be(2366);
            firstParticle.Position.Y.Should().Be(784);
            firstParticle.Position.Z.Should().Be(-597);

            firstParticle.Velocity.X.Should().Be(-12);
            firstParticle.Velocity.Y.Should().Be(-41);
            firstParticle.Velocity.Z.Should().Be(50);

            firstParticle.Acceleration.X.Should().Be(-5);
            firstParticle.Acceleration.Y.Should().Be(1);
            firstParticle.Acceleration.Z.Should().Be(-2);

            var secondParticle = particles[1];

            firstParticle.Id.Should().Be(0);
            secondParticle.Id.Should().Be(1);
        }

        [Test]
        public void Should_Get_Particle_Closest_To_Origin_In_Example()
        {
            var input = new List<string>()
            {
                "p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>",
                "p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>"
            };

            new ParticleSwarm(input)
                .GetParticleNumberClosestToOrigin()
                .Should()
                .Be(0);
        }

        [Test]
        public void Should_Get_Particle_Closest_To_Origin()
        {
            new ParticleSwarm(File.ReadAllLines("input.txt"))
                .GetParticleNumberClosestToOrigin()
                .Should()
                .Be(170);
        }
    }
}
