using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day06
{
    /// <summary>
    /// Solution for day 6
    /// </summary>
    public class Solution : ISolution
    {
        private readonly Map _map = Day06InputLoader.LoadDay06Input();

        /// <inheritdoc />
        public object Part1()
        {
            return _map.NumberOfOrbits();
        }

        /// <inheritdoc />
        public object Part2()
        {
            return _map.OrbitalTransfersToSanta();
        }
    }
}
