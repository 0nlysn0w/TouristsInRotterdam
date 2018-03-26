using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace tir.web.Models
{
	public class TirContext : DbContext
	{
		public TirContext(): base()
        {
			Database.SetInitializer<TirContext>(new CreateDatabaseIfNotExists<TirContext>());
		}

		public DbSet<Station> Stations { get; set; }
		public DbSet<PointOfInterest> PointsOfInterest { get; set; }
	}
}