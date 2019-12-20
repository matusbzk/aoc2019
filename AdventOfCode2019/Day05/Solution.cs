using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day05
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly IEnumerable<long> _input;

        public Solution()
        {
            _input = InputLoader.LoadLongIntegersSeparatedByComma(5);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var test = new Test(_input, 1);
            test.RunUntilHalt();
            return test.Diagnostics;
        }

        /// <inheritdoc />
        public object Part2()
        {
            var test = new Test(_input, 5);
            test.RunUntilHalt();
            return test.Diagnostics;
        }
    }
}
