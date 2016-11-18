using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_8.Test
{
    [TestClass]
    public class ReadCsv4Test
    {
        [TestMethod]
        public void Should_ReturnTypeIEnumerableOfDictionaryOfDynamic()
        {
            Assert.IsTrue(Program.ReadCsv4("airquality.csv") is IEnumerable<dynamic>);
        }

        [TestMethod]
        public void Should_NextCodeWork()
        {
            Program.ReadCsv4("airquality.csv").Where(z => z.Ozone > 10).Select(z => z.Wind);
        }

        [TestMethod]
        public void Should_CorrectDictionary_When_Sensor5()
        {
            var sensor5 = Program.ReadCsv3("airquality.csv").ElementAt(4);

            Assert.AreEqual("Sensor5", sensor5.Name);
            Assert.AreEqual(null, sensor5["Ozone"]);
            Assert.AreEqual(null, sensor5["Solar.R"]);
            Assert.AreEqual(14.3, sensor5["Wind"]);
            Assert.AreEqual(56, sensor5["Temp"]);
            Assert.AreEqual(5, sensor5["Month"]);
            Assert.AreEqual(5, sensor5["Day"]);
        }
    }
}
