using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tir.web.webTirCacheTableAdapters;
using static tir.web.webTirCache;

namespace tir.web.Models
{
	public class Station
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//StationType in plaats van string, dit is iets voor later
		public string Type { get; set; }
		public string Latitude { get; set; }

		public string Longitude { get; set; }

		public static string GetLocations()
		{
			_sqlConn = new SqlConnection(Properties.Settings.Default.TirCache);
			_sqlConn.Open();

			_dataTables = new webTirCache();

			var taStations = new StationsTableAdapter();
			var tblStations = _dataTables.Stations;
			taStations.Fill(tblStations);

			string stationArray = "";

			for (int i = 0; i < tblStations.Count; i++)
			{
				stationArray += string.Format(@"[""{0}"",""<strong>{0}</strong><p>{1}</p>"",{2},{3},{4}]",
					tblStations[i].Name,
					tblStations[i].Type,
					tblStations[i].Latitude,
					tblStations[i].Longitude,
					tblStations[i].Id);

				if (i != tblStations.Count)
				{
					stationArray += ",";
				}

			}

			stationArray = string.Format(@"[{0}]", stationArray);

			return stationArray;
		}

		public void Dispose()
		{
			_sqlConn?.Close();
			_sqlConn?.Dispose();
		}

		private static SqlConnection _sqlConn;
		private static webTirCache _dataTables;
	}
}