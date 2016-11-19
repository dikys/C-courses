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
    }
}
