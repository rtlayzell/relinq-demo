using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rql.Parser.LexicalAnalysis
{
	internal interface ILexerRule
	{
		bool TryMatch(TextReader reader, out QueryToken token);
	}

	internal class Lexer
	{
		private readonly TextReader _reader;
		private readonly IEnumerable<ILexerRule> _rules;

		public IEnumerable<QueryToken> Tokens
		{
			get { return EnumerateTokens(); }
		}

		public Lexer(string input, params ILexerRule[] rules) : this(input, (IEnumerable<ILexerRule>)rules)
		{
		}

		public Lexer(string input, IEnumerable<ILexerRule> rules)
		{
			Check.IsNotNull(input, nameof(input));
			Check.IsNotNull(input, nameof(rules));

			_reader = new StringReader(input);
			_rules = rules.ToList();
		}

		private IEnumerable<QueryToken> EnumerateTokens()
		{
			bool match = false;
			do
			{
				match = false;
				foreach (var rule in _rules)
				{
					QueryToken token;
					if (rule.TryMatch(_reader, out token))
					{
						match = true;
						yield return token;
					}
				}
			}
			while (match && _reader.Peek() >= 0);
		}
	}
}
