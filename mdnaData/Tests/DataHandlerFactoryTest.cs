using System;
using NUnit.Framework;

namespace mdnaData.Tests
{
	/// <summary>
	/// Summary description for DataHandlerFactoryTest.
	/// </summary>
	[TestFixture]
	public class DataHandlerFactoryTest
	{
		public DataHandlerFactoryTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Tests

		[Test]
		public void InstantiateAFactory()
		{
			DataHandlerFactory factory = new DataHandlerFactory();

			Assert.AreNotEqual( null, factory );
		}

		[Test]
		public void Create_ReturnAnOracleHandler()
		{
			DataHandlerFactory factory = new DataHandlerFactory();
			IDataHandler myHandler = factory.Create( "OracleHandler" );

            Assert.AreEqual( "OracleHandler", myHandler.HandlerClassID() );
		}
		#endregion

		
		#region SetUp and TearDown

		[TestFixtureSetUp]
		public void SetUp()
		{
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
		}

		#endregion
	}
}
