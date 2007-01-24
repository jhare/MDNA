using System;
using NUnit.Framework;

using mdna.Source;
namespace mdna.Test
{
	/// <summary>
	/// Unit tests for application core.
	/// </summary>
	[TestFixture]
	public class CoreTest
	{
		mdna.Source.Core.Core core1;
		public CoreTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[Test]
		public void testCore()
		{
			Assert.AreEqual( 4, 1 ); 
		}
	}
}
