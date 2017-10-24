using Rql.Core;
using System;

namespace Rql.Parser
{
	public sealed class RqlUriParser
	{
		private readonly Uri _resourceUri;
		private readonly string _originalQuery;

		/// <summary>
		/// Absolute URI of the resource.
		/// </summary>
		public Uri ResourceUri
		{
			get { return _resourceUri; }
		}

		public RqlUriParser(string uri) : this(new Uri(uri))
		{
		}

		public RqlUriParser(Uri uri)
		{
			Check.IsNotNull(uri, nameof(uri));

			var ub = new UriBuilder(uri);
			_originalQuery = uri.Query.TrimStart('?');
			_resourceUri = new Uri(uri.GetLeftPart(UriPartial.Path).Trim('/'));
		}

		/// <summary>
		/// Parse a full URI into its contingent parts with semantic meaning attached to each part. 
		/// See <see cref="RqlUri"/>.
		/// </summary>
		/// <returns>An <see cref="RqlUri"/> representing the full URI.</returns>
		public RqlUri ParseUri()
		{
			throw new NotImplementedException();
		}

		public FilterClause ParseFilters()
		{
			throw new NotImplementedException();
		}

		public OrderByClause ParseOrderBy()
		{
			throw new NotImplementedException();
		}

		public void ParseCount()
		{
			throw new NotImplementedException();
		}

		public long? ParseSkip()
		{
			throw new NotImplementedException();
		}

		public long? ParseTop()
		{
			throw new NotImplementedException();
		}
	}
}
