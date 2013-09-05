using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Run00.Genesis
{
	public static class ExtensionsForEnumerableOfT
	{
		/// <summary>
		/// Gets a random item from the Enumerable.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public static TResult Random<TResult>(this IEnumerable<TResult> source)
		{
			if (source.Count() == 0)
				return default(TResult);

			var index = _rand.Next(source.Count());
			return source.ElementAt(index);
		}

		private static readonly Random _rand = new Random();
	}
}
