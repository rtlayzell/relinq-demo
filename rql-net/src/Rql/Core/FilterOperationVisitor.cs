using System;

namespace Rql.Core
{
	public class FilterOperationVisitor<T>
	{
		public virtual T Visit(CompositeFilterOperation composite)
		{
			throw new NotImplementedException();
		}

		public virtual T Visit(SimpleFilterOperation operation)
		{
			throw new NotImplementedException();
		}
	}
}
