using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Common.Intcode
{
    /// <summary>
    /// Represents Intcode program
    /// </summary>
    public class IntcodeProgram
    {
        /// <summary>
        /// 
        /// </summary>
        public int[] Memory { get; set; }

        /// <summary>
        /// Current position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Has program halted
        /// </summary>
        public bool IsHalted { get; set; }

        public IntcodeProgram(IEnumerable<int> integers)
        {
            Memory = integers.ToArray();
            Position = 0;
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
            instruction.AssignOpcode(Memory[Position]);
            for (var i = 0; i < instruction.ParametersCount; i++)
            {
                instruction.AddParameter(Memory[Position], Memory[Position + i + 1]);
            }

            ProcessInstruction(instruction); 
        }

        /// <summary>
        /// Gets data from input
        /// </summary>
        /// <returns>Data from input</returns>
        protected virtual int GetInput()
        {
            Console.Write("Enter input: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Outputs data
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
                case Opcode.Halt:
                    IsHalted = true;
                    break;

            }

            Position += instruction.ParametersCount + 1;
        }

        private void ProcessAddition(Instruction instruction)
        {

            Memory[instruction.Parameters[2].Value] = GetParameterValue(instruction.Parameters[0]) + GetParameterValue(instruction.Parameters[1]);
        }

        private void ProcessMultiplication(Instruction instruction)
        {
            Memory[instruction.Parameters[2].Value] = GetParameterValue(instruction.Parameters[0]) * GetParameterValue(instruction.Parameters[1]);
        }

        private void ProcessInput(Instruction instruction)
        {
            Memory[instruction.Parameters[0].Value] = GetInput();
        }

        private void ProcessOutput(Instruction instruction)
        {
            DoOutput(GetParameterValue(instruction.Parameters[0]));
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
