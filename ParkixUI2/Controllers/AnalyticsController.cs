using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TensorFlowSharpCore;
using ParkixUI2.Services;
using ParkixUI2.Services.Contracts;
using ParkixUI2.Models;

namespace ParkixUI2.Controllers
{
    /// <summary>
    /// The controller for the analytics 'engine'.
    /// </summary>
    public class AnalyticsController : Controller
    {
        private static IPredictionService predictionService = PredictionService.Instance;
        private static IReportingService reportingService = ReportingService.Instance;
        private static IWeatherService weatherService = WeatherService.Instance;
        private static IEventService eventService = EventService.Instance;
        private static IMessagingService messageService = MessagingService.Instance;

        public static AnalyticsModel analyticsModel = new AnalyticsModel();

        public AnalyticsController()
        {
            predictionService.Token = AuthTokenService.Instance.ReportAuthToken;
        }

        //GET: /Analytics/
        public IActionResult Index()
        {
            analyticsModel.Events = eventService.GetEvents();
            analyticsModel.Messages = messageService.GetMessages();

            //KSBP for SLO airport.
            analyticsModel.Weather = weatherService.GetWeather("KSBP");

            // These are loaded into the view as Javascript, so we store them in the model as Javascript arrays.
            analyticsModel.ScheduleData = $"[{string.Join(",", predictionService.GetScheduleData().ToArray())}]";
            analyticsModel.PredictedData = $"[{string.Join(",", predictionService.GetPrediction("GE1").ToArray())}]";

            // For demonstration purposes, we're going to again choose to return a known-good data range.
            var start = new DateTime(2017, 7, 8);
            var end = new DateTime(2017, 7, 9);

            //Get actual data values and multiply them by 100 to scale percentage values.
            var actualData = reportingService.GetHistoricalLotData("GE1", start, end).Select(x => x.value * 100).ToList();

            analyticsModel.ActualData = $"[{string.Join(",", actualData.ToArray())}]";

            return View(analyticsModel);
        }

    }
}