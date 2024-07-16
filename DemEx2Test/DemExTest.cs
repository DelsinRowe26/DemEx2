using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DemEx2Test
{
	[TestClass]
	public class DemExTest
	{
		[TestMethod]
		public void DBConnectTest()
		{

			string sql = @"Data Source = DESKTOP-R2UPGH3\DR; Initial Catalog = DemExam; Integrated Security = True";
			bool connect = true;

			//DemEx2.DBConnect con = new DemEx2.DBConnect();
			bool actual = DemEx2.DBConnect.DBC(sql);

			Assert.AreEqual(connect, actual);

		}
	}
}
