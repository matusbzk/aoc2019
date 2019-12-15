using System;
using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day05
{
    public class Solution : ISolution
    {
        private readonly IEnumerable<int> _input;

        public Solution()
        {
            _input = InputLoader.LoadIntegersSeparatedByComma(5);
        }

        public object Part1()
        {
            var test = new Test(_input);
            test.RunUntilHalt();
            return test.Diagnostics;
        }

        public object Part2()
        {
            throw new NotImplementedException();
        }
    }
}
