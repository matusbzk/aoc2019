﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day12
{
    public class MoonSystem
    {
        public IList<Moon> Moons { get; set; }

        public MoonSystem(IEnumerable<Moon> moons)
        {
            Moons = moons.ToList();
        }

        /// <summary>
        /// Performs a time step
        /// </summary>
        public void PerformTimeStep(int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                ApplyGravity();
                ApplyVelocity();
            }
        }

        /// <summary>
        /// Returns total energy of the system
        /// </summary>
        public int GetTotalEnergy() => Moons.Select(m => m.GetTotalEnergy()).Sum();

        /// <summary>
        /// Applies gravity.
        /// To apply gravity, consider every pair of moons. On each axis (x, y, and z),
        /// the velocity of each moon changes by exactly +1 or -1 to pull the moons together.
        /// </summary>
        private void ApplyGravity()
        {
            foreach (var moon in Moons)
            {
                foreach (var other in Moons.Where(m => Moons.IndexOf(moon) < Moons.IndexOf(m)))
                {
                    if (moon.Position.X > other.Position.X)
                    {
                        moon.Velocity.X--;
                        other.Velocity.X++;
                    }
                    if (moon.Position.X < other.Position.X)
                    {
                        moon.Velocity.X++;
                        other.Velocity.X--;
                    }
                    if (moon.Position.Y > other.Position.Y)
                    {
                        moon.Velocity.Y--;
                        other.Velocity.Y++;
                    }
                    if (moon.Position.Y < other.Position.Y)
                    {
                        moon.Velocity.Y++;
                        other.Velocity.Y--;
                    }
                    if (moon.Position.Z > other.Position.Z)
                    {
                        moon.Velocity.Z--;
                        other.Velocity.Z++;
                    }
                    if (moon.Position.Z < other.Position.Z)
                    {
                        moon.Velocity.Z++;
                        other.Velocity.Z--;
                    }
                }
            }
        }

        /// <summary>
        /// Applies velocity.
        /// Simply add the velocity of each moon to its own position
        /// </summary>
        private void ApplyVelocity()
        {
            foreach (var moon in Moons)
            {
                moon.Position += moon.Velocity;
            }
        }
    }
}
