using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day07
{
    /// <summary>
    /// Simulates Amplifier Controller Software and tries to find the best phase settings for it
    /// </summary>
    public class AcsSimulator
    {
        /// <summary>
        /// Amplifiers code
        /// </summary>
        public IEnumerable<long> Integers { get; set; }

        /// <summary>
        /// Which integers can be used as valid phases
        /// </summary>
        public IEnumerable<int> ValidPhases { get; }

        public AcsSimulator(IEnumerable<long> integers, IEnumerable<int> validPhases)
        {
            Integers = integers;
            ValidPhases = validPhases;
        }

        /// <summary>
        /// What is the highest signal that can be sent to the thrusters?
        /// </summary>
        /// <returns>The highest signal that can be sent to the thrusters</returns>
        public long GetMaxThrusterSignal()
        {
            var max = long.MinValue;
            foreach (var a in ValidPhases)
            foreach (var b in ValidPhases)
                {
                if (a == b)
                {
                    continue;
                }

                foreach (var c in ValidPhases)
                    {
                    if (a == c || b == c)
                    {
                        continue;
                    }

                    foreach (var d in ValidPhases)
                        {
                        if (a == d || b == d || c == d)
                        {
                            continue;
                        }

                        foreach (var e in ValidPhases)
                            {
                            if (a == e || b == e || c == e || d == e)
                            {
                                continue;
                            }

                            var acs = new AmplifierControllerSoftware(Integers, new[] { a, b, c, d, e });
                            var signal = acs.GetThrusterSignal();
                            if (signal > max)
                            {
                                max = signal;
                            }
                        }
                    }
                }
            }
            
            return max;
        }

        /// <summary>
        /// What is the highest signal that can be sent to the thrusters?
        /// </summary>
        /// <returns>The highest signal that can be sent to the thrusters</returns>
        /// <remarks>This is the same method as GetMaxThrusterSignal() except it
        /// uses GetFeedbackLoopThrusterSignal() instead of GetThrusterSignal().
        /// The only difference is that it is (automatically) converted to Linq
        /// expression.
        /// Normally I would create other method that would take a method as
        /// an argument and do all this stuff to reduce code duplication.
        /// I left it as you see it because it fascinates my how Linq could
        /// make this method shorter (and basically unreadable to human).</remarks>
        public long GetMaxFeedbackLoopThrusterSignal() =>
            ValidPhases.Aggregate(long.MinValue, (current3, a) => ValidPhases.Where(b => a != b)
                .Aggregate(current3, (current2, b) => ValidPhases.Where(c => a != c && b != c)
                    .Aggregate(current2, (current1, c) => ValidPhases.Where(d => a != d && b != d && c != d)
                        .Aggregate(current1, (current, d) => (ValidPhases
                                .Where(e => a != e && b != e && c != e && d != e)
                                .Select(e => new AmplifierControllerSoftware(Integers, new[] {a, b, c, d, e}))
                                .Select(acs => acs.GetFeedbackLoopThrusterSignal())).Concat<long>(new[] {current})
                            .Max()))));
    }
}
