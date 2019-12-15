using AdventOfCode2019.Common.Geometry;
using NUnit.Framework;

namespace AdventOfCode2019.Day03.Tests
{
    [TestFixture]
    public class InstructionTests
    {
        [TestCase("R8", Direction.Right, 8)]
        [TestCase("U5", Direction.Up, 5)]
        [TestCase("L5", Direction.Left, 5)]
        [TestCase("D3", Direction.Down, 3)]
        public void Constructor_GivenValidInput_CorrectlySetsData(string input, Direction expectedDirection,
            int expectedDistance)
        {
            var instruction = new Instruction(input);

            Assert.AreEqual(expectedDirection, instruction.Direction);
            Assert.AreEqual(expectedDistance, instruction.Distance);
        }
    }
}
