using System.Collections.Generic;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day01
{
    /// <summary>
    /// Solution for day 1
    /// </summary>
    public class Solution : ISolution
    {
        private readonly IEnumerable<int> _input;

        public Solution()
        {
            _input = InputLoader.LoadIntegerLines(1);
        }

        /// <inheritdoc />
        public object Part1()
        {
            return FuelRequirementCalculator.GetFuelRequiredForAll(_input);
        }

        /// <inheritdoc />
        public object Part2()
        {
            return FuelRequirementCalculator.GetTotalFuelRequiredForAll(_input);
        }
    }
}
