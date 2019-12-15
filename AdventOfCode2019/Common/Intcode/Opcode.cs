namespace AdventOfCode2019.Common.Intcode
{
    /// <summary>
    /// Type of opcode
    /// </summary>
    public enum Opcode
    {
        /// <summary>
        /// Adds together numbers read from two positions and stores
        /// the result in a third position.
        /// </summary>
        Addition = 1,

        /// <summary>
        /// Multiplies together numbers read from two positions and stores
        /// the result in a third position.
        /// </summary>
        Multiplication = 2,

        /// <summary>
        /// Takes a single integer as input and saves it to the position
        /// given by its only parameter.
        /// </summary>
        Input = 3,

        /// <summary>
        /// Outputs the value of its only parameter.
        /// </summary>
        Output = 4,

        /// <summary>
        /// If the first parameter is non-zero, it sets the instruction
        /// pointer to the value from the second parameter.
        /// Otherwise, it does nothing.
        /// </summary>
        JumpIfTrue = 5,

        /// <summary>
        /// If the first parameter is zero, it sets the instruction pointer
        /// to the value from the second parameter. Otherwise, it does nothing.
        /// </summary>
        JumpIfFalse = 6,

        /// <summary>
        /// If the first parameter is less than the second parameter, it stores 1
        /// in the position given by the third parameter. Otherwise, it stores 0.
        /// </summary>
        LessThan = 7,

        /// <summary>
        /// If the first parameter is equal to the second parameter, it stores 1
        /// in the position given by the third parameter. Otherwise, it stores 0.
        /// </summary>
        Equals = 8,

        /// <summary>
        /// Halt.
        /// </summary>
        Halt = 99
    }
}
