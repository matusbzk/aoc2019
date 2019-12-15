using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day03
{
    /// <summary>
    /// Collection of wires
    /// </summary>
    public class Wires
    {
        /// <summary>
        /// First wire
        /// </summary>
        public Wire Wire1 { get; set; }

        /// <summary>
        /// Second wire
        /// </summary>
        public Wire Wire2 { get; set; }

        public Wires(Wire wire1, Wire wire2)
        {
            Wire1 = wire1 ?? throw new ArgumentNullException(nameof(wire1));
            Wire2 = wire2 ?? throw new ArgumentNullException(nameof(wire2));
        }

        /// <summary>
        /// Returns all position which are on path of two or more wires.
        /// </summary>
        /// <returns>All position which are on path of two or more wires</returns>
        public IEnumerable<OrderedPosition> GetIntersections()
        {
            var result = new List<OrderedPosition>();
            result.AddRange(Wire1.Path.Join(Wire2.Path, p => new {p.X, p.Y}, p => new {p.X, p.Y},
                (p1, p2) => new OrderedPosition(p1.X, p1.Y, p1.Order + p2.Order)));

            return result;
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
