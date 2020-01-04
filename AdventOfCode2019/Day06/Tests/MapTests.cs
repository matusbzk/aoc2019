using NUnit.Framework;

namespace AdventOfCode2019.Day06.Tests
{
    [TestFixture]
    public class MapTests
    {
        [Test]
        public void NumberOfOrbits_GivenTestData_ReturnsCorrectResult() =>
            Assert.AreEqual(42, TestData.TestMap().NumberOfOrbits());

        [Test]
        public void OrbitalTransfersToSanta_GivenTestData_ReturnsCorrectResult() =>
            Assert.AreEqual(4, TestData.TestMap2().OrbitalTransfersToSanta());
    }
}
