using System;
using AdventOfCode2019.Common;
using AdventOfCode2019.Day12;

namespace SolutionGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            ISolution solution = new Solution();
            Console.WriteLine($"Part1: {solution.Part1()}");
            Console.WriteLine($"Part2: {solution.Part2()}");
            Console.ReadKey();
        }
    }
}
