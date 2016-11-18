using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_8.Test
{
    [TestClass]
    public class ReadCsv1Test
    {
        [TestMethod]
        public void Should_ReturnTypeIEnumerableOfStringArray()
        {
            Assert.IsTrue(Program.ReadCsv1("airquality.csv") is IEnumerable<string[]>);
        }

        [TestMethod]
        public void Should_Null_When_NA()
        {
            var lines = Program.ReadCsv1("airquality.csv");

            var line = lines.ElementAt(5);

            Assert.AreEqual(null, line[1]);
            Assert.AreEqual(null, line[2]);
        }
    }
}
