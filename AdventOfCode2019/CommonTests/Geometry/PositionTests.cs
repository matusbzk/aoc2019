using AdventOfCode2019.Common.Geometry;
using NUnit.Framework;

namespace AdventOfCode2019.CommonTests.Geometry
{
    [TestFixture]
    public class PositionTests
    {
        [TestCase(0, 0, 0, -1, 0)]
        [TestCase(0, 0, 1, -1, 45)]
        [TestCase(0, 0, 1, 0, 90)]
        [TestCase(0, 0, 0, 1, 180)]
        [TestCase(0, 0, -1, 0, 270)]
        [TestCase(0, 0, -1, -1, 315)]
        public void GetAngle_OnSimplePositions_ReturnsCorrectResult(int x1, int y1, int x2, int y2, double expectedResult)
        {
            var position = new Position(x1, y1);
            var other = new Position(x2, y2);

            var actualResult = position.GetAngle(other);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
