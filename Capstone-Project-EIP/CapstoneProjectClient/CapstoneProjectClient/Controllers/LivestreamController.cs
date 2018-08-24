using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProjectClient.ViewModel;
using HmsService.Sdk;

namespace CapstoneProjectClient.Controllers
{
    public class LivestreamController : Controller
    {
        // GET: Livestream
        [Route("Livestream/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId,int sessionId)
        {
            
            SessionApi sessionApi = new SessionApi();
            ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);

            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;

            var curSession = sessionApi.GetSessionById(sessionId);
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            int countSession = listSession.Count();
            if (countSession == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;    
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
            return View(curSession);
        }
    }
}