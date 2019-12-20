using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day04
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly int _min = 231832;
        private readonly int _max = 767346;

        /// <inheritdoc />
        public object Part1() => PasswordValidator.GetAllValidPasswordsWithinRange(_min, _max).Count();

        /// <inheritdoc />
        public object Part2() => PasswordValidator.GetAllAdjustedValidPasswordsWithinRange(_min, _max).Count();
    }
}
