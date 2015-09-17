using System;
using System.Collections.Generic;

namespace Bottles
{
    public class Bottle
    {
	    public int Capacity { get; set; }
	    public int Volume { get; set; }

	    public void Fill()
	    {
		    Volume = Capacity;
	    }

	    public void Empty()
	    {
		    Volume = 0;
	    }

	    public void PourInto(Bottle b)
	    {
			b.Volume = (b.Volume + Volume);
			if (b.Volume > b.Capacity)
				b.Volume = b.Capacity;
			Volume = b.Volume % b.Capacity;
			
	    }
	}

	public class BottleSolver
	{
		public string Solve(int capacityBottleA, int capacityBottleB, int desiredVolume)
		{
			var bottleA = new Bottle {Capacity = capacityBottleA};
			var bottleB = new Bottle {Capacity = capacityBottleB};

			var solution = string.Empty;

			return string.Empty;
		}

		private string Solve(string path, int depth, int limit, Bottle bottleA, Bottle bottleB, int desiredVolume)
		{
			if (bottleA.Volume == desiredVolume) return " A;";
			if (bottleB.Volume == desiredVolume) return " B;";
			if (depth > limit) return string.Empty;
			var actions = new Dictionary<string, Action>
			{
				//{"a -> b" : () => bottleB.},
			};

			return string.Empty;
		}
	}
}
