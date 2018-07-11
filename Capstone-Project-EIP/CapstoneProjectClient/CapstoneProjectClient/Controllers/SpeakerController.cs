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
        [Route("Speaker/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId, int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listSpeaker = eventCollectionApi.GetSpeakerByEventId(eventId);
            return View(listSpeaker);
        }
    }
}