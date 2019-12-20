using System.Collections.Generic;
using AdventOfCode2019.Common;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day11
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly IEnumerable<long> _input;

        public Solution()
        {
            _input = InputLoader.LoadLongIntegersSeparatedByComma(11);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var robot = new EmergencyHullPaintingRobot(_input, Color.Black);
            robot.RunUntilHalt();
            return robot.PaintedPanelsCount();
        }

        /// <inheritdoc />
        public object Part2()
        {
            var robot = new EmergencyHullPaintingRobot(_input, Color.White);
            robot.RunUntilHalt();
            return $"\n{robot.PrintedMap()}";
        }
    }
}
