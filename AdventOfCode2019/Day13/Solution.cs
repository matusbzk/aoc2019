using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day13
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly IEnumerable<long> _input;

        public Solution()
        {
            _input = InputLoader.LoadLongIntegersSeparatedByComma(13);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var arcade = new Arcade(_input, 1);
            arcade.RunUntilHalt();
            return arcade.Map.Count(a => a.Value == Tile.Block);
        }

        /// <inheritdoc />
        public object Part2()
        {
            var arcade = new Arcade(_input, 2);
            arcade.RunUntilHalt();
            if (arcade.Map.Count(a => a.Value == Tile.Block) > 0)
            {
                throw new ArgumentException("Failed to win the game.");
            }
            return arcade.Score;
        }
    }
}
