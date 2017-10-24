namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Enumeration of the kinds of query nodes.
	/// </summary>
	public enum QueryNodeKind
	{
		/// <summary> 
		/// No query node kind... the default value.
		/// </summary>
		None = 0,

		/// <summary>
		/// Node used to represent a constant value.
		/// </summary>
		Constant = 1,

		/// <summary>
		/// Node used to represent a unary operation.
		/// </summary>
		UnaryOperator = 2,

		/// <summary>
		/// Node used to represent a binary operation.
		/// </summary>
		BinaryOperator = 3,
	}
}
