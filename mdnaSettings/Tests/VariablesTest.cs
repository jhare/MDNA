using System;
using NUnit.Framework;

namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for VariablesTest.
	/// </summary>
	[TestFixture]
	public class VariablesTest
	{

		#region Data Members
		// For testing two vars
		private int m_numTestVars;
		private string m_varName;
		
		private string m_varNameValue;
		#endregion

		public VariablesTest()
		{
			
		}

		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			m_numTestVars = 1;
			m_varName = "Name";
			m_varNameValue = "McMillin";
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}
		#endregion

		#region Tests

		
		#endregion
	}
}
