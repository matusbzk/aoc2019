using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day02
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
                DoOpcode();
            }
        }

        /// <summary>
        /// Perform next opcode
        /// </summary>
        public void DoOpcode()
        {
            if (IsHalted)
            {
                throw new InvalidOperationException("Cannot do Opcode because program is already halted");
            }

            Opcode opcode = (Opcode) Memory[Position];
            switch (opcode)
            {
                case Opcode.Addition:
                    ProcessAddition();
                    break;
                case Opcode.Multiplication:
                    ProcessMultiplication();
                    break;
                case Opcode.Halt:
                    IsHalted = true;
                    break;

            }
        }

        private void ProcessAddition()
        {
            Memory[Memory[Position + 3]] = Memory[Memory[Position + 1]] + Memory[Memory[Position + 2]];
            Position += 4;
        }

        private void ProcessMultiplication()
        {
            Memory[Memory[Position + 3]] = Memory[Memory[Position + 1]] * Memory[Memory[Position + 2]];
            Position += 4;
        }
    }
}
