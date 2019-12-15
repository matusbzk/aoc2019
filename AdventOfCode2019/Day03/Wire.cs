using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day03
{
    /// <summary>
    /// Represents a wire
    /// </summary>
    public class Wire
    {
        private IEnumerable<OrderedPosition> _path;

        /// <summary>
        /// Instructions
        /// </summary>
        public IList<Instruction> Instructions { get; set; }

        /// <summary>
        /// Path of wire.
        /// </summary>
        public IEnumerable<OrderedPosition> Path
        {
            get
            {
                if (_path != null)
                {
                    return _path;
                }
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

                _path = result.GroupBy(p => new {
                    p.X,
                    p.Y
                }).Select(g => g.First());

                return _path;
            }
        }

        public Wire(string instructionsStr)
        {
            Instructions = new List<Instruction>();
            foreach (var instructionStr in instructionsStr.Split(','))
            {
                Instructions.Add(new Instruction(instructionStr));
            }
        }
    }
}
