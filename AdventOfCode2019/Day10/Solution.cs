using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day10
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly Map _map;

        public Solution()
        {
            var input = InputLoader.LoadLines(10);
            _map = new Map(input);
        }

        /// <inheritdoc />
        public object Part1() => _map.HowManyAsteroidsCanBestAsteroidDetect();

        /// <inheritdoc />
        public object Part2()
        {
            var asteroid = _map.GetNthVaporized(200);
            return asteroid.Position.X * 100 + asteroid.Position.Y;
        }
    }
}
