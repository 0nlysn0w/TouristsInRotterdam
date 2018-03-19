using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tir.data
{
	class Program
	{
		static void Main(string[] args)
		{
			var sourceFile = "stops.csv.gz";
			using (var client = new WebClient())
			{
				client.DownloadFile("http://data.openov.nl/haltes/stops.csv.gz", sourceFile);
			}

			var targetFile = File.ReadAllBytes(sourceFile);
			var decompressed = Decompress(targetFile);

			//var formattedData = Encoding.ASCII.GetString(decompressed);

			var reader = new StreamReader(decompressed);


			Console.ReadLine();
		}

		static Stream Decompress(byte[] gzip)
		{
			// Create a GZIP stream with decompression mode.
			// ... Then create a buffer and write into while reading from the GZIP stream.
			using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
				CompressionMode.Decompress))
			{
				const int size = 4096;
				byte[] buffer = new byte[size];
				using (MemoryStream memory = new MemoryStream())
				{
					int count = 0;
					do
					{
						count = stream.Read(buffer, 0, size);
						if (count > 0)
						{
							memory.Write(buffer, 0, count);
						}
					}
					while (count > 0);
					return memory;
				}
			}
		}
	}
}
