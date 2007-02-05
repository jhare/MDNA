using System;
using NUnit.Framework;

namespace mdnaSettings.Test
{
	/// <summary>
	/// Summary description for SettingsFileTest.
	/// </summary>
	[TestFixture]
	public class SettingsFileTest
	{
		#region Data Members
		private mdnaSettings.SettingsFile file;
		private mdnaSettings.SettingsFile correctTemplate;

		private string correctFilePath;
		private string tempFilePath;

		private mdnaSettings.Settings correct;
		private mdnaSettings.Settings temp;
		#endregion

		// Set up things that AREN'T part of the initialization
		// having to do with test data.
		public SettingsFileTest()
		{
			correctFilePath = "./testdata/mdna.xml";
			tempFilePath = "./testdata/temp.xml";
		}

		[TestFixtureSetup]
		public void Setup
		{
			correctTemplate.Load( correctFilePath );
		}

		[TestFixtureTeardown]
		public void TearDown
		{

		}

		[Test]
		public void LoadFile()
		{
			
		}

		[Test]
		public void SaveFile()
		{

		}

		[Test]
		public void WriteSetting()
		{
		}

		[Test]
		public void DeleteSetting()
		{

		}

		[Test]
		public void WriteVar()
		{

		}

		[Test]
		public void DeleteVar()
		{

		}
	}
}
