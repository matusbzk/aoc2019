namespace AdventOfCode2019.Common.Geometry
{
    /// <summary>
    /// Represents position in 2D space
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }

        public Position(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns Manhattan distance from central port
        /// </summary>
        /// <returns>Distance from central port</returns>
        public int GetDistance() => X + Y;

        public override string ToString() => $"({X},{Y})";

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
