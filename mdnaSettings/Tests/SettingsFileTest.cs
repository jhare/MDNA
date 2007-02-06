using System;
using NUnit.Framework;


namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for SettingsFileTest.
	/// </summary>
	//[TestFixture]
	public class SettingsFileTest
	{
		#region Data Members
		private mdnaSettings.SettingsFile m_file;
		private mdnaSettings.SettingsFile m_correctTemplate;

		private string m_correctFilePath;
		private string m_tempFilePath;

		private mdnaSettings.Settings m_correct;
		private mdnaSettings.Settings m_temp;
		#endregion

		// Set up things that AREN'T part of the initialization
		// having to do with test data.
		public SettingsFileTest()
		{
			
		}

		[TestFixtureSetUp]
		public void SetUp()
		{
			m_correctFilePath = "./testdata/mdna.xml";
			m_tempFilePath = "./testdata/temp.xml";
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}

		[Test]
		public void LoadFile()
		{
			Assert.Fail( "Test Not Implemented" );			
		}

		[Test]
		public void SaveFile()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void WriteSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void DeleteSetting()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void WriteVar()
		{
			Assert.Fail( "Test Not Implemented" );
		}

		[Test]
		public void DeleteVar()
		{
			Assert.Fail( "Test Not Implemented" );
		}
	}
}
