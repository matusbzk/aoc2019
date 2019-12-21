namespace AdventOfCode2019.Day13
{
    /// <summary>
    /// Tile of arcade game
    /// </summary>
    public enum Tile
    {
        /// <summary>
        /// No game object appears in this tile.
        /// </summary>
        Empty,

        /// <summary>
        /// Walls are indestructible barriers.
        /// </summary>
        Wall,

        /// <summary>
        /// Blocks can be broken by the ball.
        /// </summary>
        Block,

        /// <summary>
        /// The paddle is indestructible.
        /// </summary>
        HorizontalPaddle,

        /// <summary>
        /// The ball moves diagonally and bounces off objects.
        /// </summary>
        Ball
    }
}
