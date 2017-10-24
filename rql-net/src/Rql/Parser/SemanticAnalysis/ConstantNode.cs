namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Query node representing a primitive value.
	/// </summary>
	public class ConstantNode : SingleValueNode
	{
		/// <summary>
		/// The constant value.
		/// </summary>
		private readonly object _constantValue;

		/// <summary>
		/// The literal text of the constant value.
		/// </summary>
		private readonly string _literalText;

		/// <summary>
		/// Gets the kind of this node.
		/// </summary>
		public override QueryNodeKind Kind => QueryNodeKind.Constant;

		/// <summary>
		/// Gets the constant value of this node.
		/// </summary>
		public object Value
		{
			get { return _constantValue; }
		}
		
		/// <summary>
		/// Gets the literal text of the value of this node.8
		/// </summary>
		public string LiteralText
		{
			get { return _literalText; }
		}

		/// <summary>
		/// Initializes a new instance of <see cref="ConstantNode"/> with the 
		/// specified <paramref name="constantValue"/>, and <paramref name="literalText"/>
		/// </summary>
		/// <param name="constantValue">The primitive value.</param>
		/// <param name="literalText">The literal text of the primitive value.</param>
		public ConstantNode(object constantValue, string literalText)
		{
			Check.IsNotNullOrEmpty(literalText, nameof(literalText));
			_literalText = literalText;
			_constantValue = constantValue;
		}

		/// <summary>
		/// Accept a <see cref="QueryNodeVisitor{T}"/> that walks the tree of <see cref="QueryNode"/>s.
		/// </summary>
		/// <typeparam name="TResult">The type returned by the visitor.</typeparam>
		/// <param name="visitor">A visitor implementation used to walk the <see cref="QueryNode"/> tree.</param>
		/// <returns>An object whose type is determined by the type parameter <typeparamref name="TResult"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Throws if the <paramref name="visitor"/> argument is null.</exception>
		public override TResult Accept<TResult>(QueryNodeVisitor<TResult> visitor)
		{
			Check.IsNotNull(visitor, nameof(visitor));
			return visitor.Visit(this);
		}
	}
}
