using Remotion.Linq.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Rql.Linq.ExpressionVisitors;

namespace Rql.Linq
{
    internal class RqlGeneratorExpressionTreeVisitor : ExpressionVisitorBase
	{
		private readonly StringBuilder _rqlExpression = new StringBuilder();
		private string _parameter = null;

		public static string GetRqlExpression(Expression expression)
		{
			var visitor = new RqlGeneratorExpressionTreeVisitor();
			visitor.Visit(expression);
			return visitor.GetRqlExpression();
		}

		public string GetRqlExpression()
		{
			return _rqlExpression.ToString();
		}

		
		protected override Expression VisitBinary(BinaryExpression expression)
		{
			switch (expression.NodeType)
			{
				case ExpressionType.Equal: return VisitBinaryPrefix(expression, "eq");
				case ExpressionType.NotEqual: return VisitBinaryPrefix(expression, "ne");
				case ExpressionType.LessThan: return VisitBinaryPrefix(expression, "lt");
				case ExpressionType.GreaterThan: return VisitBinaryPrefix(expression, "gt");
				case ExpressionType.LessThanOrEqual: return VisitBinaryPrefix(expression, "le");
				case ExpressionType.GreaterThanOrEqual: return VisitBinaryPrefix(expression, "ge");
				case ExpressionType.AndAlso: return VisitBinaryPrefix(expression, "and");
				case ExpressionType.OrElse: return VisitBinaryPrefix(expression, "or");

				default:
					throw new NotSupportedException("Binary opertion not supported.");
			}
		}

		private Expression VisitBinaryInfix(BinaryExpression expression, string op)
		{
			Visit(expression.Left);
			_rqlExpression.Append(op);
			Visit(expression.Right);

			return expression;
		}

		private Expression VisitBinaryPrefix(BinaryExpression expression, string op)
		{
			_rqlExpression.AppendFormat("{0}(", op);
			Visit(expression.Left);
			_rqlExpression.Append(",");
			Visit(expression.Right);
			_rqlExpression.Append(")");

			return expression;
		}


		protected override Expression VisitMember(MemberExpression expression)
		{
			_rqlExpression.Append(expression.Member.Name);
			return expression;
		}

		protected override Expression VisitConstant(ConstantExpression expression)
		{
			if (expression.Type == typeof(string))
				_rqlExpression.AppendFormat("\"{0}\"", expression.Value);
			else
				_rqlExpression.AppendFormat("{0}", expression.Value);
			return expression;
		}
	}
}
