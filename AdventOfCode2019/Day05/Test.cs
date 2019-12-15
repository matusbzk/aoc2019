using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day05
{
    /// <summary>
    /// The Thermal Environment Supervision Terminal
    /// </summary>
    public class Test : IntcodeProgram
    {
        public int Diagnostics { get; set; }

        public Test(IEnumerable<int> integers) : base(integers)
        {
        }

        /// <inheritdoc />
        protected override void DoOutput(int value)
        {
            Diagnostics = value;
        }
    }
}
