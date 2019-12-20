using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day01
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly IEnumerable<int> _input;

        public Solution()
        {
            _input = InputLoader.LoadIntegerLines(1);
        }

        /// <inheritdoc />
        public object Part1() => FuelRequirementCalculator.GetFuelRequiredForAll(_input);

        /// <inheritdoc />
        public object Part2() => FuelRequirementCalculator.GetTotalFuelRequiredForAll(_input);
    }
}
