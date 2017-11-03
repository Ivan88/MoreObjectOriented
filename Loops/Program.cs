using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops
{
	class Program
	{
		static void Main(string[] args)
		{
			var painters = new ProportionalPainter[10];

			var painter = CompositePainterFactories.CreateCheapestSelector(painters);
		}
	}
}