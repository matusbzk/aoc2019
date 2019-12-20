using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day10
{
    /// <summary>
    /// Asteroid
    /// </summary>
    public class Asteroid
    {
        /// <summary>
        /// Asteroid's position
        /// </summary>
        public Position Position { get; set; }

        public Asteroid(int x, int y)
        {
            Position = new Position(x, y);
        }
    }
}
