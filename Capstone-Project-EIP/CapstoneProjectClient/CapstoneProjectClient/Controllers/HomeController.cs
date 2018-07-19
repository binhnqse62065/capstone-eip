﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;

namespace CapstoneProjectClient.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index/{eventId}")]
        public ActionResult Index(int eventId)
        {
            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(eventId);
            ViewBag.EventId = eventId;
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.ElementAt(0).SessionID;
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