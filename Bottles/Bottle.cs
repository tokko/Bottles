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

			return Solve(solution, 0, 8, bottleA, bottleB, desiredVolume);
		}

		private static List<string> Solve(string path, int depth, int limit, Bottle bottleA, Bottle bottleB, int desiredVolume)
		{
			if (bottleA.Volume == desiredVolume) return new List<string> {path + "A;"};
			if (bottleB.Volume == desiredVolume) return new List<string> {path + "B;"};
			if (depth > limit) return new List<string>{path + ";"};
			var actions = new Dictionary<string, Action>
			{
				{"A -> B ", () => bottleA.PourInto(bottleB)},
				{"B -> A ", () => bottleB.PourInto(bottleA)},
				{"E(A) ", bottleA.Empty},
				{"E(B) ", bottleB.Empty},
				{"F(A) ", bottleA.Fill},
				{"F(B) ", bottleB.Fill},
			};
			PruneActions(bottleA, bottleB, actions);
			return actions.Select(action =>
			{
				action.Value();
				var s = Solve(path + action.Key, depth+1, limit, bottleA, bottleB, desiredVolume);
				return s;
			}).Aggregate(new List<string>(), (x, y) => x.Concat(y).ToList()).Where(s => s.EndsWith("B;") || s.EndsWith("A;")).ToList();
		}

		private static void PruneActions(Bottle bottleA, Bottle bottleB, Dictionary<string, Action> actions)
		{
			if (bottleA.IsEmpty())
			{
				actions.Remove("A -> B ");
				actions.Remove("E(A) ");
			}
			if (bottleB.IsEmpty())
			{
				actions.Remove("B -> A ");
				actions.Remove("E(B) ");
			}
			if (bottleA.IsFull())
			{
				actions.Remove("B -> A ");
				actions.Remove("F(A) ");
			}
			if (bottleB.IsFull())
			{
				actions.Remove("A -> B ");
				actions.Remove("F(B) ");
			}
		}
	}
}
