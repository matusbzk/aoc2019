﻿using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.CommonTests.Intcode
{
    /// <summary>
    /// Mock intcode program that always puts same value to input and stores last output
    /// </summary>
    public class MockIntcodeProgram : IntcodeProgram
    {
        public long Input { get; set; }
        public long Output { get; set; }

        public MockIntcodeProgram(IEnumerable<long> integers, int input) : base(integers)
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
