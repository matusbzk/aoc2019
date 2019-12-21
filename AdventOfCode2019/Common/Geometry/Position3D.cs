namespace AdventOfCode2019.Common.Geometry
{
    /// <summary>
    /// Represents position in 3D space
    /// </summary>
    public class Position3D : Position
    {
        /// <summary>
        /// Z axis
        /// </summary>
        public int Z { get; set; }

        public Position3D(int x = 0, int y = 0, int z = 0) : base(x, y)
        {
            Z = z;
        }

        public static Position3D operator +(Position3D position, Position3D other) =>
            new Position3D(position.X + other.X, position.Y + other.Y, position.Z + other.Z);

        public override string ToString() => $"({X},{Y},{Z})";
    }
}
