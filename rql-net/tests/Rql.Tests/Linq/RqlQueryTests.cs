using NUnit.Framework;
using Rql.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rql.Tests
{
	public class Email
	{
		public int Id { get; set; }
		public string Sender { get; set; }
	}

	[TestFixture]
	public class RqlQueryTests
	{
		[TestCase]
		public void Where_Single_BinaryExpression()
		{
			var query = new RqlQuery<Email>("/api/emails")
				.Where(x => x.Sender == "reegan.layzell@workshare.com");

			var results = query.ToList();
		}

		[TestCase]
		public void Where_LogicalAnd_BinaryExpressions()
		{
			var query = new RqlQuery<Email>("/api/emails")
				.Where(x => x.Id < 10 && x.Id > 1);

			var results = query.ToList();
		}
	}
}
