﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        private HmsEntities db = new HmsEntities();
        public ActionResult Index()
        {
            EventApi eventApi = new EventApi();
            var cur = eventApi.BaseService.GetEventById(1);
            return View(cur.Sessions.ElementAt(1));
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}
