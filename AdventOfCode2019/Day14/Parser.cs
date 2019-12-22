using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day14
{
    public static class Parser
    {
        public static IEnumerable<Reaction> ParseReactions(IEnumerable<string> lines) => lines.Select(ParseReaction);

        public static Reaction ParseReaction(string line)
        {
            var result = new Reaction();

            var parseInputsAndOutput =
                line.Split(new[] {"=>"}, StringSplitOptions.None).Select(s => s.Trim()).ToArray();
            var inputs = parseInputsAndOutput[0];
            var output = parseInputsAndOutput[1];

            foreach (var input in inputs.Split(',').Select(s => s.Trim()))
            {
                result.Inputs.Add(ParseIngredient(input));
            }

            result.Output = ParseIngredient(output);

            return result;
        }

        public static Ingredient ParseIngredient(string str)
        {
            var parsed = str.Split(' ');
            var count = Convert.ToInt32(parsed[0]);
            var name = parsed[1];
            return new Ingredient(count, new Chemical(name));
        }
    }
}
