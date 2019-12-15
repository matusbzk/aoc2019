using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2019.Day03.Tests
{
    [TestFixture]
    public class WireTests
    {
        [Test]
        public void Constructor_GivenValidInput_SetsInstructionsCorrectly()
        {
            var wire = new Wire("R8,U5,L5,D3");

            Assert.AreEqual(4, wire.Instructions.Count);
            Assert.AreEqual(new Instruction("R8"), wire.Instructions[0]);
            Assert.AreEqual(new Instruction("U5"), wire.Instructions[1]);
            Assert.AreEqual(new Instruction("L5"), wire.Instructions[2]);
            Assert.AreEqual(new Instruction("D3"), wire.Instructions[3]);
        }

        [Test]
        public void Path_ReturnCorrectResult()
        {
            var wire = new Wire("R8,U5,L5,D3");

            var path = wire.Path.ToArray();

            Assert.AreEqual(21, path.Length);
            Assert.IsTrue(path.Contains(new OrderedPosition(1, 0, 1)));
            Assert.IsTrue(path.Contains(new OrderedPosition(2, 0, 2)));
            Assert.IsTrue(path.Contains(new OrderedPosition(3, 0, 3)));
            Assert.IsTrue(path.Contains(new OrderedPosition(4, 0, 4)));
            Assert.IsTrue(path.Contains(new OrderedPosition(5, 0, 5)));
            Assert.IsTrue(path.Contains(new OrderedPosition(6, 0, 6)));
            Assert.IsTrue(path.Contains(new OrderedPosition(7, 0, 7)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 0, 8)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 1, 9)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 2, 10)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 3, 11)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 4, 12)));
            Assert.IsTrue(path.Contains(new OrderedPosition(8, 5, 13)));
            Assert.IsTrue(path.Contains(new OrderedPosition(7, 5, 14)));
            Assert.IsTrue(path.Contains(new OrderedPosition(6, 5, 15)));
            Assert.IsTrue(path.Contains(new OrderedPosition(5, 5, 16)));
            Assert.IsTrue(path.Contains(new OrderedPosition(4, 5, 17)));
            Assert.IsTrue(path.Contains(new OrderedPosition(3, 5, 18)));
            Assert.IsTrue(path.Contains(new OrderedPosition(3, 4, 19)));
            Assert.IsTrue(path.Contains(new OrderedPosition(3, 3, 20)));
            Assert.IsTrue(path.Contains(new OrderedPosition(3, 2, 21)));
        }
    }
}
