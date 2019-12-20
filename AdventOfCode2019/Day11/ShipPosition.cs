using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day11
{
    /// <summary>
    /// Represents position on ship
    /// </summary>
    public class ShipPosition : Position
    {
        /// <summary>
        /// Color of panel
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Has this panel been painted?
        /// </summary>
        public bool HasBeenPainted { get; set; }

        public ShipPosition(int x = 0, int y = 0) : base(x, y)
        {
        }
    }
}
