using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_8.Test
{
    [TestClass]
    public class ReadCsvTest
    {
        [TestMethod]
        public void Should_ReturnTypeIEnumerableStringArray_When_UseReadCsv1()
        {
            Assert.IsTrue(Program.ReadCsv1("airquality.csv") is IEnumerable<string[]>);
        }

        [TestMethod]
        public void Should_Null_When_StringEqualNA()
        {
            var stream = Program.ReadCsv1("airquality.csv");

            var line = stream.ElementAt(5);

            Assert.AreEqual(null, line[1]);
            Assert.AreEqual(null, line[2]);
        }
    }
}
