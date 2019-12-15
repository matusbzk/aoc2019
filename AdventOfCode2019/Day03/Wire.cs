using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day03
{
    /// <summary>
    /// Represents a wire
    /// </summary>
    public class Wire
    {
        /// <summary>
        /// Instructions
        /// </summary>
        public IList<Instruction> Instructions { get; set; }

        public Wire(string instructionsStr)
        {
            Instructions = new List<Instruction>();
            foreach (var instructionStr in instructionsStr.Split(','))
            {
                Instructions.Add(new Instruction(instructionStr));
            }
        }

        /// <summary>
        /// Returns path of wire.
        /// </summary>
        /// <returns>Path of wire</returns>
        public IEnumerable<OrderedPosition> GetPath()
        {
            var currentPosition = new OrderedPosition();
            var result = new List<OrderedPosition>();
            foreach (var instruction in Instructions)
            {
                var crossedPositions = instruction
                    .Apply(new OrderedPosition(currentPosition.X, currentPosition.Y, currentPosition.Order))
                    .ToArray();
                result.AddRange(crossedPositions);
                currentPosition = crossedPositions.Last();
            }

            return result.GroupBy(p => new {p.X, p.Y}).Select(g => g.First());
        }

        protected bool Equals(Wire other)
        {
            return Equals(Instructions, other.Instructions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Wire) obj);
        }

        public override int GetHashCode()
        {
            return (Instructions != null ? Instructions.GetHashCode() : 0);
        }
    }
}
