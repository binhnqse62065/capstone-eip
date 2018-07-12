using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;

namespace CapstoneProjectClient.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId, int sessionId)
        {
            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(eventId);
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            return View(eventCurr);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}