using System;
using NUnit.Framework;

namespace AdventOfCode2019.Day02.Tests
{
    [TestFixture]
    public class IntcodeProgramTests
    {
        [Test]
        public void DoOpcode_OnHaltedProgram_ThrowsInvalidOperationException()
        {
            var program = new IntcodeProgram(new[] {99}) {IsHalted = true};
            Assert.Throws<InvalidOperationException>(program.DoOpcode);
        }

        [Test]
        public void DoOpcode_ProcessingAddition_ProcessesCorrectly()
        {
            var program = new IntcodeProgram(new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50});

            program.DoOpcode();

            Assert.AreEqual("1,9,10,70,2,3,11,0,99,30,40,50", string.Join(",", program.Memory));
            Assert.AreEqual(4, program.Position);
            Assert.IsFalse(program.IsHalted);
        }

        [Test]
        public void DoOpcode_ProcessingMultiplication_ProcessesCorrectly()
        {
            var program = new IntcodeProgram(new[] {1, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50}) {Position = 4};

            program.DoOpcode();

            Assert.AreEqual("3500,9,10,70,2,3,11,0,99,30,40,50", string.Join(",", program.Memory));
            Assert.AreEqual(8, program.Position);
            Assert.IsFalse(program.IsHalted);
        }

        [Test]
        public void DoOpcode_ProcessingHalting_HaltsProgram()
        {
            var program = new IntcodeProgram(new[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 }) { Position = 8 };

            program.DoOpcode();

            Assert.IsTrue(program.IsHalted);
        }

        [TestCase(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [TestCase(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [TestCase(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [TestCase(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void RunUntilHalt_SimpleProgram_RunsCorrectly(int[] integers, int[] result)
        {
            var program = new IntcodeProgram(integers);

            program.RunUntilHalt();

            Assert.AreEqual(result, program.Memory);
            Assert.IsTrue(program.IsHalted);
        }
    }
}
