using System;
using System.Collections.Generic;
using System.Text;

namespace Rql.Parser.SemanticAnalysis
{
    internal class RqlGeneratorQueryNodeVisitor : QueryNodeVisitor<string>
    {
		public override string Visit(ConstantNode node)
		{
			return node.LiteralText ?? node.Value.ToString();
		}

		public override string Visit(BinaryOperatorNode node)
		{
			switch (node.OperatorKind)
			{
				case BinaryOperatorKind.Or: return $"$or({node.Left}, {String.Join(", ", FlattenBinaryNodes(node.Right))}";
				case BinaryOperatorKind.And: return $"$and({node.Left}, {String.Join(", ", FlattenBinaryNodes(node.Right))}";

				default: throw new RqlParserException();
			}
		}

		private IEnumerable<QueryNode> FlattenBinaryNodes(SingleValueNode node)
		{
			var binNode = node as BinaryOperatorNode;
			if (binNode != null)
			{
				if (binNode.OperatorKind == BinaryOperatorKind.Or ||
					binNode.OperatorKind == BinaryOperatorKind.And)
				{
					foreach (var nestedNode in FlattenBinaryNodes(binNode))
						yield return nestedNode;
				}
				else
				{
					yield return node;
				}
			}
			else
			{
				yield return node;
			}
		}
	}
}
