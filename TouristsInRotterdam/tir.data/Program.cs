using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace tir.data
{
	class Program
	{
		static void Main(string[] args)
		{
			var sourceFile = "http://www.rotterdamopendata.nl/storage/f/2013-04-17T140812/RET-haltebestand.csv";

			var client = new WebClient();
			using (var stream = new MemoryStream(client.DownloadData(sourceFile)))
			{
				//var csvFile = new CsvReader(stream.ReadToEnd);
				Console.Read();
			}
		}
	}
}
