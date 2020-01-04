using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day04
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private const int Min = 231832;
        private const int Max = 767346;

        /// <inheritdoc />
        public object Part1() => PasswordValidator.GetAllValidPasswordsWithinRange(Min, Max).Count();

        /// <inheritdoc />
        public object Part2() => PasswordValidator.GetAllAdjustedValidPasswordsWithinRange(Min, Max).Count();
    }
}
