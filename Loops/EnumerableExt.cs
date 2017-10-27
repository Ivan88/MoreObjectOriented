using System;
using System.Collections.Generic;
using System.Linq;

namespace Loop
{
	public static class EnumerableExt
	{
		public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
			where T : class
			where TKey : IComparable<TKey> =>
				sequence
					.Select(x => Tuple.Create(x, criterion(x)))
					.Aggregate((Tuple<T, TKey>)null,
						(best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
					.Item1;
	}
}