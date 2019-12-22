using System.Collections.Generic;

namespace AdventOfCode2019.Day14
{
    /// <summary>
    /// Chemical reaction
    /// </summary>
    public class Reaction
    {
        /// <summary>
        /// Inputs of the reaction
        /// </summary>
        public IList<Ingredient> Inputs { get; set; } = new List<Ingredient>();

        /// <summary>
        /// Output of the reaction
        /// </summary>
        public Ingredient Output { get; set; }
    }
}
