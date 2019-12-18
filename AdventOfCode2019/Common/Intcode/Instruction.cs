using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (Opcode)
            {
                case Opcode.Addition:
                    ParametersCount = 3;
                    break;
                case Opcode.Multiplication:
                    ParametersCount = 3;
                    break;
                case Opcode.Input:
                    ParametersCount = 1;
                    break;
                case Opcode.Output:
                    ParametersCount = 1;
                    break;
                case Opcode.JumpIfTrue:
                    ParametersCount = 2;
                    break;
                case Opcode.JumpIfFalse:
                    ParametersCount = 2;
                    break;
                case Opcode.LessThan:
                    ParametersCount = 3;
                    break;
                case Opcode.Equals:
                    ParametersCount = 3;
                    break;
                case Opcode.AdjustRelativeBase:
                    ParametersCount = 1;
                    break;
                case Opcode.Halt:
                    ParametersCount = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Opcode));
            }
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
