using System;
using System.Linq.Expressions;
using ComputerAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerAlgebraTest
{
    [TestClass]
    public class ExpressionExtentionTest
    {
        [TestMethod]
        public void Should_CorrectExpression_When_AppliedDifferentiation()
        {
            Expression<Func<double, double>> f = (x) => x + Math.Sin(3 * x);

            Expression<Func<double, double>> df = f.Differentiate();

            Assert.AreEqual("x => (1 + (Cos((3 * x)) * ((0 * x) + (3 * 1))))", df.ToString());
        }
    }
}
