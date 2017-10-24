using System;
using System.Collections.Generic;
using System.Text;

namespace Rql.Parser.SemanticAnalysis
{
	/// <summary>
	/// Query node representing a binary operation.
	/// </summary>
	public sealed class BinaryOperatorNode : SingleValueNode
	{
		/// <summary>
		/// The operator represented by this node.
		/// </summary>
		private readonly BinaryOperatorKind _operatorKind;

		/// <summary>
		/// The left operand of the binary operation.
		/// </summary>
		private readonly SingleValueNode _left;

		/// <summary>
		/// The right operand of the binary operation.
		/// </summary>
		private readonly SingleValueNode _right;


		/// <summary>
		/// Gets the kind of this node.
		/// </summary>
		public override QueryNodeKind Kind => QueryNodeKind.BinaryOperator;

		/// <summary>
		/// Gets the kind of binary operation represented by this node.
		/// </summary>
		public BinaryOperatorKind OperatorKind
		{
			get { return _operatorKind; }
		}

		/// <summary>
		/// Gets the left operand of the binary operation.
		/// </summary>
		public SingleValueNode Left
		{
			get { return _left; }
		}

		/// <summary>
		/// Gets the right operand of the binary operation.
		/// </summary>
		public SingleValueNode Right
		{
			get { return _right; }
		}

		/// <summary>
		/// Initializes a new instance of <see cref="BinaryOperatorNode"/> with the specified 
		/// <see cref="BinaryOperatorKind"/>, left, and right <see cref="SingleValueNode"/>s.
		/// </summary>
		/// <param name="operatorKind">The binary operator kind.</param>
		/// <param name="left">The left operand.</param>
		/// <param name="right">The right operand.</param>
		/// <exception cref="System.ArgumentNullException">Throws if <paramref name="left"/> or <paramref name="right"/> are null.</exception>
		public BinaryOperatorNode(BinaryOperatorKind operatorKind, SingleValueNode left, SingleValueNode right)
		{
			Check.IsNotNull(left, nameof(left));
			Check.IsNotNull(right, nameof(right));
			_operatorKind = operatorKind;
			_left = left;
			_right = right;
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
