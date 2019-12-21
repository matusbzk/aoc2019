using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2019.Common;
using AdventOfCode2019.Common.Geometry;

namespace AdventOfCode2019.Day12
{
    public static class Day12InputLoader
    {
        public static MoonSystem LoadDay12Input() => new MoonSystem(InputLoader.LoadLines(12).Select(ParseMoon));

        public static Moon ParseMoon(string line)
        {
            var regex = new Regex("^<x=(.*), y=(.*), z=(.*)>$");
            var match = regex.Match(line);
            return new Moon(
                new Position3D(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value),
                    Convert.ToInt32(match.Groups[3].Value)), new Position3D());
        }
    }
}
