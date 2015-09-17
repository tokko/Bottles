using System;
using Bottles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BottlesTest
{
	[TestClass]
	public class BottlesTest
	{
		[TestMethod]
		public void PourFrom_LargeToSmallNoOverflow_VolumeIsCorrect()
		{
			var bottleA = new Bottle {Capacity = 5, Volume = 3};
			var bottleB = new Bottle {Capacity = 3};

			bottleA.PourInto(bottleB);

			Assert.That(bottleA.Volume, Is.EqualTo(0));
			Assert.That(bottleB.Volume, Is.EqualTo(3));
		}
	}
}
