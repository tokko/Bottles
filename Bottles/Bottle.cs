using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bottles
{
	[DebuggerDisplay("Volume: {Volume}")]
    public class Bottle
    {
	    public int Capacity { get; set; }
	    public int Volume { get; set; }

		public Bottle()
		{
		}
		public Bottle(Bottle b)
		{
			Capacity = b.Capacity;
			Volume = b.Volume;
		}
	    public void Fill()
	    {
		    Volume = Capacity;
	    }

	    public void Empty()
	    {
		    Volume = 0;
	    }

		public bool IsEmpty()
		{
			return Volume == 0;
		}

		public bool IsFull()
		{
			return Volume == Capacity;
		}
	    public void PourInto(Bottle b)
	    {
		    var free = b.Capacity - b.Volume;
		    if (free >= Volume)
		    {
			    b.Volume += Volume;
			    Volume = 0;
			    return;
		    }
		    b.Volume = b.Capacity;
		    Volume -= free;
	    }
	}

	public class BottleSolver
	{
		public static List<string> Solve(int capacityBottleA, int capacityBottleB, int desiredVolume)
		{
			var bottleA = new Bottle {Capacity = capacityBottleA};
			var bottleB = new Bottle {Capacity = capacityBottleB};

			var solution = string.Empty;
			for (var i = 1; i < 8; i++)
			{
				var s = Solve(solution, 0, i, bottleA, bottleB, desiredVolume);
				if (s.Any()) return s;
			}
			return new List<string>();
		}

		private static List<string> Solve(string path, int depth, int limit, Bottle bottleA, Bottle bottleB, int desiredVolume)
		{
			if (bottleA.Volume == desiredVolume)
				return new List<string> {path + "A ;"};
			if (bottleB.Volume == desiredVolume)
				return new List<string> {path + "B ;"};
			if (depth > limit)
				return new List<string> { path + ";" };
			var actions = new Dictionary<string, Action<Bottle, Bottle>>
			{
				{"A -> B, ", (a, b) => a.PourInto(b)},
				{"B -> A, ", (a, b) => b.PourInto(a)},
				{"E(A), ", (a, b) => a.Empty()},
				{"E(B), ", (a, b) => b.Empty()},
				{"F(A), ", (a, b) => a.Fill()},
				{"F(B), ", (a, b) => b.Fill()},
			};
			PruneActions(bottleA, bottleB, actions);
			return actions.Select(action =>
			{
				var newBottleA = new Bottle(bottleA);
				var newBottleB = new Bottle(bottleB);
				action.Value(newBottleA, newBottleB);
				var s = Solve(path + action.Key, depth+1, limit, newBottleA, newBottleB, desiredVolume);
				return s;
			}).Aggregate(new List<string>(), (x, y) => x.Concat(y).ToList()).Where(s => s.EndsWith("A ;") || s.EndsWith("B ;")).ToList();
		}

		private static void PruneActions(Bottle bottleA, Bottle bottleB, Dictionary<string, Action<Bottle, Bottle>> actions)
		{
			if (bottleA.IsEmpty())
			{
				actions.Remove("A -> B, ");
				actions.Remove("E(A), ");
			}
			if (bottleB.IsEmpty())
			{
				actions.Remove("B -> A, ");
				actions.Remove("E(B), ");
			}
			if (bottleA.IsFull())
			{
				actions.Remove("B -> A, ");
				actions.Remove("F(A), ");
			}
			if (bottleB.IsFull())
			{
				actions.Remove("A -> B, ");
				actions.Remove("F(B), ");
			}
		}
	}
}
