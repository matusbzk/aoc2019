using System;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day12
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        /// <inheritdoc />
        public object Part1()
        {
            var moonSystem = Day12InputLoader.LoadDay12Input();
            moonSystem.PerformTimeStep(1000);
            return moonSystem.GetTotalEnergy();
        }

        /// <inheritdoc />
        /// <remarks>This will require much more effective solution. I don't want
        /// to Google it and I don't feel like thinking about it right now so
        /// I'll get to this later.</remarks>
        public object Part2()
        {
            var moonSystem = Day12InputLoader.LoadDay12Input();
            moonSystem.SimulateUntilPreviousStateEncounter();
            return moonSystem.StepsPerformed;
        }
    }
}
