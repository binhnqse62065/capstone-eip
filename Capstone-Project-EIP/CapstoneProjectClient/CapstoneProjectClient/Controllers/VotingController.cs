using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProjectClient.ViewModel;
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
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;
            
            VotingApi votingApi = new VotingApi();
            InteractionApi interactionApi = new InteractionApi();
            int votingId = (int)interactionApi.GetVotingIdBySessionId(sessionId);
            Voting voting = votingApi.GetVotingById(votingId);

            SessionApi sessionApi = new SessionApi();
            ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);

            var listSession = sessionApi.GetSessionsByEventId(eventId);
            int countSession = listSession.Count();
            if (countSession == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;
                //return RedirectToAction("Index", "QA", new { eventId = ViewBag.EventId, sessionId = ViewBag.SessionId });
            }
            else if (countSession == 0)
            {
                ViewBag.SessionNumber = 0;
                ViewBag.SessionId = 0;
            }
            else
            {
                /*Trường hợp có nhiều session*/
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;
                ViewBag.SessionNumber = countSession;
                ViewBag.IsSubMenu = true;
            }

            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            return View(voting);
        }
        // GET: Voting
        [Route("Voting/List/{eventId}/{sessionId}")]
        public ActionResult ListVoting(int eventId, int sessionId)
        {
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            SessionApi sessionApi = new SessionApi();

            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;


            IEnumerable<int> listSessionId = sessionApi.BaseService.Get(s => s.EventId == eventId && s.IsActive == true).ToList().Select(s=>s.SessionID);
            VotingApi votingApi = new VotingApi();
            InteractionApi interactionApi = new InteractionApi();

            //int votingId = (int)interactionApi.GetVotingIdBySessionId(sessionId);
            //Voting voting = votingApi.GetVotingById(votingId);

            IEnumerable<Voting> listVotingIsRunning = interactionApi
                .BaseService
                .Get(i => i.IsRunning == true 
                        && i.VotingId != null
                        && (sessionId == -1 || sessionId == i.SessionId )
                        && listSessionId.Contains(i.SessionId))
                .ToList()
                .Select(i => i.Voting);


            //ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);

            var listSession = sessionApi.GetSessionsByEventId(eventId);
            int countSession = listSession.Count();
            if (countSession == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;
                //return RedirectToAction("Index", "QA", new { eventId = ViewBag.EventId, sessionId = ViewBag.SessionId });
            }
            else if (countSession == 0)
            {
                ViewBag.SessionNumber = 0;
                ViewBag.SessionId = 0;
            }
            else
            {
                /*Trường hợp có nhiều session*/
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;
                ViewBag.SessionNumber = countSession;
                ViewBag.IsSubMenu = false;
            }

            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            return View(listVotingIsRunning);
        }


    }


}