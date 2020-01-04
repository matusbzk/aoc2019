using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day08
{
    /// <summary>
    /// Represents a layer of image
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// Represents pixels of the layer
        /// </summary>
        public IList<IList<int>> Pixels { get; set; } = new List<IList<int>>();

        /// <summary>
        /// Returns how many copies of given digit the layer contains
        /// </summary>
        /// <param name="digit">Digit</param>
        /// <returns>How many times is that digit used</returns>
        public int DigitCount(int digit) => Pixels.SelectMany(line => line).Count(pixel => pixel == digit);

        /// <summary>
        /// Returns visual representation of layer
        /// </summary>
        public string VisualRepresentation()
        {
            var result = "";
            foreach (var line in Pixels)
            {
                result = line.Aggregate(result, (current, pixel) => current + GetVisualRepresentationOfPixel(pixel));
                result += "\n";
            }

            return result;
        }

        private char GetVisualRepresentationOfPixel(int pixel)
        {
            return pixel switch
            {
                0 => '.',
                1 => '#',
                2 => ' ',
                _ => throw new ArgumentException($"Invalid value of pixel: {pixel}", nameof(pixel))
            };
        }
    }
}
