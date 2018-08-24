using CapstoneProjectClient.ViewModel;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectClient.Controllers
{
    public class CollectionController : Controller
    {
        [Route("Collection/Index/{eventId}/{typeId}/{sessionId}")]
        // GET: Collection
        public ActionResult Index(int eventId, int typeId, int sessionId)
        {
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;
            var currentCollection = eventCollectionApi.GetEventCollectionByType(eventId, typeId);


            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(eventId);
            ViewBag.EventName = eventCurr.Name;

            SessionApi sessionApi = new SessionApi();
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
                ViewBag.SessionId = 0;
                ViewBag.SessionNumber = countSession;
            }
            return View(currentCollection);
        }
    }
}