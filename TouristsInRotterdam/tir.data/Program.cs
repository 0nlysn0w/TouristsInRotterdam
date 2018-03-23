using System;
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
				string stopDesc = "";
				foreach (var stop in stops)
				{
					stopDesc += stop.desc;
					StopType(stopDesc);
				}

			}
		}
		// https://codereview.stackexchange.com/questions/119519/regex-to-first-match-then-replace-found-matches
		public static string StopType(string desc)
		{
			var Input = "Tram";

			Regex rx = new Regex(@"tram", RegexOptions.IgnoreCase);

			Match match = rx.Match(desc);

			var type = desc;
			return type;
		}
	}
}
