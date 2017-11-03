
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
	public class Painters
	{
		private IEnumerable<IPainter> ContainedPainters { get; }

		public Painters(IEnumerable<IPainter> painters)
		{
			ContainedPainters = painters.ToList();
		}

		public Painters GetAvailable()
		{
			if (this.ContainedPainters.All(x => x.IsAvailable))
				return this;
			return new Painters(this.ContainedPainters.Where(x => x.IsAvailable));
		}

		public IPainter GetChipestOne(double sqMeters)
		{
			return this.ContainedPainters.WithMinimum(x => x.CalculatePrice(sqMeters));
		}

		public IPainter GetFastestOne(double sqMeters)
		{
			return this.ContainedPainters.WithMinimum(x => x.CalculateTime(sqMeters));
		}
	}
}
