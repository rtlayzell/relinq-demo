using System;
using System.Collections.Generic;
using System.Text;

namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Abstract base class of all semantic query nodes.
	/// </summary>
	public abstract class QueryNode
	{
		/// <summary>
		/// Gets the kind of this node.
		/// </summary>
		public abstract QueryNodeKind Kind { get; }

		/// <summary>
		/// Accept a <see cref="QueryNodeVisitor{T}"/> that walks the tree of <see cref="QueryNode"/>s.
		/// </summary>
		/// <typeparam name="TResult">The type returned by the visitor.</typeparam>
		/// <param name="visitor">A visitor implementation used to walk the <see cref="QueryNode"/> tree.</param>
		/// <returns>An object whose type is determined by the type parameter <typeparamref name="TResult"/>.</returns>
		public abstract TResult Accept<TResult>(QueryNodeVisitor<TResult> visitor);

		/// <summary>
		/// Returns the textual representation of this <see cref="QueryNode"/>.
		/// </summary>
		/// <returns>A string representing the equivalent <see cref="QueryNode"/>.</returns>
		public sealed override string ToString()
		{
			var visitor = new RqlGeneratorQueryNodeVisitor();
			return Accept(visitor);
		}
	}
}
