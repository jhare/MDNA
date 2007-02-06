using System;
using NUnit.Framework;
using System.IO;
using System.Xml;


namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for SettingsFileTest.
	/// </summary>
	[TestFixture]
	[Category("Settings")]
	public class SettingsFileTest
	{
		#region Data Members
		private string baseXMLFilePath;
		#endregion

		public SettingsFileTest()
		{
			
		}

		#region Helper Functions
		public bool FilesAreEqual( string path1, string path2 )
		{
			// Wow, this couldn't have been more simple.
			StreamReader stream1 = new StreamReader( path1 );
			StreamReader stream2 = new StreamReader( path2 );

			string file1 = stream1.ReadToEnd();
			string file2 = stream2.ReadToEnd();

			if( file1 == file2 )
			{
				return( true );
			}
			else
			{
				return( false );
			}
		}
		#endregion

		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			baseXMLFilePath = "BaseSettingsFile.xml";
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}
		#endregion

		#region Tests
		[Test]
		public void Create_SetUpABaseXMLFile()
		{
			string filePath = "temp.xml";
			mdnaSettings.SettingsFile temp = new mdnaSettings.SettingsFile( filePath );
		
			Assert.AreEqual( true, FilesAreEqual( filePath, baseXMLFilePath ) );
		}
		#endregion
	}
}
