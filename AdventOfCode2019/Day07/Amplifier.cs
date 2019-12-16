﻿using System;
using System.Collections.Generic;
using AdventOfCode2019.Common.Intcode;

namespace AdventOfCode2019.Day07
{
    /// <summary>
    /// Amplifier
    /// </summary>
    public class Amplifier : IntcodeProgram
    {
        /// <summary>
        /// Phase of the amplifier
        /// </summary>
        public int Phase { get; }
        public int? Input { get; set; }
        public int InputsDone { get; private set; }
        public int? Output { get; private set; }

        public Amplifier(IEnumerable<int> integers, int phase, int? input = null) : base(integers)
        {
            Phase = phase;
            Input = input;
        }

        /// <inheritdoc />
        public override void RunUntilOutput()
        {
            base.RunUntilOutput();
            Input = null;
        }

        /// <inheritdoc />
        protected override int GetInput()
        {
            InputsDone++;
            if (InputsDone == 1)
            {
                return Phase;
            }

            if (Input.HasValue)
            {
                return Input.Value;
            }

            throw new InvalidOperationException("Cannot add another input because it has not been computed yet");
        }

        /// <inheritdoc />
        protected override void DoOutput(int value)
        {
            Output = value;
        }
    }
}
