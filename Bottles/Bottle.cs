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

	    public void PourFrom(Bottle b)
	    {
		    Volume = (Volume + b.Volume);
		    if (Volume > Capacity)
			    Volume = Capacity;
			b.Volume = Volume % Capacity;
			
	    }
	}

	public class BottleSolver
	{
		public string Solve(int capacityBottleA, int capacityBottleB, int desiredVolume)
		{
			var bottleA = new Bottle {Capacity = capacityBottleA};
			var bottleB = new Bottle {Capacity = capacityBottleB};


			return string.Empty;
		}
	}
}
