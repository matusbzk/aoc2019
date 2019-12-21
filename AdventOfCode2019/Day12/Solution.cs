using System;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day12
{
    public class Solution : ISolution
    {
        private MoonSystem _moonSystem;

        public Solution()
        {
            _moonSystem = Day12InputLoader.LoadDay12Input();
        }

        public object Part1()
        {
            _moonSystem.PerformTimeStep(1000);
            return _moonSystem.GetTotalEnergy();
        }

        public object Part2()
        {
            throw new NotImplementedException();
        }
    }
}
