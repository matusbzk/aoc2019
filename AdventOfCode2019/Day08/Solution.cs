using System.Linq;
using AdventOfCode2019.Common;

namespace AdventOfCode2019.Day08
{
    /// <inheritdoc />
    public class Solution : ISolution
    {
        private readonly Image _image;

        public Solution()
        {
            var input = InputLoader.LoadText(8);
            _image = new Image(25, 6, input);
        }

        /// <inheritdoc />
        public object Part1()
        {
            var layer = _image.Layers.OrderBy(l => l.DigitCount(0)).First();
            return layer.DigitCount(1) * layer.DigitCount(2);
        }

        /// <inheritdoc />
        public object Part2() => $"\n{_image.GetVisibleImage().VisualRepresentation()}";
    }
}
