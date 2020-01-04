using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common;
using AdventOfCode2019.Common.Geometry;
using AdventOfCode2019.Common.Structures;
using MoreLinq;

namespace AdventOfCode2019.Day15
{
    public class Tile : NeighborsListGraphVertex<TileInfo>
    {
        public Tile(TileInfo vertex) : base(vertex)
        {
        }

        public Tile North { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public Tile East { get; set; }

        public override IEnumerable<NeighborsListGraphVertex<TileInfo>> Neighbors =>
            new List<NeighborsListGraphVertex<TileInfo>>() {North, South, West, East};

        public CardinalDirection NeighborDirection(Tile neighbor)
        {
            if (neighbor == North)
            {
                return CardinalDirection.North;
            }
            if (neighbor == South)
            {
                return CardinalDirection.South;
            }
            if (neighbor == West)
            {
                return CardinalDirection.West;
            }
            if (neighbor == East)
            {
                return CardinalDirection.East;
            }

            throw new ArgumentException(nameof(neighbor));
        }

        public Tile Neighbor(CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.North:
                    return North ?? (North =
                               new Tile(new TileInfo(new Position(Vertex.Position.X, Vertex.Position.Y + 1)))
                                   {South = this});
                case CardinalDirection.South:
                    return South ?? (South =
                               new Tile(new TileInfo(new Position(Vertex.Position.X, Vertex.Position.Y - 1)))
                                   {North = this});
                case CardinalDirection.West:
                    return West ?? (West =
                               new Tile(new TileInfo(new Position(Vertex.Position.X - 1, Vertex.Position.Y)))
                                   {East = this});
                case CardinalDirection.East:
                    return East ?? (East =
                               new Tile(new TileInfo(new Position(Vertex.Position.X + 1, Vertex.Position.Y)))
                                   {West = this});
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        /// <summary>
        /// Is going to this tile important for droid?
        /// </summary>
        /// <returns>True if this tile is unknown or if some of it's neighbors is null</returns>
        public bool DoesDroidNeedToGoHere() => Vertex.Type == TileType.Unknown || Vertex.Type != TileType.Wall &&
                                               (North == null || South == null || West == null || East == null);

        /// <summary>
        /// Returns path to closest vertices satisfying given condition.
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns>Path to closest vertex which satisfies condition</returns>
        /// <remarks>Returning IEnumerable because there can be more vertices at same distance</remarks>
        public IEnumerable<Stack<CardinalDirection>> PathToClosestVertexWhich(Func<Tile, bool> predicate) =>
            PathToClosestVertexWhichInternal(predicate, 0, this).Item1;

        private Tuple<IEnumerable<Stack<CardinalDirection>>, int> PathToClosestVertexWhichInternal(
            Func<Tile, bool> predicate, int distance, Tile caller)
        {
            //Console.WriteLine($"Calling for {Vertex.Position.X},{Vertex.Position.Y}");
            if(distance > 20)
            {
                return new Tuple<IEnumerable<Stack<CardinalDirection>>, int>(new Stack<CardinalDirection>[] { }, int.MaxValue);
            }
            if (Neighbors.Any(t => predicate((Tile) t)))
            {
                return new Tuple<IEnumerable<Stack<CardinalDirection>>, int>(
                    Neighbors.Where(v => predicate((Tile) v)).Select(v =>
                        new Stack<CardinalDirection>(new[] {NeighborDirection((Tile) v)})), distance);
            }

            var result2 = Neighbors
                .Where(n => n.Vertex.Type != TileType.Wall && !Equals(n.Vertex, caller.Vertex))
                .Select(v => new
                {
                    Neighbor = (Tile) v,
                    RecursionResult = ((Tile) v).PathToClosestVertexWhichInternal(predicate, distance + 1, (Tile)v)
                })
                .MinBy(t => t.RecursionResult.Item2).ToArray();

            return new Tuple<IEnumerable<Stack<CardinalDirection>>, int>(
                result2.SelectMany(x =>
                    x.RecursionResult.Item1.Select(s => s.PushAndReturn(NeighborDirection(x.Neighbor)))),
                result2.First().RecursionResult.Item2);

        }
    }
}
