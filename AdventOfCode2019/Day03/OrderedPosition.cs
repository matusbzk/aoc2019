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
    }
}
