using System;

namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Abstract base class of visitors used to walk the semantic 
	/// tree structure of <see cref="QueryNode"/>s.
	/// </summary>
	/// <typeparam name="TResult">Type produced by visitation.</typeparam>
	public abstract class QueryNodeVisitor<TResult>
	{
		/// <summary>
		/// Visit a <see cref="BinaryOperatorNode"/>.	
		/// </summary>
		/// <param name="node">The node to visit.</param>
		/// <returns>Defined by implementation.</returns>
		public virtual TResult Visit(BinaryOperatorNode node)
		{
			throw NotSupported(nameof(BinaryOperatorNode));
		}

		/// <summary>
		/// Visit a <see cref="ConstantNode"/>
		/// </summary>
		/// <param name="node">The node to visit.</param>
		/// <returns>Defined by implementation.</returns>
		public virtual TResult Visit(ConstantNode node)
		{
			throw NotSupported(nameof(ConstantNode));
		}


		private static Exception NotSupported(string nodeName)
		{
			return new NotSupportedException(nodeName + " not supported.");
		}
	}
}