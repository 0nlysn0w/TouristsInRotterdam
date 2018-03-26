using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tir.web.Models
{
	public class PointOfInterest
	{
		public int id { get; set; }
		public string name { get; set; }
		public PointOfInterestType PointOfInterestType { get; set; }
		public double lon { get; set; }
		public double lat { get; set; }
		public string address { get; set; }
		public string zipcode { get; set; }
		public string town { get; set; } = "Rotterdam";
	}
}