using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_8.Test
{
    [TestClass]
    public class ReadCsv3Test
    {
        [TestMethod]
        public void Should_ReturnTypeIEnumerableOfDictionaryOfStringAndObject()
        {
            Assert.IsTrue(Program.ReadCsv3("airquality.csv") is IEnumerable<Dictionary<string, object>>);
        }

        [TestMethod]
        public void Should_CorrectDictionary_When_Sensor5()
        {
            var sensor5 = Program.ReadCsv3("airquality.csv").ElementAt(4);
            
            Assert.AreEqual("Sensor5", sensor5["Name"]);
            Assert.AreEqual(null, sensor5["Ozone"]);
            Assert.AreEqual(null, sensor5["Solar.R"]);
            Assert.AreEqual("14.3", sensor5["Wind"]);
            Assert.AreEqual("56", sensor5["Temp"]);
            Assert.AreEqual("5", sensor5["Month"]);
            Assert.AreEqual("5", sensor5["Day"]);
        }
    }
}
