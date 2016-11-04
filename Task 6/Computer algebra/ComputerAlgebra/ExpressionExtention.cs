using System;
using System.Linq.Expressions;

namespace ComputerAlgebra
{
    public static class ExpressionExtention
    {
        private static Differentiator differentiator = new Differentiator();

        public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
        {
            return differentiator.Differentiate(expression);
        }
    }
}
