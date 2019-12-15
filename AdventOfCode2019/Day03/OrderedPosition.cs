using System.Collections.Generic;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day03
{
    public class OrderedPosition : Position
    {
        /// <summary>
        /// Order. Used for counting number of steps
        /// </summary>
        public int Order { get; set; }

        public OrderedPosition(int x = 0, int y = 0, int order = 0) : base(x, y)
        {
            Order = order;
        }

        private sealed class OrderEqualityComparer : IEqualityComparer<OrderedPosition>
        {
            public bool Equals(OrderedPosition x, OrderedPosition y) => x.X == y.X && x.Y == y.Y;

            public int GetHashCode(OrderedPosition obj)
            {
                return obj.Order;
            }
        }

        public static IEqualityComparer<OrderedPosition> OrderComparer { get; } = new OrderEqualityComparer();
    }
}
