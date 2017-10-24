using System.Collections.Generic;
using System.Text;

namespace Rql.Core
{

	public class RqlUri
    {
		public FilterClause Filter { get; set; }

		public OrderByClause OrderBy { get; set; }

		public long? Skip { get; set; }

		public long? Take { get; set; }

		public bool Count { get; set; }

		public bool CountRemaining { get; set; }

		internal RqlUri(FilterClause filter, OrderByClause orderBy, long? skip, long? take, bool count, bool countRemaining)
		{
			Filter = filter;
			OrderBy = orderBy;
			Skip = skip;
			Take = take;
			Count = count;
			CountRemaining = countRemaining;
		}
    }
}
