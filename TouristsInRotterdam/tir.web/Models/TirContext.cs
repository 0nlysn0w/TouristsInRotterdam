using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TouristsInRotterdam.Models
{
	public class TirContext : DbContext
	{
		public TirContext(): base()
        {

		}

		public DbSet<Station> Stations { get; set; }
		public DbSet<PointOfInterest> PointsOfInterest { get; set; }
	}
}