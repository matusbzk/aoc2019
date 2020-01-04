using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2019.Common.Structures
{
    /// <summary>
    /// Vertex of graph represented by lists of neighbors
    /// </summary>
    public class NeighborsListGraphVertex<TVertex>
    {
        public TVertex Vertex { get; set; }

        public virtual IEnumerable<NeighborsListGraphVertex<TVertex>> Neighbors { get; } =
            new List<NeighborsListGraphVertex<TVertex>>();

        public NeighborsListGraphVertex(TVertex vertex)
        {
            Vertex = vertex;
        }

        /// <summary>
        /// Returns closest vertices satisfying given condition.
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns>Closest vertex which satisfies condition</returns>
        /// <remarks>Returning IEnumerable because there can be more vertices at same distance</remarks>
        public IEnumerable<NeighborsListGraphVertex<TVertex>> ClosestVertexWhich(
            Func<NeighborsListGraphVertex<TVertex>, bool> predicate) =>
            ClosestVertexWhichInternal(predicate, 0).Item1;

        private Tuple<IEnumerable<NeighborsListGraphVertex<TVertex>>, int> ClosestVertexWhichInternal(
            Func<NeighborsListGraphVertex<TVertex>, bool> predicate, int distance)
        {
            if (Neighbors.Any(predicate))
            {
                return new Tuple<IEnumerable<NeighborsListGraphVertex<TVertex>>, int>(Neighbors.Where(predicate),
                    distance);
            }

            var result = Neighbors.Select(v => v.ClosestVertexWhichInternal(predicate, distance + 1)).MinBy(t => t.Item2);
            return new Tuple<IEnumerable<NeighborsListGraphVertex<TVertex>>, int>(result.SelectMany(t => t.Item1),
                result.First().Item2);
        }
    }
}
