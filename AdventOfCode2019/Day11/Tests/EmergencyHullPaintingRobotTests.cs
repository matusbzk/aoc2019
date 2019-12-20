using System.Collections.Generic;
using AdventOfCode2019.Common.Geometry;
using NUnit.Framework;

namespace AdventOfCode2019.Day11.Tests
{
    [TestFixture]
    public class EmergencyHullPaintingRobotTests
    {
        [Test]
        public void EmergencyHullPaintingRobot_InExampleScenarios_WorksCorrectly()
        {
            var robot = new EmergencyHullPaintingRobot(new List<long>(), Color.Black);

            Assert.AreEqual(Direction.Up, robot.Direction);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            Assert.AreEqual(0, robot.TriggerInput());
            robot.TriggerOutput(1);
            robot.TriggerOutput(0);

            Assert.AreEqual(Direction.Left, robot.Direction);
            Assert.AreEqual(-1, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            Assert.AreEqual(0, robot.TriggerInput());
            robot.TriggerOutput(0);
            robot.TriggerOutput(0);

            Assert.AreEqual(Direction.Down, robot.Direction);
            Assert.AreEqual(-1, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);

            robot.TriggerInput();
            robot.TriggerOutput(1);
            robot.TriggerOutput(0);
            robot.TriggerInput();
            robot.TriggerOutput(1);
            robot.TriggerOutput(0);

            Assert.AreEqual(Direction.Up, robot.Direction);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(0, robot.Position.Y);

            Assert.AreEqual(1, robot.TriggerInput());
            robot.TriggerOutput(0);
            robot.TriggerOutput(1);
            robot.TriggerInput();
            robot.TriggerOutput(1);
            robot.TriggerOutput(0);
            robot.TriggerInput();
            robot.TriggerOutput(1);
            robot.TriggerOutput(0);

            Assert.AreEqual(Direction.Left, robot.Direction);
            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(-1, robot.Position.Y);

            Assert.AreEqual(6, robot.PaintedPanelsCount());
        }
    }
}
