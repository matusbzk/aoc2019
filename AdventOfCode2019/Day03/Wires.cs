using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day03
{
    /// <summary>
    /// Collection of wires
    /// </summary>
    /// <remarks>I expected part 2 to consist of more than two wires so I prepared in advance.</remarks>
    public class Wires
    {
        /// <summary>
        /// Stores all wires and their paths
        /// </summary>
        /// <remarks>This is so path is only computed once for each wire</remarks>
        public Dictionary<Wire, IEnumerable<OrderedPosition>> WirePaths { get; set; }

        public Wires(IEnumerable<Wire> wires)
        {
            if (wires == null)
            {
                throw new ArgumentNullException(nameof(wires));
            }

            WirePaths = new Dictionary<Wire, IEnumerable<OrderedPosition>>();
            foreach (var wire in wires)
            {
                WirePaths.Add(wire, wire.GetPath());
            }
        }

        /// <summary>
        /// Returns all position which are on path of two or more wires.
        /// </summary>
        /// <returns>All position which are on path of two or more wires</returns>
        public IEnumerable<OrderedPosition> GetIntersections()
        {
            var result = new List<OrderedPosition>();
            foreach (var wirePath1 in WirePaths)
            {
                foreach (var wirePath2 in WirePaths)
                {
                    if (!Equals(wirePath1.Key, wirePath2.Key))
                    {
                        var arr1 = wirePath1.Value;
                        var arr2 = wirePath2.Value;
                        arr1 = arr1.Where(p => arr2.Any(p2 => p.X == p2.X && p.Y == p2.Y)).ToArray();
                        arr2 = arr2.Where(p => arr1.Any(p2 => p.X == p2.X && p.Y == p2.Y)).ToArray();
                        var sth = arr1.GroupJoin(arr2, p => new {p.X, p.Y}, p => new {p.X, p.Y},
                            (p, pe) => new OrderedPosition(p.X, p.Y,
                                p.Order + pe.OrderBy(k => k.Order).First().Order)).ToArray();
                        result.AddRange(sth);
                    }
                }
            }

            return result.GroupBy(p => new { p.X, p.Y }).Select(g => g.First());
        }

        /// <summary>
        /// Returns intersection closest to central port.
        /// </summary>
        /// <returns>Intersection closest to central port</returns>
        public OrderedPosition GetClosestIntersection() => GetIntersections().OrderBy(p => p.GetDistance()).First();

        /// <summary>
        /// Returns intersection which can be gotten to in smallest number of steps.
        /// </summary>
        /// <returns>Intersection which can be gotten to in smallest number of steps</returns>
        public OrderedPosition GetFastestIntersection() => GetIntersections().OrderBy(p => p.Order).First();
    }
}
