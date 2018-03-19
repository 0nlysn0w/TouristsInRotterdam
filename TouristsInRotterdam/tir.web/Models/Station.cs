using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristsInRotterdam.Models
{
	public class Station
	{
		public int id { get; set; }
		public string operator_id { get; set; }
		public string name { get; set; }
		public string town { get; set; }
		public double lon { get; set; }
		public double lat { get; set; }
		public StationType StationType { get; set; }
	}
}