using System;
using NUnit.Framework;

namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for SettingsTest.
	/// </summary>
	public class SettingsTest
	{
		#region Data Members
		// For testing two settings
		private string settingName;
		private string settingCompany;

		// For testing two vars
		private string varName;
		private string varCompany;

		mdnaSettings.Settings file;
		#endregion

		// Setup not related to fixtures.
		public SettingsTest()
		{
     		settingName = "Joe";
			settingCompany = "USGS";

			varName = "McMillin";
			varCompany = "UMR";
		}

		[TestFixtureSetUp]
		public void Setup()
		{

		}

		[TestFixtureTearDown]
		public void Teardown()
		{

		}

		[Test]
		public void SetVar()
		{

		}

		[Test]
		public void GetVar()
		{

		}

		[Test]
		public void UnsetVar()
		{

		}

		[Test]
		public void SetSetting()
		{

		}

		[Test]
		public void GetSetting()
		{

		}

		[Test]
		public void UnsetSetting()
		{

		}

	}
}
