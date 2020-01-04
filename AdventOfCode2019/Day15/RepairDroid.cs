using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common.Geometry;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day15
{
    /// <summary>
    /// Repair droid
    /// </summary>
    public class RepairDroid : IntcodeProgram
    {
        /// <summary>
        /// Direction of last command sent to droid
        /// </summary>
        private CardinalDirection _lastCommand = CardinalDirection.North;

        /// <summary>
        /// Map of tiles droid has encountered
        /// </summary>
        public Map Map = new Map();

        /// <summary>
        /// Current position of droid
        /// </summary>
        public Tile CurrentTile { get; set; }

        /// <summary>
        /// Indicates whether oxygen system has been found
        /// </summary>
        public bool OxygenSystemFound { get; set; }

        public Stack<CardinalDirection> PlannedRoute { get; set; } = new Stack<CardinalDirection>();

        public RepairDroid(IEnumerable<long> integers) : base(integers)
        {
            CurrentTile = new Tile(new TileInfo(new Position(), TileType.Empty));
            Map.Add(CurrentTile);
        }

        /// <summary>
        /// Get next movement command
        /// </summary>
        public CardinalDirection GetMovementCommand()
        {
            // If I am on some planned route, I follow it
            if (PlannedRoute.Any())
            {
                _lastCommand = PlannedRoute.Pop();
                return _lastCommand;
            }

            // If some of tiles near me are not known, go there
            if (CurrentTile.North == null)
            {
                _lastCommand = CardinalDirection.North;
                return _lastCommand;
            }
            if (CurrentTile.South == null)
            {
                _lastCommand = CardinalDirection.South;
                return _lastCommand;
            }
            if (CurrentTile.West == null)
            {
                _lastCommand = CardinalDirection.West;
                return _lastCommand;
            }
            if (CurrentTile.East == null)
            {
                _lastCommand = CardinalDirection.East;
                return _lastCommand;
            }

            // Else I find target and set route
            PlannedRoute = CurrentTile.PathToClosestVertexWhich(v => v.DoesDroidNeedToGoHere()).First();
            _lastCommand = PlannedRoute.Pop();
            return _lastCommand;
        }

        /// <summary>
        /// Processes a reply from droid
        /// </summary>
        /// <param name="reply">Droid status code</param>
        public void ProcessDroidReply(DroidStatusCode reply)
        {
            var relevantTile = CurrentTile.Neighbor(_lastCommand);
            if (!Map.Contains(relevantTile))
            {
                Map.Add(relevantTile);
                AddNeighbors(relevantTile);
            }

            switch (reply)
            {
                case DroidStatusCode.Wall:
                    relevantTile.Vertex.Type = TileType.Wall;
                    break;
                case DroidStatusCode.Moved:
                    relevantTile.Vertex.Type = TileType.Empty;
                    CurrentTile = relevantTile;
                    break;
                case DroidStatusCode.OxygenSystem:
                    relevantTile.Vertex.Type = TileType.OxygenSystem;
                    CurrentTile = relevantTile;
                    OxygenSystemFound = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(reply), reply, null);
            }
        }

        /// <summary>
        /// Runs the droid until it finds oxygen system
        /// </summary>
        public void RunUntilOxygenSystemFound()
        {
            while (!OxygenSystemFound)
            {
                RunUntilOutput();
            }
        }

        /// <summary>
        /// Runs the droid until it finds oxygen system
        /// </summary>
        public void RunUntilOxygenSystemFoundOrAtMostXCommands(int x)
        {
            for (var i = 0; i < x; i++)
            {
                if (OxygenSystemFound)
                {
                    return;
                }
                RunUntilOutput();
            }
        }

        /// <summary>
        /// Returns map state in printable string
        /// </summary>
        public string GetPrintableMapState()
        {
            var minX = Map.Vertices.Min(k => k.Vertex.Position.X);
            var maxX = Map.Vertices.Max(k => k.Vertex.Position.X);
            var minY = Map.Vertices.Min(k => k.Vertex.Position.Y);
            var maxY = Map.Vertices.Max(k => k.Vertex.Position.Y);

            var result = "";
            for (var y = maxY + 1; y >= minY; y--)
            {
                for (var x = minX - 1; x <= maxX; x++)
                {
                    result += GetPrintableTile((Tile) Map.FirstOrDefault(v =>
                        v.Vertex.Position.Equals(new Position(x, y))));
                }

                result += "\n";
            }

            return result;
        }

        /// <inheritdoc />
        protected override long GetInput() => (long) GetMovementCommand();

        /// <inheritdoc />
        protected override void DoOutput(long value) => ProcessDroidReply((DroidStatusCode) value);

        /// <summary>
        /// Adds neighbors of tile based on its position
        /// </summary>
        private void AddNeighbors(Tile tile)
        {
            if (tile.North == null)
            {
                tile.North = (Tile) Map.FirstOrDefault(v =>
                    v.Vertex.Position.X == tile.Vertex.Position.X && v.Vertex.Position.Y == tile.Vertex.Position.Y + 1);
                if (tile.North != null)
                {
                    tile.North.South = tile;
                }
            }
            if (tile.South == null)
            {
                tile.South = (Tile)Map.FirstOrDefault(v =>
                    v.Vertex.Position.X == tile.Vertex.Position.X && v.Vertex.Position.Y == tile.Vertex.Position.Y - 1);
                if (tile.South != null)
                {
                    tile.South.North = tile;
                }
            }
            if (tile.West == null)
            {
                tile.West = (Tile)Map.FirstOrDefault(v =>
                    v.Vertex.Position.X == tile.Vertex.Position.X - 1 && v.Vertex.Position.Y == tile.Vertex.Position.Y);
                if (tile.West != null)
                {
                    tile.West.East = tile;
                }
            }
            if (tile.East == null)
            {
                tile.East = (Tile)Map.FirstOrDefault(v =>
                    v.Vertex.Position.X == tile.Vertex.Position.X + 1 && v.Vertex.Position.Y == tile.Vertex.Position.Y);
                if (tile.East != null)
                {
                    tile.East.West = tile;
                }
            }
        }

        /// <summary>
        /// Used to print map
        /// </summary>
        /// <param name="tile">Tile</param>
        /// <returns>Char representing what is at given position</returns>
        private char GetPrintableTile(Tile tile)
        {
            if (tile == null)
            {
                return ' ';

            }
            if (tile == CurrentTile)
            {
                return 'D';
            }

            switch (tile.Vertex.Type)
            {
                case TileType.Empty:
                    return '.';
                case TileType.Wall:
                    return '#';
                case TileType.OxygenSystem:
                    return 'O';
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
