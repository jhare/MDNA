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
		private int m_numSettings;
		private string m_settingName;
		private string m_settingCompany;
		private string m_settingSalary;

		private string m_settingNameValue;
		private string m_settingCompanyValue;
		private string m_settingSalaryValue;

        // For testing two vars
		private int m_numVars;
		private string m_varName;
		private string m_varCompany;
		private string m_varTenure;

		private string m_varNameValue;
		private string m_varCompanyValue;
		private string m_varTenureValue;

		mdnaSettings.Settings settings;
		#endregion

		// Setup not related to fixtures.
		public SettingsTest()
		{
			
		}

		[TestFixtureSetUp]
		public void Setup()
		{
			m_numSettings = 3;
			m_settingName = "Name";
			m_settingCompany = "Company";
			m_settingSalary = "Salary";

			m_settingNameValue = "Joe";
			m_settingCompanyValue = "USGS";
			m_settingSalaryValue = "1,000,000";

			m_numVars = 3;
			m_varName = "Name";
			m_varCompany = "Company";
			m_varTenure = "Tenure";

			m_varNameValue = "McMillin";
			m_varCompanyValue = "UMR";
			m_varTenureValue = "True";
		
			settings = new Settings();
		}

		[TestFixtureTearDown]
		public void Teardown()
		{

		}

		[Test]
		public void NewObjectUninitialized()
		{
			Assert.AreNotEqual( m_numSettings, settings.GetNumSettings() );
			Assert.AreNotEqual( m_numVars, settings.GetNumVars() );
		}

		[Test]
		public void SettingCountRange()
		{
			Assert.Greater( settings.GetNumSettings(), -1 );
		}

		[Test]
		public void VarCountRange()
		{
			Assert.Greater( settings.GetNumVars(), -1 );
		}

		[Test]
		public void SetValidSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void GetValidSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void GetInvalidSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void UnsetSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void SetValidVar()
		{
			Assert.Fail( "Test Not Implemented" );			
		}

		[Test]
		public void GetValidVar()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void GetInvalidVar()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void UnsetVar()
		{
			Assert.Fail( "Test Not Implemented" );
		}	

	}
}
