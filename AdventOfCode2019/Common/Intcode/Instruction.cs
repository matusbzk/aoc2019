using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Common.Intcode
{
    public class Instruction
    {
        public Opcode Opcode { get; set; }

        public IList<Parameter> Parameters { get; set; } = new List<Parameter>();

        public int ParametersCount { get; set; }

        /// <summary>
        /// Assigns opcode based on value in memory.
        /// </summary>
        /// <param name="memory">Opcode</param>
        public void AssignOpcode(int memory)
        {
            Opcode = (Opcode)(memory % 100);
            ParametersCount = Opcode switch
            {
                Opcode.Addition => 3,
                Opcode.Multiplication => 3,
                Opcode.Input => 1,
                Opcode.Output => 1,
                Opcode.JumpIfTrue => 2,
                Opcode.JumpIfFalse => 2,
                Opcode.LessThan => 3,
                Opcode.Equals => 3,
                Opcode.AdjustRelativeBase => 1,
                Opcode.Halt => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(Opcode))
            };
        }

        /// <summary>
        /// Adds parameter to instruction.
        /// </summary>
        /// <param name="memory">First value of instruction</param>
        /// <param name="parameter">Value of this parameter</param>
        public void AddParameter(int memory, long parameter)
        {
            if (Parameters.Count > ParametersCount)
            {
                throw new InvalidOperationException("Cannot add another parameter to instruction");
            }

            var count = Parameters.Count;

            Parameters.Add(new Parameter
            {
                Value = parameter,
                Mode = (ParameterMode) (memory % (1000 * Math.Pow(10, count)) / (100 * Math.Pow(10, count)))
            });
        }
    }
}
