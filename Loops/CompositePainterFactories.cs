using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops
{
	public class CompositePainterFactories
	{
		public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
			new CompositePainter<IPainter>(painters,
				(sqMeters, sequence) => new Painters(sequence).GetAvailable().GetChipestOne(sqMeters));

		public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
			new CompositePainter<IPainter>(painters,
				(sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));

		public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters) =>
			new CompositePainter<ProportionalPainter>(painters, (sqMeters, sequence) =>
			{
				var time =
					TimeSpan.FromHours(
						1 /
						sequence
							.Where(x => x.IsAvailable)
							.Select(x => 1 / x.CalculateTime(sqMeters).TotalHours)
							.Sum());

				var cost =
					sequence
						.Where(x => x.IsAvailable)
						.Select(x =>
									x.CalculatePrice(sqMeters) /
									x.CalculateTime(sqMeters).TotalHours * time.TotalHours)
						.Sum();

				return new ProportionalPainter()
				{
					TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
					DollarsPerHour = cost / time.TotalHours
				};
			});
	}
}
