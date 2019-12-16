using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day07
{
    /// <summary>
    /// Solution for day 7
    /// </summary>
    public class Solution : ISolution
    {
        private readonly IEnumerable<int> _input;

        public Solution()
        {
            _input = InputLoader.LoadIntegersSeparatedByComma(7);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var acsSimulator = new AcsSimulator(_input, new[] {0, 1, 2, 3, 4});
            return acsSimulator.GetMaxThrusterSignal();
        }

        /// <inheritdoc />
        public object Part2()
        {
            var acsSimulator = new AcsSimulator(_input, new[] {5, 6, 7, 8, 9});
            return acsSimulator.GetMaxFeedbackLoopThrusterSignal();
        }
    }
}
