using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Common.Structures
{
    /// <summary>
    /// Rooted forest structure
    /// </summary>
    public class RootedForest<T> where T : RootedForestObject
    {
        /// <summary>
        /// Roots
        /// </summary>
        public IList<T> Roots { get; set; } = new List<T>();

        /// <summary>
        /// Distance between two objects
        /// </summary>
        /// <param name="obj1">Object</param>
        /// <param name="obj2">Object</param>
        /// <returns>Distance between objects, null if they are not in same component</returns>
        public int? DistanceBetweenObjects(RootedForestObject obj1, RootedForestObject obj2)
        {
            var indexOf = obj1.Ancestors().IndexOf(obj2);
            if (indexOf != -1)
            {
                return indexOf;
            }

            indexOf = obj2.Ancestors().IndexOf(obj1);
            if (indexOf != -1)
            {
                return indexOf;
            }
            
            var commonAncestor = obj1.Ancestors().FirstOrDefault(a => obj2.Ancestors().Contains(a));
            if (commonAncestor == null)
            {
                return null;
            }
            return DistanceBetweenObjects(obj1, commonAncestor) + DistanceBetweenObjects(obj2, commonAncestor);
        }
    }
}
