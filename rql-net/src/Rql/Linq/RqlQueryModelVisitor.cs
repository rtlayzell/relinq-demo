using Remotion.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;

namespace Rql.Linq
{
	internal class RqlQueryModelVisitor : QueryModelVisitorBase
    {
		private readonly StringBuilder _rqlExpression = new StringBuilder();

		public static string GenerateRqlQuery(QueryModel queryModel)
		{
			var visitor = new RqlQueryModelVisitor();
			visitor.VisitQueryModel(queryModel);
			return visitor.GetRqlQuery();
		}


		public string GetRqlQuery()
		{
			return _rqlExpression.ToString();
		}

		public override void VisitAdditionalFromClause(AdditionalFromClause fromClause, QueryModel queryModel, int index)
		{
			throw new NotSupportedException("Cannot select from multiple sources.");
			// base.VisitAdditionalFromClause(fromClause, queryModel, index);
		}

		public override void VisitGroupJoinClause(GroupJoinClause groupJoinClause, QueryModel queryModel, int index)
		{
			throw new NotSupportedException("Cannot select from multiple sources.");
			// base.VisitGroupJoinClause(groupJoinClause, queryModel, index);
		}

		public override void VisitJoinClause(JoinClause joinClause, QueryModel queryModel, int index)
		{
			throw new NotSupportedException("Cannot select from multiple sources.");
			// base.VisitJoinClause(joinClause, queryModel, index);
		}

		public override void VisitJoinClause(JoinClause joinClause, QueryModel queryModel, GroupJoinClause groupJoinClause)
		{
			throw new NotSupportedException("Cannot select from multiple sources.");
			// base.VisitJoinClause(joinClause, queryModel, groupJoinClause);
		}

		public override void VisitMainFromClause(MainFromClause fromClause, QueryModel queryModel)
		{
			base.VisitMainFromClause(fromClause, queryModel);
		}

		public override void VisitOrderByClause(OrderByClause orderByClause, QueryModel queryModel, int index)
		{
			base.VisitOrderByClause(orderByClause, queryModel, index);
		}

		public override void VisitWhereClause(WhereClause whereClause, QueryModel queryModel, int index)
		{
			var rqlExpression = RqlGeneratorExpressionTreeVisitor.GetRqlExpression(whereClause.Predicate);

			//TODO: Add to where parts for later aggregation, for the sake of the demo just set the RQL expression.

			if (_rqlExpression.Length > 0)
				_rqlExpression.Append("&");

			_rqlExpression.Append(rqlExpression);

			base.VisitWhereClause(whereClause, queryModel, index);
		}
	}
}
