using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day04
{
    public class Solution : ISolution
    {
        private int _min = 231832;
        private int _max = 767346;

        public object Part1()
        {
            return PasswordValidator.GetAllValidPasswordsWithinRange(_min, _max).Count();
        }

        public object Part2()
        {
            return PasswordValidator.GetAllAdjustedValidPasswordsWithinRange(_min, _max).Count();
        }
    }
}
