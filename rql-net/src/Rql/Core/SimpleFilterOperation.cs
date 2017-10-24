namespace Rql.Core
{
	public class SimpleFilterOperation : FilterOperation
	{
		private readonly string _propertyName;
		private readonly object _value;

		public string PropertyName
		{
			get { return _propertyName; }
		}

		public object Value
		{
			get { return _value; }
		}

		internal SimpleFilterOperation(FilterOperationKind kind, string propertyName, object value) : base(kind)
		{
			_propertyName = Check.IsNotNullOrWhiteSpace(propertyName, nameof(propertyName));
			_value = value;
		}

		public override T Accept<T>(FilterOperationVisitor<T> visitor)
		{
			return visitor.Visit(this);
		}
	}
}
