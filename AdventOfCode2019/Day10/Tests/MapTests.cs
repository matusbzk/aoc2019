using NUnit.Framework;

namespace AdventOfCode2019.Day10.Tests
{
    [TestFixture]
    public class MapTests
    {
        [TestCase(new[] {".#..#", ".....", "#####", "....#", "...##"}, 8)]
        [TestCase(new[]
        {
            "......#.#.",
            "#..#.#....",
            "..#######.",
            ".#.#.###..",
            ".#..#.....",
            "..#....#.#",
            "#..#....#.",
            ".##.#..###",
            "##...#..#.",
            ".#....####"
        }, 33)]
        [TestCase(new[]
        {
            "#.#...#.#.",
            ".###....#.",
            ".#....#...",
            "##.#.#.#.#",
            "....#.#.#.",
            ".##..###.#",
            "..#...##..",
            "..##....##",
            "......#...",
            ".####.###."
        }, 35)]
        [TestCase(new[]
        {
            ".#..#..###",
            "####.###.#",
            "....###.#.",
            "..###.##.#",
            "##.##.#.#.",
            "....###..#",
            "..#.#..#.#",
            "#..#.#.###",
            ".##...##.#",
            ".....#.#.."
        }, 41)]
        [TestCase(new[]
        {
            ".#..##.###...#######",
            "##.############..##.",
            ".#.######.########.#",
            ".###.#######.####.#.",
            "#####.##.#.##.###.##",
            "..#####..#.#########",
            "####################",
            "#.####....###.#.#.##",
            "##.#################",
            "#####.##.###..####..",
            "..######..##.#######",
            "####.##.####...##..#",
            ".#####..#.######.###",
            "##...#.##########...",
            "#.##########.#######",
            ".####.#.###.###.#.##",
            "....##.##.###..#####",
            ".#.#.###########.###",
            "#.#.#.#####.####.###",
            "###.##.####.##.#..##"
        }, 210)]
        public void HowManyAsteroidsCanBestAsteroidDetect_GivenExampleMap_ReturnsCorrectResult(string[] input,
            int expectedResult)
        {
            var map = new Map(input);

            var actualResult = map.HowManyAsteroidsCanBestAsteroidDetect();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[]
        {
            ".#....#####...#..",
            "##...##.#####..##",
            "##...#...#.#####.",
            "..#.....#...###..",
            "..#.#.....#....##"
        }, 1, 801)]
        public void GetNthVaporized_GivenSimpleExampleCases_ReturnsCorrectResult(string[] input, int n, int expectedResult)
        {
            var map = new Map(input);
            Assert.AreEqual(8, map.MonitoringStation.Position.X);
            Assert.AreEqual(3, map.MonitoringStation.Position.Y);

            var asteroid = map.GetNthVaporized(n);
            var actualResult = asteroid.Position.X * 100 + asteroid.Position.Y;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new[]
        {
            ".#..##.###...#######",
            "##.############..##.",
            ".#.######.########.#",
            ".###.#######.####.#.",
            "#####.##.#.##.###.##",
            "..#####..#.#########",
            "####################",
            "#.####....###.#.#.##",
            "##.#################",
            "#####.##.###..####..",
            "..######..##.#######",
            "####.##.####...##..#",
            ".#####..#.######.###",
            "##...#.##########...",
            "#.##########.#######",
            ".####.#.###.###.#.##",
            "....##.##.###..#####",
            ".#.#.###########.###",
            "#.#.#.#####.####.###",
            "###.##.####.##.#..##"
        }, 802)]
        public void GetNthVaporized_GivenExampleMap_ReturnsCorrectResult(string[] input, int expectedResult)
        {
            var map = new Map(input);

            var asteroid = map.GetNthVaporized(200);
            var actualResult = asteroid.Position.X * 100 + asteroid.Position.Y;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
