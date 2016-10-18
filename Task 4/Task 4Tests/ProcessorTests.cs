using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4.Tests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void Should_SameType_When_CreateProcessor()
        {
            var processor = ProcessorBuilder.CreateEngine<int>().For<double>().With<char>();

            Assert.IsTrue(processor is Processor<int, double, char>);
        }
    }
}