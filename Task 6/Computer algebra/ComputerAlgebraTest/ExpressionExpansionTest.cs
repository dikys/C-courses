using System;
using System.Linq.Expressions;
using ComputerAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerAlgebraTest
{
    [TestClass]
    public class ExpressionExpansionTest
    {
        [TestMethod]
        public void Should_CorrectExpression_When_AppliedDifferentiation()
        {
            Expression<Func<double, double>> f = (x) => x - x * 3 + Math.Sin(3 * x) + Math.Abs(10 * x);

            Expression<Func<double, double>> df = f.Differentiate();

            Assert.AreEqual("x => (((1 - 3) + (Cos((3 * x)) * 3)) + Diff(Abs((10 * x))))", df.ToString());
        }
    }
}
