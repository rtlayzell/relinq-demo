using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Rql.Core
{
	public class CompositeFilterOperation : FilterOperation
	{
		private readonly IEnumerable<FilterOperation> _operations;

		private IEnumerable<FilterOperation> Operations
		{
			get { return _operations; }
		}

		internal CompositeFilterOperation(FilterOperationKind kind, IEnumerable<FilterOperation> filters) : base(kind)
		{
			_operations = Check.IsNotNullOrEmpty(filters, nameof(filters)).ToList();
		}

		public override T Accept<T>(FilterOperationVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
