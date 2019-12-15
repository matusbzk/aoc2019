using System.Collections.Generic;

namespace AdventOfCode2019.Common.Structures
{
    /// <summary>
    /// Object which can be stored in <see cref="RootedForest{T}"/>
    /// </summary>
    public class RootedForestObject
    {
        /// <summary>
        /// Parent
        /// </summary>
        public RootedForestObject Parent { get; set; }

        /// <summary>
        /// List of children
        /// </summary>
        public IList<RootedForestObject> Children { get; set; } = new List<RootedForestObject>();

        /// <summary>
        /// List of all ancestors, closest first
        /// </summary>
        public IList<RootedForestObject> Ancestors()
        {
            if (Parent == null)
            {
                return new List<RootedForestObject>();
            }
            var result = new List<RootedForestObject> {Parent};
            result.AddRange(Parent.Ancestors());
            return result;
        }
    }
}
