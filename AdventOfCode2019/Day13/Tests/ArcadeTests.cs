using AdventOfCode2019.Common.Geometry;
using NUnit.Framework;

namespace AdventOfCode2019.Day13.Tests
{
    [TestFixture]
    public class ArcadeTests
    {
        [Test]
        public void DoOutput_GivenSimpleInstructions_BehavesCorrectly()
        {
            var arcade = new Arcade(new long[] {}, 0);

            arcade.TriggerOutputs(new long[] {1, 2, 3, 6, 5, 4});

            Assert.AreEqual(2, arcade.Map.Count);
            Assert.IsTrue(arcade.Map.ContainsKey(new Position(1,2)));
            Assert.AreEqual(Tile.HorizontalPaddle, arcade.Map[new Position(1, 2)]);
            Assert.IsTrue(arcade.Map.ContainsKey(new Position(6, 5)));
            Assert.AreEqual(Tile.Ball, arcade.Map[new Position(6, 5)]);
        }
    }
}
