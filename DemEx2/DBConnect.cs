using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Contexts;

namespace DemEx2
{
	internal class DBConnect
	{
		public static SqlConnection sqlConn;
		public static void DataBaseConn(string sql)
		{
			sqlConn = new SqlConnection(sql);
		}

		public static void LoadedDB(string sql, out DataTable dt)
		{
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();

			string Get_Data = "SELECT * FROM [Plan]";

			SqlCommand cmd = sqlConn.CreateCommand();
			cmd.CommandText = Get_Data;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			dt = new DataTable("[Plan]");

			adapter.Fill(dt);
		}

		public static void DateFilter(string sql, string Date, out DataTable dt)
		{
			sqlConn = new SqlConnection(sql);

			sqlConn.Open();

			string Get_Data = "SELECT * FROM [Plan] WHERE DATE = " + "'" + Date + "'";
			SqlCommand cmd = sqlConn.CreateCommand();
			cmd.CommandText = Get_Data;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			dt = new DataTable("[Plan]");

			adapter.Fill(dt);
		}

		public static void SQLQueryAutorization(string id, string password)
		{
			string sqlQuery = "SELECT * FROM [dbo].[участники] WHERE [Почта]= '" + id + "' and [пароль]='" + password + "'";
			
			using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, sqlConn))
			{
				DataTable table = new DataTable();

				dataAdapter.Fill(table);//Вылетает ошибка

				if (table.Rows.Count == 0)
				{
					MessageBox.Show("Ошибка, вы ввели неправильное имя, либо фамиилию, либо отчество");
				}
				else
				{
					MessageBox.Show("Добро пожаловать!");
					/*Form2 newForm = new Form2();
                    newForm.Show();*/
				}
			}
		}
	}
}
