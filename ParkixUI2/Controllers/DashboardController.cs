using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ParkixUI2.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using ParkixUI2.Services;
using ParkixUI2.Services.Contracts;

namespace ParkixUI2.Controllers
{
    /// <summary>
    /// The main view of the application.
    /// </summary>
    public class DashboardController : Controller
    {

        private static IConfigurationService configurationService = ConfigurationService.Instance;
        private static IReportingService reportingService = ReportingService.Instance;
        private static IMessagingService messagingService = MessagingService.Instance;
        private static IEventService eventService = EventService.Instance;

		public static DashboardModel dashModel = new DashboardModel();

        public DashboardController()
        {
            reportingService.Token = AuthTokenService.Instance.ReportAuthToken;
            configurationService.Token = AuthTokenService.Instance.ConfigureAuthToken;
        }

        //This method is used to get data for use in the dashModel. 
        //TODO: Triage.
        private void generateLotData()
        {

            //Horrifying hacks to build JS arrays for use in the view.
            var h1 = reportingService.GetLatestLotData("H1");
            var ge1 = reportingService.GetLatestLotData("GE1");
            dashModel.H1 = "[" + (int)(h1 * 100) + "," + (100 - (int)(h1 * 100)) + "]";
            dashModel.CurrentPercentFull = (int)(ge1 * 100);
            dashModel.TotalInUse = "[" + (100 - dashModel.CurrentPercentFull) + ", " + dashModel.CurrentPercentFull + "]";
            dashModel.GE1 = "[" + (100 - dashModel.CurrentPercentFull) + ", " + dashModel.CurrentPercentFull + "]";
            dashModel.SpotsInUse = (int) (6500f * ge1);
            dashModel.SpotsAvailable = 6500 - dashModel.SpotsInUse;

            //Use known-good dataset for demonstration.
            var start = new DateTime(2017, 7, 8);
            var end = new DateTime(2017, 7, 9);

            var historicalData = reportingService.GetHistoricalLotData("GE1", start, end);
            //Scale percentages and use string interpolation to create a JS array.
            dashModel.GraphData = BuildChartsData(historicalData);

        }

        // GET: Dashboard
        public ActionResult Index()
		{
            dashModel.Events = eventService.GetEvents();
            dashModel.Messages = messagingService.GetMessages();
            dashModel.Lots = configurationService.GetAssociations().Values.ToList();
            generateLotData();
            
			return View(dashModel);
		}

        // GET: Dashboard/Messages
        public IActionResult Messages()
        {
            dashModel.Messages = messagingService.GetMessages();
            return View(dashModel);
        }

        // GET: Dashboard/Messages/ViewMessage?id=
        public IActionResult ViewMessage(int id)
        {
            ViewData["MessageID"] = id;
            ViewData["MessageSubject"] = dashModel.Messages[id].subject;
            ViewData["MessageDateTime"] = dashModel.Messages[id].timestamp.ToString("MM/dd/yyyy hh:mm");
            ViewData["MessageData"] = dashModel.Messages[id].message;

            return View(dashModel);
        }

        // GET: Dashboard/Settings
        public IActionResult Settings()
        {
            dashModel.Sensors = configurationService.GetSensors();
            return View(dashModel);
        }

        //GET: Dashboard/Sensor?id=
		public IActionResult Sensor(string id)
		{
            ViewData["id"] = id;
			return View(dashModel);
		}

        //GET: Dashboard/Config?id=
		public IActionResult Config(string id)
		{
			ViewData["id"] = id;
            ViewData["image"] = configurationService.GetImage(id);
			return View(dashModel);
		}

        //POST: Dashboard/SendConfig
		[HttpPost]
		public ActionResult SendConfig([FromBody] string guid, [FromBody] string points)
		{
			//TODO:  POST the data from here to Configuration.

			return RedirectToAction("Config/" + guid);
		}

        //This function is used to build a particular JS array format required by the charts library.
        private string BuildChartsData(List<LotData> data)
        {
            var sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < data.Count; i++)
            {
                sb.Append("[" + i + "," + (data[i].value * 100) + "]");

                if (i != data.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}
