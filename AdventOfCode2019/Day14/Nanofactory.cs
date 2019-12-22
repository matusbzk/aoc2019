using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day14
{
    /// <summary>
    /// Responsible for computing reactions
    /// </summary>
    /// <remarks>This is very ugly and could probably elegantly implemented
    /// as either some graph or mathematics algorithm.</remarks>
    public class Nanofactory
    {
        /// <summary>
        /// List of reactions
        /// </summary>
        public IEnumerable<Reaction> Reactions { get; set; }

        /// <summary>
        /// Number of Ore collected
        /// </summary>
        public long OreCollected { get; set; }

        /// <summary>
        /// Number of fuel produced
        /// </summary>
        public long FuelProduced { get; set; }

        /// <summary>
        /// Not all ingredients created are necessarily used. We save leftover ingredients here.
        /// </summary>
        public IList<Ingredient> LeftoverIngredients { get; set; } = new List<Ingredient>();

        /// <summary>
        /// How much Ore is needed for one fuel, without using any leftovers.
        /// Set in the beginning, used for faster computation of part 2.
        /// </summary>
        public long? OreForOneFuel { get; set; }

        public Nanofactory(IEnumerable<Reaction> reactions)
        {
            Reactions = reactions;
        }

        /// <summary>
        /// Collects number of FUEL with minimum Ore collects
        /// </summary>
        /// <param name="count">How many fuels I want</param>
        public void CollectFuel(int count = 1)
        {
            // I want to have OreForOneFuel value set correctly, so if it's not, I call it with count 1 first
            if (!OreForOneFuel.HasValue)
            {
                CollectFuel();
                count--;
            }

            var needed = new List<Ingredient> {new Ingredient(count, new Chemical("FUEL"))};

            while (needed.Any())
            {
                var ingredientNeeded = needed.First();
                var reaction = Reactions.First(r => Equals(r.Output.Chemical, ingredientNeeded.Chemical));
                var countEquationNeeded = (long) Math.Ceiling((decimal) ingredientNeeded.Count / reaction.Output.Count);

                // if there are some leftovers, save them to 'leftover'
                var leftoverCount = countEquationNeeded * reaction.Output.Count - ingredientNeeded.Count;
                if (leftoverCount > 0)
                {
                    var ingredientLeftover = LeftoverIngredients.FirstOrDefault(i => Equals(i.Chemical, ingredientNeeded.Chemical));
                    if (ingredientLeftover != null)
                    {
                        ingredientLeftover.Count += leftoverCount;
                    }

                    LeftoverIngredients.Add(new Ingredient(leftoverCount, ingredientNeeded.Chemical));
                }

                // remove this ingredient from 'needed' and add all input to 'needed'
                needed.Remove(ingredientNeeded);
                foreach (var input in reaction.Inputs)
                {
                    if (input.Chemical.IsOre())
                    {
                        OreCollected += input.Count * countEquationNeeded;
                    }
                    else
                    {
                        var countNeeded = input.Count * countEquationNeeded;
                        var ingredientLeftover = LeftoverIngredients.FirstOrDefault(i => Equals(i.Chemical, input.Chemical));
                        if (ingredientLeftover != null)
                        {
                            if (ingredientLeftover.Count > countNeeded)
                            {
                                ingredientLeftover.Count -= countNeeded;
                                continue;
                            }

                            countNeeded -= ingredientLeftover.Count;
                            LeftoverIngredients.Remove(ingredientLeftover);
                        }

                        var existingNeeded = needed.FirstOrDefault(i => Equals(i.Chemical, input.Chemical));
                        if (existingNeeded != null)
                        {
                            existingNeeded.Count += countNeeded;
                        }
                        else
                        {
                            needed.Add(new Ingredient(countNeeded, input.Chemical));
                        }
                    }
                }
            }

            FuelProduced += count;
            if (!OreForOneFuel.HasValue)
            {
                OreForOneFuel = OreCollected;
            }
        }

        /// <summary>
        /// Use trillion Ore to get as much Fuel as possible
        /// </summary>
        /// <remarks>This sets this structure into invalid state.</remarks>
        public void UseTrillionOre()
        {
            if (!OreForOneFuel.HasValue)
            {
                CollectFuel();
            }

            var count = 1;
            while (count > 0)
            {
                count = (int)Math.Floor((decimal)(1000000000000 - OreCollected) / OreForOneFuel.Value);
                CollectFuel(count);
            }

            while (OreCollected <= 1000000000000)
            {
                CollectFuel();
            }

            FuelProduced--;
        }
    }
}
