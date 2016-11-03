using System;
using System.Linq.Expressions;

namespace ComputerAlgebra
{
    public static class ExpressionExpansion
    {
        public static Expression<Func<double, double>> Differentiate(this Expression<Func<double, double>> expression)
        {
            return Differentiator.Differentiate(expression);
        }
    }
}
