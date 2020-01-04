using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common.Geometry;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day11
{
    /// <summary>
    /// Emergency hull painting robot
    /// </summary>
    public class EmergencyHullPaintingRobot : IntcodeProgram
    {
        public IList<ShipPosition> Map { get; set; } = new List<ShipPosition>();

        /// <summary>
        /// Position of robot
        /// </summary>
        public ShipPosition Position { get; set; }

        /// <summary>
        /// Direction the robot is facing
        /// </summary>
        public Direction Direction { get; set; } = Direction.Up;

        public int InputsDone { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="integers">Intcode</param>
        /// <param name="startingColor">Color of panel where robot is starting</param>
        public EmergencyHullPaintingRobot(IEnumerable<long> integers, Color startingColor) : base(integers)
        {
            Position = new ShipPosition {Color = startingColor};
            Map.Add(Position);
        }

        /// <summary>
        /// Returns number of panels that have been painted at least once
        /// </summary>
        /// <returns></returns>
        public int PaintedPanelsCount() => Map.Count(p => p.HasBeenPainted);

        /// <summary>
        /// Returns current state of map
        /// </summary>
        public string PrintedMap()
        {
            var result = "";
            for (var y = Map.Min(p => p.Y); y <= Map.Max(p => p.Y); y++)
            {
                for (var x = Map.Min(p => p.X); x <= Map.Max(p => p.X); x++)
                {
                    result += (Map.FirstOrDefault(p => p.X == x && p.Y == y)?.Color ?? Color.Black) == Color.Black
                        ? "."
                        : "#";
                }

                result += "\n";
            }

            return result;
        }

        /// <summary>
        /// For testing purposes, performs input
        /// </summary>
        /// <returns>Input value</returns>
        public long TriggerInput() => GetInput();

        /// <summary>
        /// For testing purposes, performs output
        /// </summary>
        /// <param name="value">value to output</param>
        public void TriggerOutput(long value) => DoOutput(value);

        /// <inheritdoc />
        protected override long GetInput() => (long) Position.Color;

        /// <inheritdoc />
        protected override void DoOutput(long value)
        {
            if (InputsDone % 2 == 0)
            {
                Position.Color = (Color) value;
                Position.HasBeenPainted = true;
            }
            else
            {
                Direction = (Color) value switch
                {
                    Color.Black => (Direction switch
                    {
                        Direction.Up => Direction.Left,
                        Direction.Down => Direction.Right,
                        Direction.Left => Direction.Down,
                        Direction.Right => Direction.Up,
                        _ => throw new ArgumentOutOfRangeException(nameof(Direction))
                    }),
                    Color.White => (Direction switch
                    {
                        Direction.Up => Direction.Right,
                        Direction.Down => Direction.Left,
                        Direction.Left => Direction.Up,
                        Direction.Right => Direction.Down,
                        _ => throw new ArgumentOutOfRangeException(nameof(Direction))
                    }),
                    _ => throw new ArgumentOutOfRangeException(nameof(value))
                };
                MoveRobot();
            }

            InputsDone++;
        }

        private void MoveRobot()
        {
            var newPosition = Direction switch
            {
                Direction.Up => new ShipPosition(Position.X, Position.Y - 1),
                Direction.Down => new ShipPosition(Position.X, Position.Y + 1),
                Direction.Left => new ShipPosition(Position.X - 1, Position.Y),
                Direction.Right => new ShipPosition(Position.X + 1, Position.Y),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (!Map.Any(p => p.X == newPosition.X && p.Y == newPosition.Y))
            {
                Map.Add(newPosition);
            }

            Position = Map.First(p => p.X == newPosition.X && p.Y == newPosition.Y);
        }
    }
}
