using System;

namespace AdventOfCode2019.Common.Geometry
{
    /// <summary>
    /// Extension methods for <see cref="CardinalDirection"/>
    /// </summary>
    public static class CardinalDirectionExtension
    {
        public static CardinalDirection TurnRight(this CardinalDirection direction) =>
            direction switch
            {
                CardinalDirection.North => CardinalDirection.East,
                CardinalDirection.South => CardinalDirection.West,
                CardinalDirection.West => CardinalDirection.North,
                CardinalDirection.East => CardinalDirection.South,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
    }
}
