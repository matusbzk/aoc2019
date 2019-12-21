using System.Collections.Generic;
using AdventOfCode2019.Common.Geometry;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day13
{
    /// <summary>
    /// Represents an arcade
    /// </summary>
    public class Arcade : IntcodeProgram
    {
        /// <summary>
        /// Game map
        /// </summary>
        public IDictionary<Position, Tile> Map { get; set; } = new Dictionary<Position, Tile>();

        /// <summary>
        /// Every instruction consists of three outputs. This is used to store first and second output
        /// until the third is loaded.
        /// </summary>
        public IList<int> OutputsLoaded { get; set; } = new List<int>();

        /// <summary>
        /// Player's score
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// X axis of ball
        /// </summary>
        public int? BallPosition { get; set; }

        /// <summary>
        /// X axis of joystick
        /// </summary>
        public int? JoystickPosition { get; set; }

        public Arcade(IEnumerable<long> integers, int quarters) : base(integers)
        {
            Memory[0] = quarters;
        }

        /// <summary>
        /// For testing purposes, performs output
        /// </summary>
        /// <param name="values">values to output</param>
        public void TriggerOutputs(IEnumerable<long> values)
        {
            foreach (var value in values)
            {
                DoOutput(value);
            }
        }

        /// <inheritdoc />
        protected override long GetInput() => ComputeJoystickInstruction();

        /// <inheritdoc />
        protected override void DoOutput(long value)
        {
            if (OutputsLoaded.Count < 2)
            {
                OutputsLoaded.Add((int) value);
            }
            else
            {
                ProcessInstruction(OutputsLoaded[0], OutputsLoaded[1], (int) value);
                OutputsLoaded = new List<int>();
            }
        }

        /// <summary>
        /// Return how to move joystick
        /// </summary>
        /// <returns>1 if joystick should move to right, -1 if to left and 0 if not to move.</returns>
        private int ComputeJoystickInstruction()
        {
            if (BallPosition > JoystickPosition)
            {
                return 1;
            }
            if (BallPosition < JoystickPosition)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Processes instruction.
        /// If first two values are -1 and 0, third value is score.
        /// Otherwise first two values are X and Y coordinates
        /// and third value is type of tile to be set there.
        /// </summary>
        private void ProcessInstruction(int value1, int value2, int value3)
        {
            if (value1 == -1 && value2 == 0)
            {
                Score = value3;
            }
            else
            {
                var tile = (Tile)value3;
                Map[new Position(value1, value2)] = tile;
                switch (tile)
                {
                    case Tile.Ball:
                        BallPosition = value1;
                        break;
                    case Tile.HorizontalPaddle:
                        JoystickPosition = value1;
                        break;
                }
            }
        }
    }
}
