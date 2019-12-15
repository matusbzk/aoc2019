using System.Linq;
using AdventOfCode2019.Common.Structures;

namespace AdventOfCode2019.Day06
{
    /// <summary>
    /// Represents object in Space
    /// </summary>
    public class Object : RootedForestObject
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        public int NumberOfOrbits() => NumberOfDescendants() + Children.Sum(c => ((Object) c).NumberOfOrbits());

        public int NumberOfDescendants() => Children.Count + Children.Sum(c => ((Object)c).NumberOfDescendants());

        /// <summary>
        /// Used to return forest in string form
        /// </summary>
        public string Stringified(int level = 0)
        {
            var result = "";
            for (var i = 0; i < level; i++)
            {
                result += "\t";
            }

            result += $"{Name}\n";
            foreach (var child in Children)
            {
                result += ((Object) child).Stringified(level + 1);
            }

            return result;
        }
    }
}
