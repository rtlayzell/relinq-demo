using Remotion.Linq;
using Rql.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rql.Linq
{
	internal class RqlQueryExecutor : IQueryExecutor
	{
		private readonly Uri _uri;
		private readonly IHttpClient _client;

		public RqlQueryExecutor(Uri uri, IHttpClient client)
		{
			Check.IsNotNull(uri, nameof(uri));
			//Check.IsNotNull(client, nameof(client));

			_uri = uri;
			_client = client;
		}

		public T ExecuteScalar<T>(QueryModel queryModel)
		{
			return ExecuteCollection<T>(queryModel).Single();
		}

		public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
		{
			return returnDefaultWhenEmpty
				? ExecuteCollection<T>(queryModel).SingleOrDefault()
				: ExecuteCollection<T>(queryModel).Single();
		}

		public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
		{
			var query = RqlQueryModelVisitor.GenerateRqlQuery(queryModel);
			
			// TODO: Send query to http client.

			throw new NotImplementedException();
		}
	}
}
