using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Common.Intcode
{
    /// <summary>
    /// Represents Intcode program.
    /// </summary>
    public class IntcodeProgram
    {
        /// <summary>
        /// Memory of program.
        /// </summary>
        public List<long> Memory { get; set; }

        /// <summary>
        /// Current position of instruction pointer.
        /// </summary>
        public int InstructionPointer { get; set; }

        /// <summary>
        /// Has program halted?
        /// </summary>
        public bool IsHalted { get; set; }

        /// <summary>
        /// Relative base used for relative mode of instructions
        /// </summary>
        public int RelativeBase { get; set; }

        public IntcodeProgram(IEnumerable<long> integers)
        {
            Memory = integers.ToList();
        }

        /// <summary>
        /// Run program until it halts
        /// </summary>
        public void RunUntilHalt()
        {
            while (!IsHalted)
            {
                PerformInstruction();
            }
        }

        /// <summary>
        /// Run program until it produces output
        /// </summary>
        public virtual void RunUntilOutput()
        {
            Opcode opcode = PerformInstruction();
            while (opcode != Opcode.Output && !IsHalted)
            {
                opcode = PerformInstruction();
            }
        }

        /// <summary>
        /// Perform next instruction
        /// </summary>
        /// <returns>Opcode of instruction performed</returns>
        public Opcode PerformInstruction()
        {
            if (IsHalted)
            {
                throw new InvalidOperationException("Cannot do Opcode because program is already halted");
            }

            var instruction = new Instruction();
            instruction.AssignOpcode(Convert.ToInt32(SafeMemoryGet(InstructionPointer)));
            for (var i = 0; i < instruction.ParametersCount; i++)
            {
                instruction.AddParameter(Convert.ToInt32(SafeMemoryGet(InstructionPointer)),
                    SafeMemoryGet(InstructionPointer + i + 1));
            }

            ProcessInstruction(instruction);
            return instruction.Opcode;
        }

        /// <summary>
        /// Gets data from input.
        /// </summary>
        /// <returns>Data from input</returns>
        protected virtual long GetInput()
        {
            Console.Write("Enter input: ");
            return Convert.ToInt64(Console.ReadLine());
        }

        /// <summary>
        /// Outputs data.
        /// </summary>
        /// <param name="value">Data to output</param>
        protected virtual void DoOutput(long value)
        {
            Console.WriteLine(value);
        }

        private void ProcessInstruction(Instruction instruction)
        {
            if (instruction.Parameters.Count != instruction.ParametersCount)
            {
                throw new ArgumentException(
                    "Calling ProcessInstruction() while instruction does not contain correct number of parameters",
                    nameof(instruction));
            }

            bool instructionPointerModified = false;
            switch (instruction.Opcode)
            {
                case Opcode.Addition:
                    ProcessAddition(instruction);
                    break;
                case Opcode.Multiplication:
                    ProcessMultiplication(instruction);
                    break;
                case Opcode.Input:
                    ProcessInput(instruction);
                    break;
                case Opcode.Output:
                    ProcessOutput(instruction);
                    break;
                case Opcode.JumpIfTrue:
                    instructionPointerModified = ProcessJumpIfTrue(instruction);
                    break;
                case Opcode.JumpIfFalse:
                    instructionPointerModified = ProcessJumpIfFalse(instruction);
                    break;
                case Opcode.LessThan:
                    ProcessLessThan(instruction);
                    break;
                case Opcode.Equals:
                    ProcessEquals(instruction);
                    break;
                case Opcode.AdjustRelativeBase:
                    ProcessAdjustRelativeBase(instruction);
                    break;
                case Opcode.Halt:
                    instructionPointerModified = IsHalted = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!instructionPointerModified)
            {
                InstructionPointer += instruction.ParametersCount + 1;
            }
        }

        private void ProcessAddition(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Addition)
            {
                throw new ArgumentException(
                    "Tried to call ProcessAddition() with instruction with opcode which is not addition",
                    nameof(instruction));
            }

            SafeAssign(GetParameterAddress(instruction.Parameters[2]),
                GetParameterValue(instruction.Parameters[0]) + GetParameterValue(instruction.Parameters[1]));
        }

        private void ProcessMultiplication(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Multiplication)
            {
                throw new ArgumentException(
                    "Tried to call ProcessMultiplication() with instruction with opcode which is not multiplication",
                    nameof(instruction));
            }

            SafeAssign(GetParameterAddress(instruction.Parameters[2]),
                GetParameterValue(instruction.Parameters[0]) * GetParameterValue(instruction.Parameters[1]));
        }

        private void ProcessInput(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Input)
            {
                throw new ArgumentException(
                    "Tried to call ProcessInput() with instruction with opcode which is not input",
                    nameof(instruction));
            }

            SafeAssign(GetParameterAddress(instruction.Parameters[0]), GetInput());
        }

        private void ProcessOutput(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Output)
            {
                throw new ArgumentException(
                    "Tried to call ProcessOutput() with instruction with opcode which is not output",
                    nameof(instruction));
            }

            DoOutput(GetParameterValue(instruction.Parameters[0]));
        }

        /// <returns>True if instruction pointer has been modified</returns>
        private bool ProcessJumpIfTrue(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.JumpIfTrue)
            {
                throw new ArgumentException(
                    "Tried to call ProcessJumpIfTrue() with instruction with opcode which is not jump-if-true",
                    nameof(instruction));
            }

            if (GetParameterValue(instruction.Parameters[0]) != 0)
            {
                InstructionPointer = Convert.ToInt32(GetParameterValue(instruction.Parameters[1]));
                return true;
            }

            return false;
        }

        /// <returns>True if instruction pointer has been modified</returns>
        private bool ProcessJumpIfFalse(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.JumpIfFalse)
            {
                throw new ArgumentException(
                    "Tried to call ProcessJumpIfFalse() with instruction with opcode which is not jump-if-false",
                    nameof(instruction));
            }

            if (GetParameterValue(instruction.Parameters[0]) == 0)
            {
                InstructionPointer = Convert.ToInt32(GetParameterValue(instruction.Parameters[1]));
                return true;
            }

            return false;
        }

        private void ProcessLessThan(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.LessThan)
            {
                throw new ArgumentException(
                    "Tried to call ProcessLessThan() with instruction with opcode which is not less than",
                    nameof(instruction));
            }

            SafeAssign(GetParameterAddress(instruction.Parameters[2]),
                GetParameterValue(instruction.Parameters[0]) < GetParameterValue(instruction.Parameters[1]) ? 1 : 0);
        }

        private void ProcessEquals(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Equals)
            {
                throw new ArgumentException(
                    "Tried to call ProcessEquals() with instruction with opcode which is not equals",
                    nameof(instruction));
            }

            SafeAssign(GetParameterAddress(instruction.Parameters[2]),
                GetParameterValue(instruction.Parameters[0]) == GetParameterValue(instruction.Parameters[1]) ? 1 : 0);
        }

        private void ProcessAdjustRelativeBase(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.AdjustRelativeBase)
            {
                throw new ArgumentException(
                    "Tried to call ProcessAdjustRelativeBase() with instruction with opcode which is not adjust relative base",
                    nameof(instruction));
            }

            RelativeBase += Convert.ToInt32(GetParameterValue(instruction.Parameters[0]));
        }

        private long GetParameterValue(Parameter parameter)
        {
            switch (parameter.Mode)
            {
                case ParameterMode.Position:
                    return SafeMemoryGet(Convert.ToInt32(parameter.Value));
                case ParameterMode.Immediate:
                    return parameter.Value;
                case ParameterMode.Relative:
                    return SafeMemoryGet(Convert.ToInt32(RelativeBase + parameter.Value));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Get number of address where this parameter refers to.
        /// Does not work for immediate parameter mode.
        /// </summary>
        /// <param name="parameter">Parameter</param>
        private int GetParameterAddress(Parameter parameter)
        {
            switch (parameter.Mode)
            {
                case ParameterMode.Position:
                    return Convert.ToInt32(parameter.Value);
                case ParameterMode.Relative:
                    return Convert.ToInt32(RelativeBase + parameter.Value);
                case ParameterMode.Immediate:
                    throw new ArgumentException("Parameters that an instruction writes to cannot be in immediate mode",
                        nameof(parameter));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Safely gets value from memory.
        /// If memory is not long enough, it allocks more.
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Value at given index</returns>
        private long SafeMemoryGet(int index)
        {
            if (index >= Memory.Count)
            {
                Memory.AddRange(Enumerable.Repeat((long) 0, index - Memory.Count + 1));
            }

            return Memory[index];
        }

        /// <summary>
        /// Safely assigns value to memory.
        /// If memory is not long enough, it allocks more.
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="value">Value</param>
        private void SafeAssign(int index, long value)
        {
            if (index >= Memory.Count)
            {
                Memory.AddRange(Enumerable.Repeat((long) 0, index - Memory.Count + 1));
            }

            Memory[index] = value;
        }
    }
}
