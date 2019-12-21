using System;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day12
{
    /// <summary>
    /// Represents a moon
    /// </summary>
    public class Moon
    {
        /// <summary>
        /// Position of the moon
        /// </summary>
        public Position3D Position { get; set; }

        /// <summary>
        /// Velocity of the moon
        /// </summary>
        public Position3D Velocity { get; set; }

        public Moon(Position3D position, Position3D velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        /// <summary>
        /// Returns total energy of the moon
        /// </summary>
        public int GetTotalEnergy() => GetPotentialEnergy() * GetKineticEnergy();

        /// <inheritdoc />
        public override string ToString() =>
            $"pos=<x={Position.X}, y={Position.Y}, z={Position.Z}>, vel=<x={Velocity.X}, y={Velocity.Y}, z={Velocity.Z}>";

        private int GetPotentialEnergy() => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);

        private int GetKineticEnergy() => Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z);
    }
}
