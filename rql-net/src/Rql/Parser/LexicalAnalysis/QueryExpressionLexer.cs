using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Rql.Parser.LexicalAnalysis
{
	internal enum QueryTokenKind
	{
		None = 0,
		Name = 1,
		Dollar = 2,
		Equal = 3,
		LeftParen = 4,
		RightParen = 5,
		Ampersand = 6,
		Pipe = 7,
	}

	internal abstract class QueryToken
	{
		public abstract QueryTokenKind Kind { get; }
	}

    internal class QueryExpressionLexer
    {
		internal QueryToken PeekNext()
		{
			throw new NotImplementedException();
		}

		internal QueryToken NextToken()
		{
			throw new NotImplementedException();
		}
    }
}
