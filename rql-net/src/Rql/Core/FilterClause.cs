using System;
using System.Collections.Generic;
using System.Text;

namespace Rql.Core
{
	public class FilterClause
	{
		public FilterOperation Operation { get; }
		
		public FilterClause(FilterOperation operation)
		{
			Operation = Check.IsNotNull(operation, nameof(operation));
		}
	}
}
