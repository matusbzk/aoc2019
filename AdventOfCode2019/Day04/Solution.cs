using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day04
{
    /// <summary>
    /// Solution for day 4
    /// </summary>
    public class Solution : ISolution
    {
        private int _min = 231832;
        private int _max = 767346;

        /// <inheritdoc />
        public object Part1()
        {
            return PasswordValidator.GetAllValidPasswordsWithinRange(_min, _max).Count();
        }

        /// <inheritdoc />
        public object Part2()
        {
            return PasswordValidator.GetAllAdjustedValidPasswordsWithinRange(_min, _max).Count();
        }
    }
}
