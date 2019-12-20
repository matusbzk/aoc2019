using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day03
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly Wires _wires;

        public Solution()
        {
            var input = InputLoader.LoadLines(3).ToArray();
            _wires = new Wires(new Wire(input[0]), new Wire(input[1]));
        }

        /// <inheritdoc />
        public object Part1() => _wires.GetClosestIntersection().GetDistance();

        /// <inheritdoc />
        public object Part2() => _wires.GetFastestIntersection().Order;
    }
}
