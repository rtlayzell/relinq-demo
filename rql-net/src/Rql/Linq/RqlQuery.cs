using Remotion.Linq;
using Rql.Core;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Remotion.Linq.Parsing.Structure;

namespace Rql.Linq
{
	public class RqlQuery<TResult> : QueryableBase<TResult>
	{
		private readonly Uri _resourceUri;

		private static IQueryExecutor CreateExecutor(Uri uri, IHttpClient client)
		{
			return new RqlQueryExecutor(uri, client);
		}

		public Uri ResourceUri
		{
			get { return _resourceUri; }
		}

		public RqlQuery(string resourceUri) : this(new Uri(resourceUri, UriKind.RelativeOrAbsolute))
		{
		}

		public RqlQuery(Uri resourceUri) : base(QueryParser.CreateDefault(), CreateExecutor(resourceUri, null))
		{
			_resourceUri = resourceUri;
		}

		/// <summary>
		///		Required by the LINQ/Re-linq infrastructure.
		/// </summary>
		public RqlQuery(IQueryProvider queryProvider, Expression expression) : base(queryProvider, expression)
		{
		}
	}
}
