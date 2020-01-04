using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day15
{
    public class TileInfo
    {
        public Position Position { get; set; }

        public TileType Type { get; set; }

        public TileInfo(Position position, TileType type = TileType.Unknown)
        {
            Position = position;
            Type = type;
        }

        protected bool Equals(TileInfo other)
        {
            return Equals(Position, other.Position) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TileInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Position != null ? Position.GetHashCode() : 0) * 397) ^ (int) Type;
            }
        }
    }
}
