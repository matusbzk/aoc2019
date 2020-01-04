using System;
using System.Collections.Generic;
using System.Threading;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day15
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly IEnumerable<long> _input;

        public Solution()
        {
            _input = InputLoader.LoadLongIntegersSeparatedByComma(15);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var droid = new RepairDroid(_input);

            droid.RunUntilOxygenSystemFoundOrAtMostXCommands(400);
            while (!droid.OxygenSystemFound)
            {
                droid.RunUntilOutput();
                Console.Clear();
                Console.WriteLine(droid.GetPrintableMapState());
                Thread.Sleep(250);
            }
            return $"\n{droid.GetPrintableMapState()}";
        }

        /// <inheritdoc />
        public object Part2()
        {
            throw new NotImplementedException();
        }
    }
}
