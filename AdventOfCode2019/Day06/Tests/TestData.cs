using System.Collections.Generic;

namespace AdventOfCode2019.Day06.Tests
{
    public static class TestData
    {
        public static IEnumerable<string> TestInput = new List<string>
        {
            "COM)B",
            "B)C",
            "C)D",
            "D)E",
            "E)F",
            "B)G",
            "G)H",
            "D)I",
            "E)J",
            "J)K",
            "K)L"
        };

        public static IEnumerable<string> TestInput2 = new List<string>
        {
            "COM)B",
            "B)C",
            "C)D",
            "D)E",
            "E)F",
            "B)G",
            "G)H",
            "D)I",
            "E)J",
            "J)K",
            "K)L",
            "K)YOU",
            "I)SAN"
        };

        public static Map TestMap() => Day06InputLoader.ParseDay06Input(TestInput);

        public static Map TestMap2() => Day06InputLoader.ParseDay06Input(TestInput2);
    }
}
