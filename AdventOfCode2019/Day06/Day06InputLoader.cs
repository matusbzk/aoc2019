using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Common;
using AdventOfCode2019.Common.Structures;

namespace AdventOfCode2019.Day06
{
    public static class Day06InputLoader
    {
        public static Map LoadDay06Input()
        {
            var lines = InputLoader.LoadLines(6);

            return ParseDay06Input(lines);
        }

        public static Map ParseDay06Input(IEnumerable<string> lines)
        {
            var result = new Map();
            var objects = new List<Object>();
            foreach (var line in lines)
            {
                var splitted = line.Split(')');
                var orbitedName = splitted[0];
                var orbited = objects.FirstOrDefault(o => o.Name == orbitedName);
                if (orbited == null)
                {
                    orbited = new Object { Name = orbitedName, Children = new List<RootedForestObject>() };
                    objects.Add(orbited);
                }

                var orbitingName = splitted[1];
                var orbiting = objects.FirstOrDefault(o => o.Name == orbitingName);
                if (orbiting == null)
                {
                    orbiting = new Object { Name = orbitingName };
                    objects.Add(orbiting);
                }

                switch (orbitingName)
                {
                    case "YOU":
                        result.You = orbiting;
                        break;
                    case "SAN":
                        result.Santa = orbiting;
                        break;
                }

                orbiting.Parent = orbited;
                orbited.Children.Add(orbiting);
            }

            var roots = new List<Object>();
            roots.AddRange(objects);

            foreach (var obj in objects)
            {
                foreach (var objChild in obj.Children)
                {
                    roots.Remove((Object)objChild);
                }
            }

            result.Roots = roots;
            return result;
        }
    }
}
