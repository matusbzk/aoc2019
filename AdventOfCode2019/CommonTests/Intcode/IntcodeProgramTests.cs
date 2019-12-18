using System;
using AdventOfCode2019.Common.Intcode;
using NUnit.Framework;

namespace AdventOfCode2019.CommonTests.Intcode
{
    [TestFixture]
    public class IntcodeProgramTests
    {
        [Test]
        public void DoOpcode_OnHaltedProgram_ThrowsInvalidOperationException()
        {
            var program = new IntcodeProgram(new long[] {99}) {IsHalted = true};
            Assert.Throws<InvalidOperationException>(() => program.PerformInstruction());
        }

        [Test]
        public void DoOpcode_ProcessingAddition_ProcessesCorrectly()
        {
            var program = new IntcodeProgram(new long[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50});

            program.PerformInstruction();

            Assert.AreEqual("1,9,10,70,2,3,11,0,99,30,40,50", string.Join(",", program.Memory));
            Assert.AreEqual(4, program.InstructionPointer);
            Assert.IsFalse(program.IsHalted);
        }

        [Test]
        public void DoOpcode_ProcessingMultiplication_ProcessesCorrectly()
        {
            var program = new IntcodeProgram(new long[] {1, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50})
                {InstructionPointer = 4};

            program.PerformInstruction();

            Assert.AreEqual("3500,9,10,70,2,3,11,0,99,30,40,50", string.Join(",", program.Memory));
            Assert.AreEqual(8, program.InstructionPointer);
            Assert.IsFalse(program.IsHalted);
        }

        [Test]
        public void DoOpcode_ProcessingHalting_HaltsProgram()
        {
            var program = new IntcodeProgram(new long[] {3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50})
                {InstructionPointer = 8};

            program.PerformInstruction();

            Assert.IsTrue(program.IsHalted);
        }

        [TestCase(new long[] { 1, 0, 0, 0, 99 }, new long[] { 2, 0, 0, 0, 99 })]
        [TestCase(new long[] { 2, 3, 0, 3, 99 }, new long[] { 2, 3, 0, 6, 99 })]
        [TestCase(new long[] { 2, 4, 4, 5, 99, 0 }, new long[] { 2, 4, 4, 5, 99, 9801 })]
        [TestCase(new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new long[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void RunUntilHalt_SimpleProgram_RunsCorrectly(long[] integers, long[] result)
        {
            var program = new IntcodeProgram(integers);

            program.RunUntilHalt();

            Assert.AreEqual(result, program.Memory);
            Assert.IsTrue(program.IsHalted);
        }

        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 42, 0)]
        [TestCase(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 5, 0)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 5, 1)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 0)]
        [TestCase(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 42, 0)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 42, 0)]
        [TestCase(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 5, 0)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 5, 1)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 8, 0)]
        [TestCase(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 42, 0)]
        public void RunUntilHalt_ProgramsWithInput_ProduceCorrectOutput(long[] integers, int input, int expectedOutput)
        {
            var program = new MockIntcodeProgram(integers, input);

            program.RunUntilHalt();

            Assert.AreEqual(expectedOutput, program.Output);
        }

        [TestCase(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0)]
        [TestCase(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 42, 1)]
        [TestCase(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0)]
        [TestCase(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 42, 1)]
        public void RunUntilHalt_ProgramsWithJumpTests_ProduceCorrectOutput(long[] integers, int input, int expectedOutput)
        {
            var program = new MockIntcodeProgram(integers, input);

            program.RunUntilHalt();

            Assert.AreEqual(expectedOutput, program.Output);
        }

        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125,
            20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 1, 999)]
        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125,
            20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 8, 1000)]
        [TestCase(new long[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125,
            20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        }, 42, 1001)]
        public void RunUntilHalt_LargerExample_ProduceCorrectOutput(long[] integers, int input, int expectedOutput)
        {
            var program = new MockIntcodeProgram(integers, input);

            program.RunUntilHalt();

            Assert.AreEqual(expectedOutput, program.Output);
        }

        [TestCase(new long[] {109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99})]
        public void IntcodeProgram_WhenProgramUsesMoreMemoryThenOriginallyAssigned_WoksCorrectly(long[] integers)
        {
            var program = new IntcodeProgram(integers);

            Assert.DoesNotThrow(program.RunUntilHalt);
        }

        [TestCase(new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 })]
        [TestCase(new long[] { 104, 1125899906842624, 99 })]
        public void IntcodeProgram_WhenDealingWithBigNumbers_WorksCorrectly(long[] integers)
        {
            var program = new IntcodeProgram(integers);

            Assert.DoesNotThrow(program.RunUntilHalt);
        }
    }
}
