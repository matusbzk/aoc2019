using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.CommonTests.Intcode
{
    /// <summary>
    /// Mock intcode program that always puts same value to input and stores last output
    /// </summary>
    public class MockIntcodeProgram : IntcodeProgram
    {
        public int Input { get; set; }
        public int Output { get; set; }

        public MockIntcodeProgram(IEnumerable<int> integers, int input) : base(integers)
        {
            Input = input;
        }

        protected override int GetInput()
        {
            return Input;
        }

        protected override void DoOutput(int value)
        {
            Output = value;
        }
    }
}
