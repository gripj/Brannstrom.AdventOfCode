namespace Brannstrom.AdventOfCode.Day20
{
    public class Particle
    {
        public int Id { get; }
        public Vector Position { get; }
        public Vector Velocity { get; }
        public Vector Acceleration { get; }
        public bool IsDestroyed { get; set; }

        public Particle(int id, Vector position, Vector velocity, Vector acceleration)
        {
            Id = id;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        public void Move()
        {
            (Velocity.X, Velocity.Y, Velocity.Z) = (Velocity.X + Acceleration.X, Velocity.Y + Acceleration.Y, Velocity.Z + Acceleration.Z);
            (Position.X, Position.Y, Position.Z) = (Position.X + Velocity.X, Position.Y + Velocity.Y, Position.Z + Velocity.Z);
        }
    }
}
