using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day14
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly Nanofactory _nanofactory;

        public Solution()
        {
            _nanofactory = new Nanofactory(Parser.ParseReactions(InputLoader.LoadLines(14)));
        }

        /// <inheritdoc />
        public object Part1()
        {
            _nanofactory.CollectFuel();
            return _nanofactory.OreCollected;
        }

        /// <inheritdoc />
        public object Part2()
        {
            _nanofactory.UseTrillionOre();
            return _nanofactory.FuelProduced;
        }
    }
}
