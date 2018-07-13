using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService;
using HmsService.Models.Entities;

namespace CapstoneProjectClient.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        [Route("Activity/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId, int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            ActivityApi activityApi = new ActivityApi();
            var listActivity = activityApi.GetActivitiesBySessionId(sessionId);
            return View(listActivity);

        }
    }
}