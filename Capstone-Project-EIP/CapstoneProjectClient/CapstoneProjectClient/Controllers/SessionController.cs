﻿using CapstoneProjectClient.ViewModel;
using HmsService.Sdk;
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
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;
            SessionApi sessionApi = new SessionApi();
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            ViewBag.EventName = listSession.FirstOrDefault().EventName;
            if(listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
                ViewBag.SessionId = listSession.FirstOrDefault().SessionID;
                return RedirectToAction("Index", "QA", new { eventId = ViewBag.EventId, sessionId = ViewBag.SessionId });
            }

            return View(listSession);
        }
    }
}