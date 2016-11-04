using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ComputerAlgebra
{
    public class Differentiator : ExpressionVisitor
    {
        private static readonly MethodInfo diffInfo = ((Func<double, double>)Diff).Method;

        // метод - маркер дифференцирования
        private static double Diff(double value)
        {
            return value;
        }

        public Expression<Func<double, double>> Differentiate(Expression<Func<double, double>> expression)
        {
            var arguments = expression.Parameters;
            var body = this.Visit(Expression.Call(Differentiator.diffInfo, expression.Body));

            return Expression.Lambda<Func<double, double>>(body, arguments);
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            if (expression.Method != Differentiator.diffInfo)
            {
                return base.VisitMethodCall(expression);
            }

            var body = expression.Arguments[0];

            switch (body.NodeType)
            {
                case ExpressionType.Constant:
                    return VisitConstant(Expression.Constant(0.0, typeof(double)));

                case ExpressionType.Parameter:
                    return VisitConstant(Expression.Constant(1.0, typeof(double)));

                case ExpressionType.Add:
                case ExpressionType.Subtract:
                    BinaryExpression operation = (BinaryExpression)body;

                    return VisitBinary(
                        Expression.MakeBinary(body.NodeType,
                            Expression.Call(Differentiator.diffInfo,
                                operation.Left),
                            Expression.Call(Differentiator.diffInfo,
                                operation.Right)));

                case ExpressionType.Multiply:
                    BinaryExpression multiply = (BinaryExpression)body;

                    return VisitBinary(
                        Expression.MakeBinary(ExpressionType.Add,
                            Expression.MakeBinary(ExpressionType.Multiply,
                                Expression.Call(Differentiator.diffInfo, multiply.Left),
                                multiply.Right),
                            Expression.MakeBinary(ExpressionType.Multiply,
                                multiply.Left,
                                Expression.Call(Differentiator.diffInfo, multiply.Right))));

                case ExpressionType.Call:
                    MethodCallExpression method = (MethodCallExpression)body;

                    if (method.Method == ((Func<double, double>)Math.Sin).Method)
                    {
                        return VisitBinary(
                            Expression.MakeBinary(ExpressionType.Multiply,
                                Expression.Call(((Func<double, double>)Math.Cos).Method,
                                    method.Arguments),
                                Expression.Call(Differentiator.diffInfo,
                                    method.Arguments)));
                    }
                    break;
            }

            return base.VisitMethodCall(expression);
        }
    }
}
