using System;

namespace AdventOfCode2019.Common.Geometry
{
    /// <summary>
    /// Extension methods for <see cref="CardinalDirection"/>
    /// </summary>
    static class CardinalDirectionExtension
    {
        public static CardinalDirection TurnRight(this CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    return CardinalDirection.East;
                case CardinalDirection.South:
                    return CardinalDirection.West;
                case CardinalDirection.West:
                    return CardinalDirection.North;
                case CardinalDirection.East:
                    return CardinalDirection.South;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
