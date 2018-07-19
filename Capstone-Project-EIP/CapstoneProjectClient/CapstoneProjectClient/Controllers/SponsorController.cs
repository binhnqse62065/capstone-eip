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
        [Route("Sponsor/Index/{eventId}")]
        public ActionResult Index(int eventId)
        {
            ViewBag.EventId = eventId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listSponsor = eventCollectionApi.GetSponsorByEventId(eventId);
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.ElementAt(0).SessionID;
            }
            return View(listSponsor);
        }
    }
}