using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCode2019.Day08.Tests
{ 
    [TestFixture]
    public class ImageTests
    {
        [Test]
        public void ParseFromImageData_GivenTestData_ProducesCorrectImage()
        {
            var img = new Image(3, 2, "123456789012");

            Assert.AreEqual(2, img.Layers.Count);
            Assert.AreEqual("123", string.Join("", img.Layers[0].Pixels[0]));
            Assert.AreEqual("456", string.Join("", img.Layers[0].Pixels[1]));
            Assert.AreEqual("789", string.Join("", img.Layers[1].Pixels[0]));
            Assert.AreEqual("012", string.Join("", img.Layers[1].Pixels[1]));
        }
    }
}
