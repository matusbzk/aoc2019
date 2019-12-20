using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day06
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly Map _map = Day06InputLoader.LoadDay06Input();

        /// <inheritdoc />
        public object Part1() => _map.NumberOfOrbits();

        /// <inheritdoc />
        public object Part2() => _map.OrbitalTransfersToSanta();
    }
}
