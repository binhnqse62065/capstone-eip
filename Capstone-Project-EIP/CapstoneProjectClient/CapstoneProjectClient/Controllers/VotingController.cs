using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class VotingController : Controller
    {
        // GET: Voting
        [Route("Voting/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId,int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            VotingApi votingApi = new VotingApi();
            InteractionApi interactionApi = new InteractionApi();
            int votingId = (int)interactionApi.GetVotingIdBySessionId(sessionId);
            Voting voting = votingApi.GetVotingById(votingId);

            SessionApi sessionApi = new SessionApi();
            ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);

            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
            }
            return View(voting);
        }

       
    }


}