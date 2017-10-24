using Remotion.Linq.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;

namespace Rql.Linq.ExpressionVisitors
{
	/// <summary>
	///		An expression visitor that ignores Block expressions.
	/// </summary>
	[DebuggerStepThrough]
    internal class ExpressionVisitorBase : RelinqExpressionVisitor
    {
		protected override Expression VisitExtension(Expression extensionExpression)
		{
			//if (extensionExpression is NullConditionalExpression)
			//{
			//	return extensionExpression;
			//}

			return base.VisitExtension(extensionExpression);
		}

		protected override Expression VisitBlock(BlockExpression node)
		{
			return base.VisitBlock(node);
		}
	}
}
