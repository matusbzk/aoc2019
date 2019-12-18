using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day09
{
    public class Solution : ISolution
    {
        private readonly IEnumerable<long> _input;

        public Solution()
        {
            _input = InputLoader.LoadLongIntegersSeparatedByComma(9);
        }
        public object Part1()
        {
            var boost = new Boost(_input, 1);
            boost.RunUntilOutput();
            return boost.Output;
        }

        public object Part2()
        {
            var boost = new Boost(_input, 2);
            boost.RunUntilOutput();
            return boost.Output;
        }
    }
}
