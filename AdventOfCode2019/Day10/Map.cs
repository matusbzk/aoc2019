using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2019.Day10
{
    /// <summary>
    /// Map of asteroids
    /// </summary>
    public class Map
    {
        private Asteroid _monitoringStation;

        /// <summary>
        /// List of asteroids on map
        /// </summary>
        public IList<Asteroid> Asteroids { get; set; }

        /// <summary>
        /// Asteroid on which monitoring station was built
        /// </summary>
        public Asteroid MonitoringStation => _monitoringStation ??= GetBestAsteroid();

        public Map(IEnumerable<string> input)
        {
            ParseMap(input);
        }

        /// <summary>
        /// What is the maximum number of asteroids detectable from one asteroid?
        /// </summary>
        public int HowManyAsteroidsCanBestAsteroidDetect() => HowManyOthersCanAsteroidDetect(MonitoringStation);

        /// <summary>
        /// How many asteroids can be detected from this one?
        /// </summary>
        /// <param name="asteroid">Asteroid</param>
        /// <returns>Number of asteroids visible in direct line of sight</returns>
        public int HowManyOthersCanAsteroidDetect(Asteroid asteroid) => Asteroids
            .Select(a => asteroid.Position.GetAngle(a.Position)).Where(d => d.HasValue).Distinct().Count();

        /// <summary>
        /// Returns Nth asteroid to be vaporized
        /// </summary>
        /// <remarks>Some vaporized asteroids are deleted, not all though</remarks>
        public Asteroid GetNthVaporized(int n)
        {
            var remaining = n;
            while (true)
            {
                var detectable = HowManyOthersCanAsteroidDetect(MonitoringStation);
                if (detectable < remaining)
                {
                    VaporizeAllDetectable();
                    remaining -= detectable;
                }
                else
                {
                    return GetAllDetectable()
                        .OrderBy(a => MonitoringStation.Position.GetAngle(a.Position))
                        .ElementAt(remaining - 1);
                }
            }
        }

        /// <summary>
        /// Deletes all detectable asteroids from map
        /// </summary>
        private void VaporizeAllDetectable()
        {
            foreach (var asteroid in GetAllDetectable())
            {
                Asteroids.Remove(asteroid);
            }
        }

        /// <summary>
        /// Returns all asteroid detectable from current station
        /// </summary>
        private IEnumerable<Asteroid> GetAllDetectable() =>
            Asteroids.Where(a => a != MonitoringStation)
                .GroupBy(a => MonitoringStation.Position.GetAngle(a.Position))
                .Select(g => g.MinBy(a => MonitoringStation.Position.GetDistance(a.Position)).FirstOrDefault());

        private Asteroid GetBestAsteroid() => Asteroids.MaxBy(HowManyOthersCanAsteroidDetect).First();

        private void ParseMap(IEnumerable<string> input)
        {
            Asteroids = new List<Asteroid>();
            var y = 0;
            foreach (var line in input)
            {
                var x = 0;
                foreach (var position in line)
                {
                    if (position == '#')
                    {
                        Asteroids.Add(new Asteroid(x, y));
                    }

                    x++;
                }

                y++;
            }
        }
    }
}
