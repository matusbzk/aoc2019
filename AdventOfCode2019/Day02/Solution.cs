using System;
using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day02
{
    /// <summary>
    /// Solution for day 2
    /// </summary>
    public class Solution : ISolution
    {
        private readonly IEnumerable<int> _input;

        public Solution()
        {
            _input = InputLoader.LoadIntegersSeparatedByComma(2);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var gap = new GravityAssistProgram(_input, 12, 2);
            gap.RunUntilHalt();
            return gap.Memory[0];
        }

        /// <inheritdoc />
        /// <remarks>Simple brute force solution but it is enough</remarks>
        public object Part2()
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var gap = new GravityAssistProgram(_input, noun, verb);
                    gap.RunUntilHalt();
                    if (gap.Memory[0] == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new Exception("No correct result found");
        }
    }
}
