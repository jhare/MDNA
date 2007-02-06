using System;
using NUnit.Framework;

namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for VariablesTest.
	/// </summary>
	public class VariablesTest
	{

		#region Data Members
		// For testing two vars
		private int m_numTestVars;
		private string m_varName;
		private string m_varCompany;
		private string m_varTenure;

		private string m_varNameValue;
		private string m_varCompanyValue;
		private string m_varTenureValue;
		#endregion

		public VariablesTest()
		{
			
		}

		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			m_numTestVars = 3;
			m_varName = "Name";
			m_varCompany = "Company";
			m_varTenure = "Tenure";

			m_varNameValue = "McMillin";
			m_varCompanyValue = "UMR";
			m_varTenureValue = "True";
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}
		#endregion
	}
}
