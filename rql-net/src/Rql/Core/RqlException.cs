using System;
using System.Collections.Generic;
using System.Text;

namespace Rql.Core
{
	[Serializable]
	public class RqlException : Exception
	{
		public RqlException() { }
		public RqlException(string message) : base(message) { }
		public RqlException(string message, Exception inner) : base(message, inner) { }
		protected RqlException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

