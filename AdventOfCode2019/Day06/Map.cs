using System.Linq;
using AdventOfCode2019.Common.Structures;

namespace AdventOfCode2019.Day06
{
    public class Map : RootedForest<Object>
    {
        public int NumberOfOrbits() => Roots.Sum(c => c.NumberOfOrbits());

        public Object You { get; set; }

        public Object Santa { get; set; }

        /// <summary>
        /// How many orbital transfers do you have to make to get to Santa
        /// </summary>
        /// <returns>How many orbital transfers do you have to make to get to Santa</returns>
        public int? OrbitalTransfersToSanta() => DistanceBetweenObjects(You, Santa);

        /// <summary>
        /// Returns forest in string form
        /// </summary>
        /// <returns></returns>
        public string Stringified()
        {
            var result = "";
            foreach (var root in Roots)
            {
                result += root.Stringified();
            }

            return result;
        }
    }
}
