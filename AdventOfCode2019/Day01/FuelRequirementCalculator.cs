using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    /// <summary>
    /// Calculates fuel requirements
    /// </summary>
    public static class FuelRequirementCalculator
    {
        /// <summary>
        /// Gets fuel required for given mass. Does not take fuel mass into account.
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel required for given mass</returns>
        public static int GetFuelRequired(int mass)
        {
            return Convert.ToInt32(Math.Floor(((decimal) mass / 3))) - 2;
        }

        /// <summary>
        /// Gets fuel required for set of masses. Does not take fuel mass into account.
        /// </summary>
        /// <param name="masses">Masses</param>
        /// <returns>Fuel required for set of masses</returns>
        public static int GetFuelRequiredForAll(IEnumerable<int> masses) => masses.Select(GetFuelRequired).Sum();

        /// <summary>
        /// Gets fuel required for given mass. Does take fuel mass into account.
        /// </summary>
        /// <param name="mass">Mass</param>
        /// <returns>Fuel required for given mass</returns>
        public static int GetTotalFuelRequired(int mass)
        {
            var result = 0;
            var added = GetFuelRequired(mass);
            while (added > 0)
            {
                result += added;
                added = GetFuelRequired(added);
            }

            return result;
        }

        /// <summary>
        /// Gets fuel required for set of masses. Does take fuel mass into account.
        /// </summary>
        /// <param name="masses">Masses</param>
        /// <returns>Fuel required for set of masses</returns>
        public static int GetTotalFuelRequiredForAll(IEnumerable<int> masses) => masses.Select(GetTotalFuelRequired).Sum();
    }
}
