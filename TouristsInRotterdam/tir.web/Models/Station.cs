using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
	}
}