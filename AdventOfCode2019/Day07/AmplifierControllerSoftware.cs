using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day07
{
    /// <summary>
    /// Amplifier Controller Software
    /// </summary>
    public class AmplifierControllerSoftware
    {
        public IList<Amplifier> Amplifiers { get; set; }

        public AmplifierControllerSoftware(IEnumerable<long> integers, IEnumerable<int> phaseSettings)
        {
            var phasesArray = phaseSettings as int[] ?? phaseSettings.ToArray();
            var integersArray = integers as long[] ?? integers.ToArray();
            if (phasesArray.Any(phase => phasesArray.Count(p => p == phase) > 1))
            {
                throw new ArgumentException("Each phase can be only used once");
            }

            Amplifiers = new List<Amplifier>();
            foreach (var phaseSetting in phasesArray)
            {
                Amplifiers.Add(new Amplifier(integersArray, phaseSetting));
            }

            Amplifiers.First().Input = 0;
        }

        /// <summary>
        /// Runs all amplifiers and returns output of last amplifier.
        /// </summary>
        /// <returns>Output of last amplifier</returns>
        public long GetThrusterSignal()
        {
            for (var i = 0; i < Amplifiers.Count; i++)
            {
                Amplifiers[i].RunUntilHalt();
                if (i < Amplifiers.Count - 1)
                {
                    Amplifiers[i + 1].Input = Amplifiers[i].Output ??
                                              throw new InvalidOperationException(
                                                  $"Amplifier {i} halted and has not returned any output for next amplifier");
                }
            }

            return Amplifiers.Last().Output ??
                   throw new InvalidOperationException("Last amplifier did not return any output");
        }

        /// <summary>
        /// Runs each amplifier until it produces output and then moves to next one.
        /// Loops them until they all stop. Then the last amplifier produces result.
        /// </summary>
        /// <returns>Result outputted by last amplifier after its last run</returns>
        public long GetFeedbackLoopThrusterSignal()
        {
            while (true)
            {
                for (var i = 0; i < Amplifiers.Count; i++)
                {
                    Amplifiers[i].RunUntilOutput();
                    if (i < Amplifiers.Count - 1)
                    {
                        Amplifiers[i + 1].Input = Amplifiers[i].Output ??
                                                  throw new InvalidOperationException(
                                                      $"Amplifier {i} halted and has not returned any output for next amplifier");
                    }
                    else
                    {
                        if (Amplifiers[i].IsHalted)
                        {
                            return Amplifiers[i].Output ??
                                   throw new InvalidOperationException(
                                       "Last amplifier does not have output value even though it should have it");
                        }

                        Amplifiers[0].Input = Amplifiers[i].Output ??
                                              throw new InvalidOperationException(
                                                  $"Amplifier {i} halted and has not returned any output for next amplifier");
                    }
                }
            }
        }
    }
}
