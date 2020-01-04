using System;
using System.Collections.Generic;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day03
{
    /// <summary>
    /// Represents an instruction
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// Direction
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Distance
        /// </summary>
        public int Distance { get; set; }

        public Instruction(string instructionStr)
        {
            Direction = instructionStr[0] switch
            {
                'U' => Direction.Up,
                'D' => Direction.Down,
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new ArgumentException($"Cannot get direction from string '{instructionStr}'")
            };

            Distance = Convert.ToInt32(instructionStr.Substring(1));
        }

        /// <summary>
        /// Applies instruction on given position
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>All positions encountered by this instruction</returns>
        public IEnumerable<OrderedPosition> Apply(OrderedPosition position)
        {
            var result = new List<OrderedPosition>();

            var action = Direction switch
            {
                Direction.Up => (Action) (() => position.Y++),
                Direction.Down => (() => position.Y--),
                Direction.Right => (() => position.X++),
                Direction.Left => (() => position.X--),
                _ => throw new ArgumentOutOfRangeException(nameof(Direction))
            };
            for (var i = 0; i < Distance; i++)
            {
                action.Invoke();
                position.Order++;
                result.Add(new OrderedPosition(position.X, position.Y, position.Order));
            }

            return result;
        }

        protected bool Equals(Instruction other)
        {
            return Direction == other.Direction && Distance == other.Distance;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Instruction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Direction * 397) ^ Distance;
            }
        }
    }
}
