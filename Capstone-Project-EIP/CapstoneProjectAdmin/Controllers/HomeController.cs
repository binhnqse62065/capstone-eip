﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Sdk;
using HmsService.Models.Entities.Services;
using HmsService.Models.Entities;

namespace CapstoneProjectAdmin.Controllers
{
    public class HomeController : Controller
    {
        private HmsEntities db = new HmsEntities();
        public ActionResult Index(int id)
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(id);
            ViewBag.EventId = id;
            return View(cur);
        }

        public ActionResult Edit(int id)
        {
            var currentEvent = db.Events.Find(id);
            return View(currentEvent);
        }

        [HttpPost]
        public ActionResult Update(Event eventUpdate)
        {
            var eventUp = db.Events.Find(1);
            eventUp.Name = eventUp.Name;
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                var err = e.Message;
            }
            
            return View("Index");
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

        public ActionResult AdminView()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}