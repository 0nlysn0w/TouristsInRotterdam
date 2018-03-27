using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace tir.data
{
	public class DatabaseHelper
	{
		public void CreateIfNotExists(string connectionstring)
		{
			var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionstring);
			var database = ConnectionStringBuilder.InitialCatalog;

			ConnectionStringBuilder.InitialCatalog = "master";

			using (var connection = new SqlConnection(ConnectionStringBuilder.ToString()))
			{
				connection.Open();

				using (var command = connection.CreateCommand())
				{
					command.CommandText = string.Format("select * from sys.databases where name='{0}'", database);

					using (var reader = command.ExecuteReader())
					{
						if (reader.HasRows)
							return;
					}
					command.CommandText = string.Format("create database {0}", database);
					command.ExecuteNonQuery();
				}
			}
		}
	}
	public class DatabaseConfiguration
	{
		public static tir.web.Properties.Settings Settings = tir.web.Properties.Settings.Default;

		public DatabaseConfiguration(string connectionstring)
		{
			_helper.CreateIfNotExists(connectionstring);
		}

		public void DatabaseBuilder()
		{
			CheckTables();
		}
		public void CheckTables()
		{
			using (var connection = new SqlConnection(Settings.TirCache.ToString()))
			{
				connection.Open();

				using (var command = connection.CreateCommand())
				{
					command.CommandText = "select * from information_schema.tables";

					using (var reader = command.ExecuteReader())
					{
						if (reader.HasRows)
							return;
					}
					ExcecuteQueries();
				}
			}
		}

		private void ExcecuteQueries()
		{
			var queries = _files.LoadFiles();
			using (var connection = new SqlConnection(Settings.TirCache.ToString()))
			{
				connection.Open();

				using (var command = connection.CreateCommand())
				{
					foreach (var query in queries)
					{
						Debug.WriteLine(string.Format("==> Now executing {0}", query.QueryName));
						command.CommandText = "USE [" + connection.Database + "]" + query.QueryString;
						command.ExecuteNonQuery();
					}
				}
			}
		}
		private FileProcessing _files = new FileProcessing();
		private DatabaseHelper _helper = new DatabaseHelper();
	}


	public class FileProcessing
	{
		public List<QueryObject> LoadFiles()
		{
			var location = Directory.GetCurrentDirectory();
			var sqlpath = Path.Combine(location, "sql");
			bool doesexist = Directory.Exists(sqlpath);
			List<QueryObject> Queries = new List<QueryObject>();

			if (doesexist)
			{
				string[] filepaths = Directory.GetFiles(sqlpath, "*.sql", 0);
				foreach (var path in filepaths)
				{
					QueryObject query = new QueryObject();
					query.QueryName = Path.GetFileNameWithoutExtension(path);
					query.QueryString = File.ReadAllText(path);
					Queries.Add(query);
				}
			}
			else
			{
				Console.WriteLine("Make sure you didn't made any changes in the installation folder.");
				Console.WriteLine("Can not continue. The application will close.");
				Thread.Sleep(3000);
			}

			return Queries;
		}
	}

	public class QueryObject
	{
		public string QueryName { get; set; }
		public string QueryString { get; set; }
	}
}