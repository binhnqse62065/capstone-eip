using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class LivestreamController : Controller
    {
        // GET: Livestream
        [Route("Livestream/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId,int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            SessionApi sessionApi = new SessionApi();
            var curSession = sessionApi.GetSessionById(sessionId);
            return View(curSession);
        }
    }
}