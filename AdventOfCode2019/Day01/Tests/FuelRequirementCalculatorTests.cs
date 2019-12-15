using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode2019.Day01.Tests
{
    [TestFixture]
    public class FuelRequirementCalculatorTests
    {
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void GetFuelRequired_GivenValidMass_ReturnsCorrectResult(int mass, int expectedResult)
        {
            Assert.AreEqual(expectedResult, FuelRequirementCalculator.GetFuelRequired(mass));
        }

        [TestCase(new[] { 12, 14, 1969, 100756 }, 34241)]
        public void GetFuelRequiredForAll_GivenValidMasses_ReturnsCorrectResult(IEnumerable<int> masses, int expectedResult)
        {
            Assert.AreEqual(expectedResult, FuelRequirementCalculator.GetFuelRequiredForAll(masses));
        }

        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void GetTotalFuelRequired_GivenValidMass_ReturnsCorrectResult(int mass, int expectedResult)
        {
            Assert.AreEqual(expectedResult, FuelRequirementCalculator.GetTotalFuelRequired(mass));
        }

        [TestCase(new[] { 14, 1969, 100756 }, 51314)]
        public void GetTotalFuelRequiredForAll_GivenValidMasses_ReturnsCorrectResult(IEnumerable<int> masses, int expectedResult)
        {
            Assert.AreEqual(expectedResult, FuelRequirementCalculator.GetTotalFuelRequiredForAll(masses));
        }
    }
}
