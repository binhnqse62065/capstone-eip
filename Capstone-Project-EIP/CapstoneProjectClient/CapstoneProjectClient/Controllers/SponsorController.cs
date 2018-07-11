using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;


namespace CapstoneProjectClient.Controllers
{
    public class SponsorController : Controller
    {
        // GET: Sponsor
        [Route("Sponsor/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId,int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listSponsor = eventCollectionApi.GetSponsorByEventId(eventId);
            return View(listSponsor);
        }
    }
}