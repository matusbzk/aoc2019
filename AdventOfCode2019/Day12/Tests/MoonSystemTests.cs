using System.Linq;
using AdventOfCode2019.Common.Geometry;
using NUnit.Framework;

namespace AdventOfCode2019.Day12.Tests
{
    [TestFixture]
    public class MoonSystemTests
    {
        [Test]
        public void PerformTimeStep_WhenRunOnExampleData_WorksCorrectly()
        {
            var moonSystem = new MoonSystem(new Moon[]
            {
                new Moon(new Position3D(-1, 0, 2), new Position3D()),
                new Moon(new Position3D(2, -10, -7), new Position3D()),
                new Moon(new Position3D(4, -8, 8), new Position3D()),
                new Moon(new Position3D(3, 5, -1), new Position3D())
            });

            moonSystem.PerformTimeStep();

            Assert.AreEqual(2, moonSystem.Moons.ElementAt(0).Position.X);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(0).Position.Y);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(0).Position.Z);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(0).Velocity.X);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(0).Velocity.Y);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(0).Velocity.Z);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(1).Position.X);
            Assert.AreEqual(-7, moonSystem.Moons.ElementAt(1).Position.Y);
            Assert.AreEqual(-4, moonSystem.Moons.ElementAt(1).Position.Z);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(1).Velocity.X);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(1).Velocity.Y);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(1).Velocity.Z);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(2).Position.X);
            Assert.AreEqual(-7, moonSystem.Moons.ElementAt(2).Position.Y);
            Assert.AreEqual(5, moonSystem.Moons.ElementAt(2).Position.Z);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(2).Velocity.X);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(2).Velocity.Y);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(2).Velocity.Z);
            Assert.AreEqual(2, moonSystem.Moons.ElementAt(3).Position.X);
            Assert.AreEqual(2, moonSystem.Moons.ElementAt(3).Position.Y);
            Assert.AreEqual(0, moonSystem.Moons.ElementAt(3).Position.Z);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(3).Velocity.X);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(3).Velocity.Y);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(3).Velocity.Z);

            moonSystem.PerformTimeStep(9);

            Assert.AreEqual(2, moonSystem.Moons.ElementAt(0).Position.X);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(0).Position.Y);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(0).Position.Z);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(0).Velocity.X);
            Assert.AreEqual(-2, moonSystem.Moons.ElementAt(0).Velocity.Y);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(0).Velocity.Z);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(1).Position.X);
            Assert.AreEqual(-8, moonSystem.Moons.ElementAt(1).Position.Y);
            Assert.AreEqual(0, moonSystem.Moons.ElementAt(1).Position.Z);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(1).Velocity.X);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(1).Velocity.Y);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(1).Velocity.Z);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(2).Position.X);
            Assert.AreEqual(-6, moonSystem.Moons.ElementAt(2).Position.Y);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(2).Position.Z);
            Assert.AreEqual(3, moonSystem.Moons.ElementAt(2).Velocity.X);
            Assert.AreEqual(2, moonSystem.Moons.ElementAt(2).Velocity.Y);
            Assert.AreEqual(-3, moonSystem.Moons.ElementAt(2).Velocity.Z);
            Assert.AreEqual(2, moonSystem.Moons.ElementAt(3).Position.X);
            Assert.AreEqual(0, moonSystem.Moons.ElementAt(3).Position.Y);
            Assert.AreEqual(4, moonSystem.Moons.ElementAt(3).Position.Z);
            Assert.AreEqual(1, moonSystem.Moons.ElementAt(3).Velocity.X);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(3).Velocity.Y);
            Assert.AreEqual(-1, moonSystem.Moons.ElementAt(3).Velocity.Z);
        }

        [Test]
        public void GetTotalEnergy_GivenExampleData_ReturnsCorrectResult()
        {
            var moonSystem = new MoonSystem(new Moon[]
            {
                new Moon(new Position3D(-1, 0, 2), new Position3D()),
                new Moon(new Position3D(2, -10, -7), new Position3D()),
                new Moon(new Position3D(4, -8, 8), new Position3D()),
                new Moon(new Position3D(3, 5, -1), new Position3D())
            });

            moonSystem.PerformTimeStep(10);
            var actualResult = moonSystem.GetTotalEnergy();

            Assert.AreEqual(179, actualResult);
        }

        [Test]
        public void SimulateUntilPreviousStateEncounter_OnSimpleExample_PerformsCorrectNumberOfSteps()
        {
            var moonSystem = new MoonSystem(new[]
            {
                new Moon(new Position3D(-1, 0, 2), new Position3D()),
                new Moon(new Position3D(2, -10, -7), new Position3D()),
                new Moon(new Position3D(4, -8, 8), new Position3D()),
                new Moon(new Position3D(3, 5, -1), new Position3D())
            });

            moonSystem.SimulateUntilPreviousStateEncounter();

            Assert.AreEqual(2772, moonSystem.StepsPerformed);
        }

        /// <remarks>Program is not effective enough</remarks>
        [Test]
        public void SimulateUntilPreviousStateEncounter_OnLongerExample_PerformsCorrectNumberOfSteps()
        {
            var moonSystem = new MoonSystem(new[]
            {
                new Moon(new Position3D(-8, -10, 0), new Position3D()),
                new Moon(new Position3D(5, 5, 10), new Position3D()),
                new Moon(new Position3D(2, -7, 3), new Position3D()),
                new Moon(new Position3D(9, -8, -3), new Position3D())
            });

            moonSystem.SimulateUntilPreviousStateEncounter();

            Assert.AreEqual(4686774924, moonSystem.StepsPerformed);
        }
    }
}
