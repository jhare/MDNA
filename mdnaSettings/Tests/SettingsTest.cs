using System;
using NUnit.Framework;

namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for SettingsTest.
	/// </summary>
	[TestFixture]
	public class SettingsTest
	{
		#region Data Members
		// For testing two settings
		private int m_numTestSettings;
		private string m_settingName;
		private string m_settingCompany;
		private string m_settingSalary;

		private string m_settingNameValue;
		private string m_settingCompanyValue;
		private string m_settingSalaryValue;

        mdnaSettings.Settings settings;

		#endregion

		// Setup not related to fixtures.
		public SettingsTest()
		{
			
		}


		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			m_numTestSettings = 3;
			m_settingName = "Name";
			m_settingCompany = "Company";
			m_settingSalary = "Salary";

			m_settingNameValue = "Joe";
			m_settingCompanyValue = "USGS";
			m_settingSalaryValue = "1,000,000";
		
			settings = new Settings();
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}
		#endregion

		#region Tests
		
		[Test]
		public void State_ObjectIsInitiallyEmpty()
		{
			
		}
		
		#endregion

	}
}
