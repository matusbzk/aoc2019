namespace AdventOfCode2019.Day15
{
    /// <summary>
    /// The repair droid can reply with any of the following status codes
    /// </summary>
    public enum DroidStatusCode
    {
        /// <summary>
        /// The repair droid hit a wall. Its position has not changed.
        /// </summary>
        Wall,

        /// <summary>
        /// The repair droid has moved one step in the requested direction.
        /// </summary>
        Moved,

        /// <summary>
        /// The repair droid has moved one step in the requested direction;
        /// its new position is the location of the oxygen system.
        /// </summary>
        OxygenSystem
    }
}
