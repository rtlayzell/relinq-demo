using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rql
{
	internal static class Check
	{
		public static T IsNotNull<T>(T value, string paramName) where T : class
		{
			if (value == null)
				throw new ArgumentNullException(paramName);

			return value;
		}

		public static TEnumerable IsNotNullOrEmpty<TEnumerable>(TEnumerable collection, string paramName)
			where TEnumerable : IEnumerable
		{
			if (collection == null)
				throw new ArgumentNullException(paramName);

			var enumerator = collection.GetEnumerator();
			if (!enumerator.MoveNext())
				throw new ArgumentException(paramName);

			return collection;
		}

		internal static TString IsNotNullOrWhiteSpace<TString>(TString str, string paramName) where TString : IEnumerable<char>
		{
			if (str == null)
				throw new ArgumentNullException(paramName);

			if (str.All(ch => Char.IsWhiteSpace(ch)))
				throw new ArgumentException(paramName);

			return str;
		}
	}
}
