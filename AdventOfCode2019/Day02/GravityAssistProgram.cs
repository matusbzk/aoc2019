using System.Collections.Generic;

namespace AdventOfCode2019.Day02
{
    /// <summary>
    /// Gravity assist program makes small changes in the beginning
    /// </summary>
    public class GravityAssistProgram : IntcodeProgram
    {
        public GravityAssistProgram(IEnumerable<int> integers, int noun, int verb) : base(integers)
        {
            Memory[1] = noun;
            Memory[2] = verb;
        }
    }
}
