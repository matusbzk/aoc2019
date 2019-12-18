namespace AdventOfCode2019.Common.Intcode
{
    /// <summary>
    /// Mode of the parameter.
    /// </summary>
    public enum ParameterMode
    {
        /// <summary>
        /// Number represents position in memory where value is stored.
        /// </summary>
        Position = 0,

        /// <summary>
        /// Number represents value itself.
        /// </summary>
        Immediate = 1,

        /// <summary>
        /// Similar as position but position in memory is calculated from relative base
        /// </summary>
        Relative = 2
    }
}
