using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace tir.data
{
	class Program
	{
		static void Main(string[] args)
		{

			WebClient client = new WebClient();

			byte[] bytes = client.DownloadData(Properties.Settings.Default.SourceURL);

			var resultString = Encoding.Default.GetString(bytes);

			//TextReader text = new StringReader(resultString);

			using (var stream = new MemoryStream())
			using (var writer = new StreamWriter(stream))
			using (var reader = new StreamReader(stream))
			using (var csv = new CsvReader(reader))
			{
				writer.Write(resultString);
				writer.Flush();
				stream.Position = 0;

				csv.Configuration.Delimiter = ";";

				var records = csv.GetRecords<Stop>().ToList();

			}
		}
	}
}
