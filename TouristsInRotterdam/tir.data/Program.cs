﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Text.RegularExpressions;

namespace tir.data
{
	class Program
	{
		static void Main(string[] args)
		{
			WebClient client = new WebClient();

			byte[] bytes = client.DownloadData(Properties.Settings.Default.SourceURL);

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

				var stops = csv.GetRecords<Stop>().ToList();

				for (int i = 0; i < stops.Count; i++)
				{
					stops[i].desc = StopType(stops[i].desc);
				}
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
	}
}
