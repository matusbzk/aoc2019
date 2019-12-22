namespace AdventOfCode2019.Day14
{
    /// <summary>
    /// Ingredient is part of chemical reaction.
    /// It consist of a chemical and its count
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Quantity of chemical
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Type of chemical
        /// </summary>
        public Chemical Chemical { get; set; }

        public Ingredient(long count, Chemical chemical)
        {
            Count = count;
            Chemical = chemical;
        }

        /// <inheritdoc />
        public override string ToString() => $"{Count} {Chemical.Name}";
    }
}
