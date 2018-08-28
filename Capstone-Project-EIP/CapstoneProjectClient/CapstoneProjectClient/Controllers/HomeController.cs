using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;
using CapstoneProjectClient.ViewModel;

namespace CapstoneProjectClient.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index/{eventId}")]
        public ActionResult Index(int eventId)
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

            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(eventId);
            ViewBag.EventId = eventId;
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
            return View(eventCurr);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}