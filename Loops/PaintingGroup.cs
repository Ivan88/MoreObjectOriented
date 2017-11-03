using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops
{
	public class CompositePainter<TPainter> : IPainter
		where TPainter : IPainter
	{
		private IEnumerable<TPainter> Painters { get; }

		private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

		public bool IsAvailable => this.Painters.Any(x => x.IsAvailable);

		public CompositePainter(IEnumerable<TPainter> painters,
								Func<double, IEnumerable<TPainter>, IPainter> reduce)
		{
			this.Painters = painters.ToList();
			this.Reduce = reduce;
		}

		public TimeSpan CalculateTime(double sqMeters) =>
			this.Reduce(sqMeters, this.Painters).CalculateTime(sqMeters);

		public double CalculatePrice(double sqMeters) =>
			this.Reduce(sqMeters, this.Painters).CalculatePrice(sqMeters);
	}
}
