using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day05
{
    /// <summary>
    /// The Thermal Environment Supervision Terminal
    /// </summary>
    public class Test : IntcodeProgram
    {
        public int Input { get; set; }
        public int Diagnostics { get; set; }

        public Test(IEnumerable<int> integers, int input) : base(integers)
        {
            Input = input;
        }

        /// <inheritdoc />
        /// <remarks>Always provides same input</remarks>
        protected override int GetInput()
        {
            return Input;
        }

        /// <inheritdoc />
        protected override void DoOutput(int value)
        {
            Diagnostics = value;
        }
    }
}
