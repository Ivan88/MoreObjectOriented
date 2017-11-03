using System;

namespace Loops
{
	public interface IPainter
	{
		bool IsAvailable { get; }
		TimeSpan CalculateTime(double sqMeters);
		double CalculatePrice(double sqMeters);
	}
}
