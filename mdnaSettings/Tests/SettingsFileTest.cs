using System;
using NUnit.Framework;
using System.IO;
using System.Xml;
using System.Windows.Forms;


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
		private string XMLFileWithValidEntries;
		#endregion

		public SettingsFileTest()
		{
			
		}


		#region Helper Functions
		public bool FilesAreEqual( string path1, string path2 )
		{
			// If one of the files aren't there then shit happens.
			try
			{
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
			catch( Exception ex )
			{
				MessageBox.Show( "Exception Caught: " + ex.Message );
				return( false );
			}

		}
		#endregion

		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			baseXMLFilePath = "BaseSettingsFile.xml";
			XMLFileWithValidEntries = "WithValidEntries.xml";
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
			string filePath = "Create_SetUpABaseXMLFile.xml";
			mdnaSettings.SettingsFile temp = new mdnaSettings.SettingsFile( filePath );
		
			Assert.AreEqual( true, FilesAreEqual( filePath, baseXMLFilePath ) );
		}


		[Test]
		public void Create_UseTheActualFunction()
		{
			string filePath = "Create_UseTheActualFunction.xml";
			mdnaSettings.SettingsFile temp = new mdnaSettings.SettingsFile();

			temp.Create( filePath );

			Assert.AreEqual( true, FilesAreEqual( filePath, baseXMLFilePath ) );
		}


		[Test]
		public void Save_WithAValidSettingsObject()
		{
			bool saveResult;
			string filePath = "Save_WithAValidSettingsObject.xml";
			mdnaSettings.SettingsFile file = new mdnaSettings.SettingsFile( filePath );
			mdnaSettings.Settings settings = new mdnaSettings.Settings();

			settings.Category = "setting";
			settings.Add( "foo", "bar" );
			settings.Add( "laverne", "shirley" );

			saveResult = file.Save( settings );

			Assert.AreEqual( true, saveResult );
			Assert.AreEqual( true, FilesAreEqual( filePath, XMLFileWithValidEntries ) );           
		}


		#endregion
	}
}
