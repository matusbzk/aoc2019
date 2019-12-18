using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day05
{
    /// <summary>
    /// The Thermal Environment Supervision Terminal
    /// </summary>
    public class Test : IntcodeProgram
    {
        public long Input { get; set; }
        public long Diagnostics { get; set; }

        public Test(IEnumerable<long> integers, long input) : base(integers)
        {
            Input = input;
        }

        /// <inheritdoc />
        /// <remarks>Always provides same input</remarks>
        protected override long GetInput()
        {
            return Input;
        }

        /// <inheritdoc />
        protected override void DoOutput(long value)
        {
            Diagnostics = value;
        }
    }
}
