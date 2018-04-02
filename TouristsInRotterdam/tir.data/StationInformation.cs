using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tir.data.dsTirCacheTableAdapters;
using static tir.data.dsTirCache;
using tir.web.Models;
using System.Data.SqlClient;

namespace tir.data
{
	public class StationInformation
	{
		public StationInformation()
		{
			_sqlConn = new SqlConnection(tir.web.Properties.Settings.Default.TirCache);
			_sqlConn.Open();
			//_dataTables = new dsTirCache();
		}
		public static string GetLocations()
		{
			_dataTables = new dsTirCache();
			var taStations = new StationsTableAdapter();
			var tblStations = _dataTables.Stations;
			taStations.Fill(tblStations);

			List<StationsRow> Stations = new List<StationsRow>();

			foreach (var row in tblStations)
			{
				Stations.Add(row);
			}

			return "yolo";
		}
		private static SqlConnection _sqlConn;
		private static dsTirCache _dataTables;
	}
}
