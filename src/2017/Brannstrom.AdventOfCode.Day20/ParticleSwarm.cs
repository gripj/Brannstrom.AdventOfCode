using System;
using System.Collections.Generic;
using System.Linq;

namespace Brannstrom.AdventOfCode.Day20
{
    public class ParticleSwarm
    {
        public List<Particle> Particles { get; }

        public ParticleSwarm(IEnumerable<string> input)
        {
            Particles = Parse(input);
        }

        public int GetParticleNumberClosestToOrigin()
        {
            return (
                from particle in Particles
                orderby particle.Acceleration.DistanceToOrigin(), 
                        particle.Velocity.DistanceToOrigin(), 
                        particle.Position.DistanceToOrigin()
                select particle
            ).First().Id;
        }

        public int GetParticleCountAfterCollisions()
        {
            var particles = Particles;

            for (var count = 0; count < 50; count++)
            {
                foreach (var particle in particles)
                    particle.Move();

                foreach (var particle in particles)
                    particle.IsDestroyed = particles.Count(p => p.Position.Equals(particle.Position)) > 1 || particle.IsDestroyed;

                var destroyedParticles = particles.Where(p => p.IsDestroyed).ToArray();
                foreach (var destroyedParticle in destroyedParticles)
                    particles.Remove(destroyedParticle);
            }

            return particles.Count;
        }

        private static List<Particle> Parse(IEnumerable<string> input)
        {
            return Enumerable.Zip(input, Enumerable.Range(0, int.MaxValue), (line, i) => (i: i, line: line))
                    .Select(ToParticle)
                    .ToList();
        }

        private static Particle ToParticle((int id, string input) info)
        {
            var points = info.input.Split(new string[] { ", " }, StringSplitOptions.None).Select(ToVector).ToList();

            var p = points[0];
            var v = points[1];
            var a = points[2];

            return new Particle(info.id, p, v, a);
        }

        private static Vector ToVector(string coordinates)
        {
            var values = coordinates.Substring(3).Replace("<", "").Replace(">", "").Split(',').Select(int.Parse).ToList();

            return new Vector(values[0], values[1], values[2]);
        }
    }
}
