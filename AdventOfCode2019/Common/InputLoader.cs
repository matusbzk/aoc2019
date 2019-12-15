using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Common
{
    /// <summary>
    /// Used for loading input.
    /// Expecting all input be in file 'input.txt' in corresponding folder in AdventOfCode2019 project
    /// </summary>
    public static class InputLoader
    {
        /// <summary>
        /// Loads one line of input as string
        /// </summary>
        /// <param name="day">Day</param>
        /// <returns>Input as string</returns>
        public static string LoadText(int day)
        {
            return File.ReadAllText(GetPath(day));
        }

        /// <summary>
        /// Loads each line of input as string
        /// </summary>
        /// <param name="day">Day</param>
        /// <returns>Each line of input as string</returns>
        public static IEnumerable<string> LoadLines(int day)
        {
            return File.ReadLines(GetPath(day));
        }

        /// <summary>
        /// Loads each line of input as int
        /// </summary>
        /// <param name="day">Day</param>
        /// <returns>Each line of input as int</returns>
        public static IEnumerable<int> LoadIntegerLines(int day)
        {
            return LoadLines(day).Select(l => Convert.ToInt32(l));
        }

        /// <summary>
        /// Loads integers separated by comma
        /// </summary>
        /// <param name="day">Day</param>
        /// <returns>Integers</returns>
        public static IEnumerable<int> LoadIntegersSeparatedByComma(int day) =>
            LoadText(day).Split(',').Select(v => Convert.ToInt32(v));

        private static string GetPath(int day) => $@"../../../AdventOfCode2019/Day{day:D2}/input.txt";
    }
}
