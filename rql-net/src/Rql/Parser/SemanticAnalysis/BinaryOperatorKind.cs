namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Enumeration of the kinds of binary operations.
	/// </summary>
	public enum BinaryOperatorKind
	{
		/// <summary>
		/// Represents a logical OR binary operation.
		/// </summary>
		Or,
		
		/// <summary>
		/// Represents a logical AND binary operation.
		/// </summary>
		And,

		/// <summary>
		/// Represents a equality operation.
		/// </summary>
		Equal,

		/// <summary>
		/// Represents an inequality operation.
		/// </summary>
		NotEqual,

		/// <summary>
		/// Represents a less-than operation.
		/// </summary>
		LessThan,

		/// <summary>
		/// Represents a greater-than operation.
		/// </summary>
		GreaterThan,

		/// <summary>
		/// Represents a less-than or equal operation.
		/// </summary>
		LessThanOrEqual,

		/// <summary>
		/// Represents a greater-than or equal operation.
		/// </summary>
		GreaterThanOrEqual,
	}
}
