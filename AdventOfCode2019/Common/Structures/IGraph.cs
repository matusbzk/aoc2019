using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Common.Structures
{
    /// <summary>
    /// Graph consists of vertices and edges
    /// </summary>
    public interface IGraph<TVertex> : IList<TVertex>
    {
        IEnumerable<TVertex> ListVertices();
    }
}
