﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Text.RegularExpressions;
using tir.web.Models;
using System.Data.SqlClient;
using tir.data.dsTirCacheTableAdapters;

namespace tir.data
{
	class Program
	{
		public Program()
		{
			_sqlConn = new SqlConnection(tir.web.Properties.Settings.Default.TirCache);
			_sqlConn.Open();
			
		}
		public static tir.web.Properties.Settings Settings = tir.web.Properties.Settings.Default;
		static void Main(string[] args)
		{
			var databaseConfig = new DatabaseConfiguration(Settings.TirCache);

			databaseConfig.DatabaseBuilder();

			foreach (var DataSource in Properties.Settings.Default.DataSources)
			{
				WebClient client = new WebClient();
				byte[] bytes = client.DownloadData(DataSource);

				DataProcessor(bytes);
			}

		}
		public static void DataProcessor(byte[] bytes) { 
			
			var resultString = Encoding.Default.GetString(bytes);

			using (var stream = new MemoryStream())
			using (var writer = new StreamWriter(stream))
			using (var reader = new StreamReader(stream))
			using (var csv = new CsvReader(reader))
			{
				writer.Write(resultString);
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.Delimiter = ";";

				List<csvStop> csvStops = csv.GetRecords<csvStop>().ToList();
				List<tir.web.Models.Station> stations = new List<tir.web.Models.Station>();
				for (int i = 0; i < csvStops.Count(); i++)
				{
					csvStops[i].desc = StopType(csvStops[i].desc);

					if (csvStops[i].desc != "Unknown")
					{
						stations.Add(new tir.web.Models.Station()
						{
							Name = csvStops[i].name,
							Type = csvStops[i].desc,
							Longitude = csvStops[i].longitude.Replace(",","."),
							Latitude = csvStops[i].latitude.Replace(",", ".")
						});
					}

				}

				stations = stations.
					GroupBy(o => new { o.Name, o.Type })
					.Select(o => o.FirstOrDefault())
					.ToList();
				//saving

				_dataTables = new dsTirCache();

				var taStation = new StationsTableAdapter();
				var tblStations = _dataTables.Stations;

				foreach (var station in stations)
				{
					var newRow = tblStations.NewStationsRow();
					newRow.Name = station.Name;
					newRow.Type = station.Type;
					newRow.Longitude = station.Longitude;
					newRow.Latitude = station.Latitude;

					tblStations.AddStationsRow(newRow);
				}
				taStation.Update(tblStations);

			}
		}
		public static string StopType(string desc)
		{
			List<string> SearchTypes = Enum.GetNames(typeof(tir.web.Models.StationType)).ToList();

			foreach (var toMatch in SearchTypes)
			{
				Regex rx = new Regex(toMatch, RegexOptions.IgnoreCase);

				var match = rx.Match(desc);

				if (rx.Match(desc).Success)
				{
					return toMatch;
				}
			}
			return "Unknown";
		}

		private static SqlConnection _sqlConn;
		private static dsTirCache _dataTables;

	}
}
