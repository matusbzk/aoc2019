namespace AdventOfCode2019.Common.Intcode
{
    /// <summary>
    /// Represents parameter of instruction
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Value
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// Mode of this parameter
        /// </summary>
        public ParameterMode Mode { get; set; }
    }
}
