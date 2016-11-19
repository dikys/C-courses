using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_8.Test
{
    [TestClass]
    class ReadCsv2Test
    {
        private class TestClass1
        {
            
        }

        private class TestClass2
        {
            public string Name;
            public int? Ozone;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_ThrowArgumentException_When_TDoesNotCorrectType()
        {
            Program.ReadCsv2<TestClass2>("airquality.csv");
        }
    }
}
