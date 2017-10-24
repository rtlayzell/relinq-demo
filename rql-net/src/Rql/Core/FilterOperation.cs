using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rql.Core
{
	public abstract class FilterOperation
	{
		private readonly FilterOperationKind _kind;

		public virtual FilterOperationKind Kind
		{
			get { return _kind; }
		}

		protected FilterOperation(FilterOperationKind kind)
		{
			Debug.Assert(Enum.IsDefined(typeof(FilterOperationKind), kind));
			_kind = kind;
		}

		public abstract T Accept<T>(FilterOperationVisitor<T> visitor);


		public static CompositeFilterOperation Or(params FilterOperation[] filters) => new CompositeFilterOperation(FilterOperationKind.Or, filters);
		public static CompositeFilterOperation And(params FilterOperation[] filters) => new CompositeFilterOperation(FilterOperationKind.And, filters);

		public static CompositeFilterOperation Or(IEnumerable<FilterOperation> filters) => new CompositeFilterOperation(FilterOperationKind.Or, filters);
		public static CompositeFilterOperation And(IEnumerable<FilterOperation> filters) => new CompositeFilterOperation(FilterOperationKind.And, filters);

		public static SimpleFilterOperation In(string propertyName, IEnumerable<object> values) => new SimpleFilterOperation(FilterOperationKind.In, propertyName, values);
		public static SimpleFilterOperation NotIn(string propertyName, IEnumerable<object> values) => new SimpleFilterOperation(FilterOperationKind.NotIn, propertyName, values);
		public static SimpleFilterOperation Equal(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.Equal, propertyName, value);
		public static SimpleFilterOperation NotEqual(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.NotEqual, propertyName, value);
		public static SimpleFilterOperation LessThan(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.LessThan, propertyName, value);
		public static SimpleFilterOperation GreaterThan(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.GreaterThan, propertyName, value);
		public static SimpleFilterOperation LessThanOrEqual(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.LessThanOrEqual, propertyName, value);
		public static SimpleFilterOperation GreaterThanOrEqual(string propertyName, object value) => new SimpleFilterOperation(FilterOperationKind.GreaterThanOrEqual, propertyName, value);
	}
}
