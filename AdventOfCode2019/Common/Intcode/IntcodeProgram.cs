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
        public int[] Memory { get; set; }

        /// <summary>
        /// Current position of instruction pointer.
        /// </summary>
        public int InstructionPointer { get; set; }

        /// <summary>
        /// Has program halted?
        /// </summary>
        public bool IsHalted { get; set; }

        public IntcodeProgram(IEnumerable<int> integers)
        {
            Memory = integers.ToArray();
            InstructionPointer = 0;
            IsHalted = false;
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
        /// Perform next instruction
        /// </summary>
        public void PerformInstruction()
        {
            if (IsHalted)
            {
                throw new InvalidOperationException("Cannot do Opcode because program is already halted");
            }

            var instruction = new Instruction();
            instruction.AssignOpcode(Memory[InstructionPointer]);
            for (var i = 0; i < instruction.ParametersCount; i++)
            {
                instruction.AddParameter(Memory[InstructionPointer], Memory[InstructionPointer + i + 1]);
            }

            ProcessInstruction(instruction); 
        }

        /// <summary>
        /// Gets data from input.
        /// </summary>
        /// <returns>Data from input</returns>
        protected virtual int GetInput()
        {
            Console.Write("Enter input: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Outputs data.
        /// </summary>
        /// <param name="value">Data to output</param>
        protected virtual void DoOutput(int value)
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

            Memory[instruction.Parameters[2].Value] = GetParameterValue(instruction.Parameters[0]) +
                                                      GetParameterValue(instruction.Parameters[1]);
        }

        private void ProcessMultiplication(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Multiplication)
            {
                throw new ArgumentException(
                    "Tried to call ProcessMultiplication() with instruction with opcode which is not multiplication",
                    nameof(instruction));
            }

            Memory[instruction.Parameters[2].Value] = GetParameterValue(instruction.Parameters[0]) *
                                                      GetParameterValue(instruction.Parameters[1]);
        }

        private void ProcessInput(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Input)
            {
                throw new ArgumentException(
                    "Tried to call ProcessInput() with instruction with opcode which is not input",
                    nameof(instruction));
            }

            Memory[instruction.Parameters[0].Value] = GetInput();
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
                InstructionPointer = GetParameterValue(instruction.Parameters[1]);
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
                InstructionPointer = GetParameterValue(instruction.Parameters[1]);
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

            Memory[instruction.Parameters[2].Value] =
                GetParameterValue(instruction.Parameters[0]) < GetParameterValue(instruction.Parameters[1]) ? 1 : 0;
        }

        private void ProcessEquals(Instruction instruction)
        {
            if (instruction.Opcode != Opcode.Equals)
            {
                throw new ArgumentException(
                    "Tried to call ProcessEquals() with instruction with opcode which is not equals",
                    nameof(instruction));
            }

            Memory[instruction.Parameters[2].Value] =
                GetParameterValue(instruction.Parameters[0]) == GetParameterValue(instruction.Parameters[1]) ? 1 : 0;
        }

        private int GetParameterValue(Parameter parameter)
        {
            switch (parameter.Mode)
            {
                case ParameterMode.Position:
                    return Memory[parameter.Value];
                case ParameterMode.Immediate:
                    return parameter.Value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
