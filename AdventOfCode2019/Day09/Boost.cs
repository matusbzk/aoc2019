using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day09
{
    public class Boost : IntcodeProgram
    {
        public long Input { get; set; }
        public long? Output { get; set; }

        public Boost(IEnumerable<long> integers, long input) : base(integers)
        {
            Input = input;
        }

        protected override long GetInput()
        {
            return Input;
        }

        protected override void DoOutput(long value)
        {
            Output = value;
        }
    }
}
