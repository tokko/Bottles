using System;
using Bottles;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BottlesTest
{
	[TestFixture]
	public class BottlesTest
	{
		[Test]
		public void PourFrom_LargeToSmallNoOverflow_VolumeIsCorrect()
		{
			var bottleA = new Bottle {Capacity = 5, Volume = 3};
			var bottleB = new Bottle {Capacity = 3};

			bottleA.PourInto(bottleB);

			Assert.That(bottleA.Volume, Is.EqualTo(0));
			Assert.That(bottleB.Volume, Is.EqualTo(3));
		}

		[Test]
		public void PourFrom_LargeToSmallOverflow_VolumeIsCorrect()
		{
			var bottleA = new Bottle {Capacity = 5, Volume = 5};
			var bottleB = new Bottle {Capacity = 3};

			bottleA.PourInto(bottleB);

			Assert.That(bottleA.Volume, Is.EqualTo(2));
			Assert.That(bottleB.Volume, Is.EqualTo(3));
		}

		[Test]
		public void PourFrom_SmallToLargeNoOverflow_VolumeIsCorrect()
		{
			var bottleA = new Bottle {Capacity = 5, Volume = 0};
			var bottleB = new Bottle {Capacity = 3, Volume = 3};

			bottleB.PourInto(bottleA);

			Assert.That(bottleA.Volume, Is.EqualTo(3));
			Assert.That(bottleB.Volume, Is.EqualTo(0));
		}

		[Test]
		public void PourFrom_SmallToLargeOverflow_VolumeIsCorrect()
		{
			var bottleA = new Bottle {Capacity = 5, Volume = 3};
			var bottleB = new Bottle {Capacity = 3, Volume = 3};

			bottleB.PourInto(bottleA);

			Assert.That(bottleA.Volume, Is.EqualTo(5));
			Assert.That(bottleB.Volume, Is.EqualTo(1));
		}

		[Test]
		[Ignore]
		public void Solve_3And5LitreContainers4LitreDesired_ReturnsCorrectPaths()
		{
			var solution = BottleSolver.Solve(5, 3, 1);

			Assert.NotNull(solution);
			Assert.True(solution.Count > 0);
		}
	}



}
