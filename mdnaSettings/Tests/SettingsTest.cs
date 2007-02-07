using System;
using NUnit.Framework;

namespace mdnaSettings.Tests
{
	/// <summary>
	/// Summary description for SettingsTest.
	/// </summary>
	[TestFixture]
	[Category("Settings")]
	public class SettingsTest
	{
		#region Data Members
		// For testing two settings
		private string m_settingName;
		private string m_settingNameValue;

		#endregion

		// Setup not related to fixtures.
		public SettingsTest()
		{
			
		}

		#region SetUp and TearDown
		[TestFixtureSetUp]
		public void SetUp()
		{
			m_settingName = "Name";
			m_settingNameValue = "Joe";
			
		}

		[TestFixtureTearDown]
		public void TearDown()
		{

		}
		#endregion

		#region Tests
		
		[Test]
		public void Count_NewObjectIsInitiallyEmpty()
		{
			// It would be nice to check for null here, but it is unnecessary.
			mdnaSettings.Settings settings = new mdnaSettings.Settings();
			Assert.AreEqual( 0, settings.Count );
		}


		[Test]
		public void Get_NewObjectReturnsEmptySettings()
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings();
			Assert.AreEqual( "", settings.Get("foo") );
		}


		[Test]
		public void Add_InsertNewSetting()
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings();

			settings.Clear();
			Assert.AreEqual( 0, settings.Count );
			
			settings.Add( m_settingName, m_settingNameValue );

			Assert.AreEqual( settings.Count, 1 );
			Assert.AreEqual( m_settingNameValue, settings.Get( m_settingName ) );
		}


		[Test]
		public void Remove_ClearSettingsAddAnObjectThenRemoveIt( )
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings();

			settings.Clear();
			Assert.AreEqual( 0, settings.Count );

			settings.Add( m_settingName, m_settingNameValue );
			Assert.AreEqual( 1, settings.Count );

			settings.Remove( m_settingName );
			Assert.AreEqual( 0, settings.Count );

			Assert.AreEqual( "", settings.Get( m_settingName ) );
		}


		[Test]
		public void Clear_AddManyKeysThenClear()
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings();

			Assert.AreEqual( 0, settings.Count );

			settings.Add( "foo", "bar" );
			settings.Add( "peanut butter", "jelly" );
			settings.Add( "laverne", "shirley" );

			Assert.AreEqual( 3, settings.Count );
			
			settings.Clear();

			Assert.AreEqual( 0, settings.Count );
		}


		[Test]
		public void Category_TestAccessor()
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings();
			settings.Category = "foo";

			Assert.AreEqual( "foo", settings.Category );		
		}


		[Test]
		public void Category_UsedInTheConstructor()
		{
			mdnaSettings.Settings settings = new mdnaSettings.Settings( "foo" );
			Assert.AreEqual( "foo", settings.Category );
		}


		#endregion

	}
}
