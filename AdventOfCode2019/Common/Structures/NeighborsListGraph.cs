using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Common.Structures
{
    /// <summary>
    /// Graph represented by list of neighbors for each vertex
    /// </summary>
    /// <typeparam name="TVertex">Type of vertex</typeparam>
    public class NeighborsListGraph<TVertex> : IGraph<NeighborsListGraphVertex<TVertex>>
        
    {
        public IList<NeighborsListGraphVertex<TVertex>> Vertices { get; set; } =
            new List<NeighborsListGraphVertex<TVertex>>();

        /// <inheritdoc />
        public IEnumerable<NeighborsListGraphVertex<TVertex>> ListVertices() => Vertices;

        #region IList
        /// <inheritdoc />
        public IEnumerator<NeighborsListGraphVertex<TVertex>> GetEnumerator() => Vertices.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(NeighborsListGraphVertex<TVertex> item) => Vertices.Add(item);

        /// <inheritdoc />
        public void Clear() => Vertices.Clear();

        /// <inheritdoc />
        public bool Contains(NeighborsListGraphVertex<TVertex> item) => Vertices.Contains(item);

        /// <inheritdoc />
        public void CopyTo(NeighborsListGraphVertex<TVertex>[] array, int arrayIndex) =>
            Vertices.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(NeighborsListGraphVertex<TVertex> item) => Vertices.Remove(item);

        /// <inheritdoc />
        public int Count => Vertices.Count;

        /// <inheritdoc />
        public bool IsReadOnly => Vertices.IsReadOnly;

        /// <inheritdoc />
        public int IndexOf(NeighborsListGraphVertex<TVertex> item) => Vertices.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, NeighborsListGraphVertex<TVertex> item) => Vertices.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index) => Vertices.RemoveAt(index);

        /// <inheritdoc />
        public NeighborsListGraphVertex<TVertex> this[int index]
        {
            get => Vertices[index];
            set => Vertices[index] = value;
        }
        #endregion

    }
}
