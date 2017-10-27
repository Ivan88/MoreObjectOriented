using System;
using System.Collections.Generic;
using System.Linq;

namespace Loop
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		private static IPainter FindCheapestPainter(int sqMeters, IEnumerable<IPainter> painters)
		{
			return painters
				.Where(x => x.IsAvailable)
				.WithMinimum(x => x.CalculatePrice(sqMeters));
		}

		private static IPainter FindFastestPainter(int sqMeters, IEnumerable<IPainter> painters)
		{
			return painters
				.Where(x => x.IsAvailable)
				.WithMinimum(x => x.CalculateTime(sqMeters));
		}

		private static void WorkTogether(int sqMeters, IEnumerable<IPainter> painters)
		{
			var time =
				TimeSpan.FromHours(
					1 /
					painters
						.Where(x => x.IsAvailable)
						.Select(x => 1 / x.CalculateTime(sqMeters).TotalHours)
						.Sum());

			var cost =
				painters
					.Where(x => x.IsAvailable)
					.Select(x =>
								x.CalculatePrice(sqMeters) /
								x.CalculateTime(sqMeters).TotalHours * time.TotalHours)
					.Sum();
		}
	}
}