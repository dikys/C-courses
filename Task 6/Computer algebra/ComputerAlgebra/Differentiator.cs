using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ComputerAlgebra
{
    public class Differentiator : ExpressionVisitor
    {
        private static readonly Differentiator differentiator;
        private static readonly MethodInfo diffInfo;

        static Differentiator()
        {
            differentiator = new Differentiator();
            diffInfo = differentiator.GetType().GetMethod("Diff");
        }

        // метод - маркер дифференцирования
        public static double Diff(double value)
        {
            return 1;
        }

        public static Expression<Func<double, double>> Differentiate(Expression<Func<double, double>> expression)
        {
            var arguments = expression.Parameters;
            var body = differentiator.Visit(Expression.Call(Differentiator.diffInfo, expression.Body));

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

                    if (operation.Left.NodeType == ExpressionType.Constant
                        && operation.Right.NodeType == ExpressionType.Constant)
                    {
                        return Expression.Constant(0.0, typeof(double));
                    }
                    else if (operation.Left.NodeType == ExpressionType.Constant)
                    {
                        return VisitMethodCall(Expression.Call(Differentiator.diffInfo, operation.Right));
                    }
                    else if (operation.Right.NodeType == ExpressionType.Constant)
                    {
                        return VisitMethodCall(Expression.Call(Differentiator.diffInfo, operation.Left));
                    }
                    else if (operation.Left.NodeType == ExpressionType.Parameter
                             && operation.Right.NodeType == ExpressionType.Parameter)
                    {
                        return Expression.Constant(2.0, typeof(double));
                    }

                    return VisitBinary(
                        Expression.MakeBinary(body.NodeType,
                            Expression.Call(Differentiator.diffInfo,
                                operation.Left),
                            Expression.Call(Differentiator.diffInfo,
                                operation.Right)));

                case ExpressionType.Multiply:
                    BinaryExpression multiply = (BinaryExpression)body;

                    if (multiply.Left.NodeType == ExpressionType.Parameter
                             && multiply.Right.NodeType == ExpressionType.Parameter)
                    {
                        return Expression.Multiply(Expression.Constant(2.0, typeof(double)), multiply.Right);
                    }
                    else if (multiply.Left.NodeType == ExpressionType.Constant
                             && multiply.Right.NodeType == ExpressionType.Parameter)
                    {
                        return multiply.Left;
                    }
                    else if (multiply.Left.NodeType == ExpressionType.Parameter
                             && multiply.Right.NodeType == ExpressionType.Constant)
                    {
                        return multiply.Right;
                    }
                    else if (multiply.Left.NodeType == ExpressionType.Constant
                        && multiply.Right.NodeType == ExpressionType.Constant)
                    {
                        return Expression.Constant(0.0, typeof(double));
                    }
                    else if (multiply.Left.NodeType == ExpressionType.Constant)
                    {
                        return VisitBinary(
                            Expression.Multiply(
                                multiply.Left,
                                Expression.Call(Differentiator.diffInfo,
                                    multiply.Right)));
                    }
                    else if (multiply.Right.NodeType == ExpressionType.Constant)
                    {
                        return VisitBinary(
                            Expression.Multiply(
                                multiply.Right,
                                Expression.Call(Differentiator.diffInfo,
                                    multiply.Left)));
                    }

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

                    if (method.Method == typeof(Math).GetMethod("Sin"))
                    {
                        return VisitBinary(
                            Expression.MakeBinary(ExpressionType.Multiply,
                                Expression.Call(typeof(Math).GetMethod("Cos"),
                                    method.Arguments),
                                Expression.Call(Differentiator.diffInfo,
                                    method.Arguments)));
                    }
                    else if (method.Method == typeof(Math).GetMethod("Cos"))
                    {
                        return VisitBinary(
                            Expression.MakeBinary(ExpressionType.Multiply,
                                Expression.Call(typeof(Math).GetMethod("Sin"),
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
