namespace AdventOfCode2019.Day14
{
    /// <summary>
    /// Represents a chemical
    /// </summary>
    public class Chemical
    {
        /// <summary>
        /// Name of the chemical
        /// </summary>
        public string Name { get; set; }

        public Chemical(string name)
        {
            Name = name;
        }

        /// <summary>
        /// We have unlimited supply of Ore
        /// </summary>
        /// <returns>True if this chemical is Ore</returns>
        public bool IsOre() => Name == "ORE";

        /// <summary>
        /// We want fuel.
        /// </summary>
        /// <returns>True if this chemical is fuel</returns>
        public bool IsFuel() => Name == "FUEL";

        protected bool Equals(Chemical other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Chemical) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
