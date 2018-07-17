﻿using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectClient.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        [Route("Session/Index/{eventId}")]
        public ActionResult Index(int eventId)
        {
            ViewBag.EventId = eventId;
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if(listSession.Count() == 1)
            {
                return RedirectToAction("Index", "Timeline", new { eventId = ViewBag.EventId, sessionId = listSession.ElementAt(0).SessionID });
                //return View();
            }
            return View(listSession);
        }
    }
}