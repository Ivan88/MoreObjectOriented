using System;

namespace Loop
{
	public class ProportionelaPainter : IPainter
	{
		public TimeSpan TimePerSqMeter { get; set; }
		public double DollarsPerHour { get; set; }

		public bool IsAvailable => throw new NotImplementedException();

		public double CalculatePrice(double sqMeters) =>
			this.CalculateTime(sqMeters).TotalHours * this.DollarsPerHour;

		public TimeSpan CalculateTime(double sqMeters) =>
			TimeSpan.FromHours(this.TimePerSqMeter.TotalHours * sqMeters);
	}
}