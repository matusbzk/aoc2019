using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day08
{
    /// <summary>
    /// Represents an image
    /// </summary>
    public class Image
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public IList<Layer> Layers { get; set; } = new List<Layer>();

        public Image(int width, int height, string data)
        {
            Width = width;
            Height = height;
            ParseFromImageData(data);
        }

        /// <summary>
        /// Get the final image, given 0 is black, 1 is white, and 2 is transparent
        /// and in each pixel, user can always see first nontransparent pixel.
        /// </summary>
        /// <returns>Final image</returns>
        public Layer GetVisibleImage()
        {
            var result = new Layer();
            for (var i = 0; i < Height; i++)
            {
                var line = new List<int>();
                for (var j = 0; j < Width; j++)
                {
                    line.Add(Layers.FirstOrDefault(l => l.Pixels[i][j] != 2)?.Pixels[i][j] ?? 2);
                }
                result.Pixels.Add(line);
            }

            return result;
        }

        private void ParseFromImageData(string data)
        {
            data = string.Join("", data.Where(char.IsDigit));
            var index = 0;
            while (index < data.Length)
            {
                var layer = new Layer();
                for (var i = 0; i < Height; i++)
                {
                    var line = new List<int>();
                    for (var j = 0; j < Width; j++)
                    {
                        line.Add(Convert.ToInt32(char.GetNumericValue(data[index])));
                        index++;
                    }
                    layer.Pixels.Add(line);
                }

                Layers.Add(layer);
            }
        }
    }
}
