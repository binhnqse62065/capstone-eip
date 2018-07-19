using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class SpeakerController : Controller
    {
        // GET: Speaker
        [Route("Speaker/Index/{eventId}")]
        public ActionResult Index(int eventId)
        {
            ViewBag.EventId = eventId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listSpeaker = eventCollectionApi.GetSpeakerByEventId(eventId);
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.ElementAt(0).SessionID;
            }
            return View(listSpeaker);
        }
    }
}