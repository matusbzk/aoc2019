using NUnit.Framework;

namespace AdventOfCode2019.Day06.Tests
{
    [TestFixture]
    public class Day06InputLoaderTests
    {
        [Test]
        public void ParseDay06Input_GivenTestData_ReturnsCorrectResult()
        {
            var com = new Object { Name = "COM" };
            var b = new Object { Name = "B" };
            var c = new Object { Name = "C" };
            var d = new Object { Name = "D" };
            var e = new Object { Name = "E" };
            var f = new Object { Name = "F" };
            var g = new Object { Name = "G" };
            var h = new Object { Name = "H" };
            var i = new Object { Name = "I" };
            var j = new Object { Name = "J" };
            var k = new Object { Name = "K" };
            var l = new Object {Name = "L"};
            com.Children.Add(b);
            b.Children.Add(c);
            b.Children.Add(g);
            g.Children.Add(h);
            c.Children.Add(d);
            d.Children.Add(e);
            d.Children.Add(i);
            e.Children.Add(f);
            e.Children.Add(j);
            j.Children.Add(k);
            k.Children.Add(l);

            var expectedResult = new Map();
            expectedResult.Roots.Add(com);

            var actualResult = TestData.TestMap();

            Assert.AreEqual(expectedResult.Stringified(), actualResult.Stringified());
        }

        [Test]
        public void ParseDay06Input_GivenTestDataWithYouAndSanta_ContainsYouAndSanta()
        {
            var actualResult = TestData.TestMap2();

            Assert.IsNotNull(actualResult.You);
            Assert.IsNotNull(actualResult.Santa);
        }
    }
}
