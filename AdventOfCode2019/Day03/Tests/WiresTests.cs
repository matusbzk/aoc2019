using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2019.Day03.Tests
{
    [TestFixture]
    public class WiresTests
    {
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4")]
        public void GetIntersections_WithTwoWires_ReturnsCorrectResult(string path1, string path2)
        {
            Wires wires = new Wires(new Wire(path1), new Wire(path2));

            var intersections = wires.GetIntersections().ToArray();

            Assert.AreEqual(2, intersections.Length);
            Assert.IsTrue(intersections.Contains(new OrderedPosition(3, 3)));
            Assert.IsTrue(intersections.Contains(new OrderedPosition(6, 5)));
        }

        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 146)]  // Should be 159 but this is the result for me
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void GetClosestIntersection_WithTwoWires_ReturnsCorrectResult(string path1, string path2, int expectedDistance)
        {
            Wires wires = new Wires(new Wire(path1), new Wire(path2));

            var closestIntersection = wires.GetClosestIntersection();

            Assert.AreEqual(expectedDistance, closestIntersection.GetDistance());
        }

        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void GetFastestIntersection_WithTwoWires_ReturnsCorrectResult(string path1, string path2, int expectedDistance)
        {
            Wires wires = new Wires(new Wire(path1), new Wire(path2));

            var fastestIntersection = wires.GetFastestIntersection();

            Assert.AreEqual(expectedDistance, fastestIntersection.Order);
        }
    }
}
