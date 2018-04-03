using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tir.web.webTirCacheTableAdapters;
using static tir.web.webTirCache;

namespace tir.web.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
			_sqlConn = new SqlConnection(Properties.Settings.Default.TirCache);
			_sqlConn.Open();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Map()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult GetLocations()
		{
			_dataTables = new webTirCache();

			var taStations = new StationsTableAdapter();
			var tblStations = _dataTables.Stations;
			taStations.Fill(tblStations);

			List<StationsRow> Stations = new List<StationsRow>();

			foreach (var row in tblStations)
			{
				Stations.Add(row);
			}

			return Content("yolo");
		}



		private static SqlConnection _sqlConn;
		private static webTirCache _dataTables;

	}
}