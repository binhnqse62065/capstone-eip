using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProjectClient.ViewModel;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class TimelineController : Controller
    {
        // GET: Timeline
        [Route("Timeline/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId, int sessionId)
        {
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId
            }).ToList();

            TimelineApi timelineApi = new TimelineApi();
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            var timeline = timelineApi.GetAllTimesBySessionId(sessionId);
            SessionApi sessionApi = new SessionApi();
            ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);

            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
            }
            return View(timeline);
        }
    }
}