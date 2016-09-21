using System;
using System.Data;
using System.Data.Odbc;

namespace dbtest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString = "DRIVER={MySQL ODBC 3.51 Driver};" +
				"SERVER=localhost;DATABASE=user;" +
				"UID=db_tab;PASSWORD=t5mmcZdECBhVvfnT;" +
				"OPTION=3";
			IDbConnection dbcon;
			dbcon = new OdbcConnection(connectionString);
			try {
				dbcon.Open();
				Console.WriteLine("Conectat");
				IDbCommand dbcmd = dbcon.CreateCommand ();
				string sql = "SELECT firstname, lastname FROM `table` LIMIT 5";
				dbcmd.CommandText = sql;
				IDataReader reader = dbcmd.ExecuteReader();
				while(reader.Read()) {
					string FirstName = (string) reader["firstname"];
					string LastName = (string) reader["lastname"];
					Console.WriteLine("Name: " + FirstName + " " + LastName);
				}
				reader.Close();
				reader = null;
				dbcmd.Dispose();
				dbcmd = null;
				dbcon.Close();
				dbcon = null;
			} catch (Exception ex) {
				Console.WriteLine ("No s'ha pogut obrir la conexio: " + ex.ToString());
			}
		}
	}
}
